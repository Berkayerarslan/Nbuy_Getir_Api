using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Sessions
{
    /// <summary>
    /// KUllanıcıya ait Sepet bilgileri Sipariş işlemleri sırasında Sessionda saklanacak,  Bunun gibi oturum bazlı veri saklma durumlarımız için bu servisi kullanacağız.
    /// </summary>
    public interface ISessionService<TObject> where TObject:class
    {
        void Add(TObject @object, string key); // key value cinsinden ramde oturum bilgisini onject olarak tutmak için kullancağız.
        void Remove(string key); // ilgili session bilgisini ramden kaldırmak için kullanacağız.
        /// <summary>
        /// Ramde oturum bazlı saklanan değer
        /// </summary>
        TObject GetSession(string key);
    }
}
