using Nbuy_Getir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nbuy_Getir.Domain.Models
{
    public class Product : AuditableEntity
    {
        public string Name { get; private set; }
        public decimal UnitPrice { get; private set; }
        // Bu alan sadece program tarafında tutulacak bir alan olsun.
        public decimal DiscountedListPrice { get; private set; }
        public decimal ListPrice { get; private set; }
        public int Stock { get; set; } // current stock
        public bool IsStockCriticalLevel
        {
            get
            {
                return Stock < 10 ? true : false;
            }
        }
        public string Description { get; set; } // 10*1 1lt 2kg 30 cc 50ml
        public string PictureBase64 { get; private set; }
        public string PictureUrl { get; private set; }
        /// <summary>
        /// İndirimli ürün olup olmadığını Db de saklamayacağız. zaten elimizde bilgilere göre bu property tarafından indirimli ürün olup olmadığını buluyoruzç Ürün indirimli mi
        /// </summary>
        public bool IsDiscounted
        {
            get
            {
                return DiscountedListPrice < ListPrice ? true : false;
            }
        }


        public Product(string name, decimal unitPrice, decimal listPrice, decimal dicountedListPrice, int stock, string description, string pictureBase64, string pictureUrl)
        {
            SetName(name);
            SetPrice(unitPrice, listPrice, dicountedListPrice);
            SetDescription(description);
            SetStock(stock);
        }
        /// <summary>
        /// Hem kayıt hem de güncelleme işleminde kullanacağı için public yapıldı.
        /// Eğer boş ise default ürüne ait bir url verelim.
        /// </summary>
        public void SetPictureUrl(string pictureurl)
        {
            if (string.IsNullOrEmpty(pictureurl))
            {
                pictureurl = "default-product.jpeg";
            }
          
            PictureUrl = pictureurl.Trim();
        }
        /// <summary>
        /// ilk kayıt işleminde sadece stok değeri formdan alınırdken kullanılacağı için private yaptık.
        /// </summary>
        /// <param name="stock"></param>
        private void SetStock(int stock)
        {
            if (stock < 0)
            {
                throw new Exception("Stok değeri 0'dan küçük olamaz.");
            }
            Stock = stock;
        }
        /// <summary>
        /// Stoklama işlemi ürünün envanter girilmesi işlemi 
        /// </summary>
        /// <param name="stock"></param>
        public void StockIn(int quantity)
        {
            if (quantity <= 0)
            {
                throw new Exception("stoğa girilecek yeni ürün adeti 0 ve daha küçük olamaz");
            }
            Stock += quantity;
            // Stoğa ürün girildi eventi fırlatalım

        }
        public void StockOut(int quantity)
        {
            if (quantity < 0)
            {
                throw new Exception("0 dan küçük değer stoktan düşülemez.");
            }
            if (IsStockCriticalLevel)
            {
                // Kritik stok seviyesinde bir ürün sipariş edildi diye bir nesaj atalım.
            }
            if (quantity > Stock)
            {
                // Hatalı kayıt gönderme işlemi
                throw new Exception("Stoktan düşülen miktar stok değerinden büyük olamaz.");
            }
            Stock -= quantity;
        }
        public void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new Exception("ürün açıklama alanını doldurunuz");
            }
            if (description.Length > 50)
            {
                throw new Exception("Max 50 karakter girebilirsibiz.");
            }
            Description = description.Trim();
        }
        public void SetName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("ürün ismi boş geçilemez.");
            }

            Name = name.Trim();
        }
        /// <summary>
        /// ürüne ait fiyatların değişimini bu method ile yapacağız.
        /// </summary>
        /// <param name="unitPrice"></param>
        /// <param name="listPrice"></param>
        /// <param name="discountedListPrice"></param>
        public void SetPrice(decimal unitPrice, decimal listPrice, decimal discountedListPrice)
        {
            if (unitPrice > listPrice)
            {
                throw new Exception("Birim fiyat liste fiyatından büyük olamaz");
            }
            if (unitPrice <= 0 || listPrice <= 0 || discountedListPrice <= 0)
            {
                throw new Exception("Ürün birim fiyatı veya ürün satış fiyatı negatşf ve 0 verilemez.");
            }
            if (discountedListPrice > listPrice)
            {
                throw new Exception("İndirimli satış fiyatı satış fiyatından büyük olamaz.");
            }
            if (discountedListPrice < unitPrice)
            {
                throw new Exception("indirimli satış fiyatı biri fiyattan küçük olamaz");
            }
            ListPrice = listPrice;
            UnitPrice = unitPrice;
            DiscountedListPrice = discountedListPrice;
        }
        /// <summary>
        /// Bu methode ile bir ürünün satış fiyatına belirli bir oranda bir indirim yapılır. İndirm oranı güncellenir ve sadece Program tarafında DiscountedLİstPrice tutucağuz be indirim fiyatımız olacaktır. 11 unitPrice 13 listPrice 12.67 discountedLisPrice
        /// </summary>
        /// <param name="discountAmount"></param>
        public void DecreasePrice(decimal newPrice) // ürünün satış fiyatına indirim yap.
        {

            if (newPrice > ListPrice)
            {
                throw new Exception("İndirimli fiyat liste fiyatından büyük olamaz.");
            }

            if (UnitPrice <= UnitPrice)
            {
                throw new Exception("İndirimli fiyat birim fiyatından küçük olamaz.");
            }
            DiscountedListPrice = newPrice;
            // indirim uygula eventi fırlatacağız.
            // Bu ürünü favorisine ekleyen müşterilerine mail atsın. Ürünün fiyatı düştü maili atsın.

        }

        /// <summary>
        /// Ürünün liste fiyatı güncellenirse diye yaptık. Satış fiyatını artırıyoruz.
        /// </summary>
        /// <param name="newListPrice"></param>
        /// <param name="newDiscountedListPrice"></param>
        public void IncreasePrice(decimal newListPrice, decimal newDiscountedListPrice)
        {
            if (newListPrice < ListPrice)
            {
                throw new Exception("yenii fiyat liste fiyatından küçük olamaz.");
            }
            if (newDiscountedListPrice > newListPrice)
            {
                throw new Exception("indirimli fiyat yeni liste fiyatından büyük olamaz.");

            }
            ListPrice = newListPrice;
            DiscountedListPrice = newDiscountedListPrice;
            // Zamlı ürünleri event olarak fırlatabiliriz.
        }


    }
}
