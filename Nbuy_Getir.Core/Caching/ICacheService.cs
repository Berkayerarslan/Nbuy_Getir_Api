using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Caching
{
   


    /// <summary>
    /// Getir uygulamasındaki Kategorileri ve bu kategorilere ait alt kategori bilgisini cacheden yani ram üzerinden okuyacağız Böylece her seferinde dbden çekmediğimiz için daha hızkı bir sonuç döndüreceğiz BU gibi çok fazla crud operasyonun yapılmadığı sınıflarımızı ramden okuyabiliriz aynı zaman sepet gibi işlemler içinde tanımlanabilir. Çok fazla insert update işlemleri olmayan verilerimiz için cache mekanızmamızı kullanırız.
    /// </summary>
    public interface ICacheService<TResult> where TResult:class
    {
        /// <summary>
        /// Veriyi ramde tutarken key bilgisi üzeirnden sistemde tutacağız.
        /// </summary>
        /// <param name="cacheData"></param>
        void SetCache(string key, TResult cacheData);
        /// <summary>
        /// json string deseraliaze
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TResult GetFromCache(string key);
    }
}
