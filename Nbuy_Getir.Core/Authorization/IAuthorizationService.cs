using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Authorization
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAuthorizationService
    {
        /// <summary>
        /// Sistemde oturum açan kullanıcının sistemdeki özel kaynaklara yetkisi var mı kontrolü ypaacağız. Örneği kargo sorumlusu sadece kargodaki ürünleri görebilecek.
        /// </summary>
        /// <param name="roleName"></param>
        /// <returns></returns>
        bool HasRole(string roleName);
        bool HasRoles(params string[] roleNames);
        bool HasClaim(string claim);
        /// <summary>
        /// Claims bilgisi kullanıacıya tanımlanmıi olan özellikler örneğin nbuygetir çalışanı mı, indirim çeki tnaımlanmıi mu 
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        bool HasClaims(params string[] claims);
    }
}
