using Nbuy_Getir.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Domain.Models
{
    public class Category: AuditableEntity
    {
        public string Name { get; set; }
        /// <summary>
        /// En üst seviye olan kategorileri listeleyeceğiz Bu üst seviye altına eklenen alt kategorileri ise ürünle ile bağlayacağız.
        /// </summary>
        public bool IsTopLevel { get; set; }


        private List<Category> _subCategories { get; set; } = new List<Category>();
        public IReadOnlyCollection<Category> SubCategories => _subCategories;

        private List<Product> _products = new List<Product>();
        public IReadOnlyList<Product> Products => _products;

        public Category(string name, bool isTopLEvel = false)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("kategori ismi boş geçilemez.");
            }
        }

        public void AddSubCategory(Category category)
        {
            if (string.IsNullOrEmpty(category.Name))
            {
                throw new Exception("kategori ismi boş geçilemez.");

            }
            _subCategories.Add(category);
        }
        public void AddProduct(Product product)
        {
            // !IsTopLevel && _subCategories.Count == 0 en alt kategoridir.
            if (!IsTopLevel && _subCategories.Count() == 0)
            {
                _products.Add(product);
            }
        }
    }
}
