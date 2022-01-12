using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Authentication
{
    public class TokenClaim
    {
        public string ClaimType { get; set; } // username, Tole
        public string ClaimValue { get; set; } // Berkay, Admin

    }
    public class TokenModel
    {
        public string AccessToken { get; set; } // Base64 formatındaki token bilgisi
        public DateTime ExpireDate { get; set; } // token ne zman expire olacağı bilgisi
    }

    /// <summary>
    /// Belirli bir süreliğine Acces Token üretmek için bu servisi kulllancağız.
    /// Tokenda taşınacak bilgiler için TokenClaim adında bir sınıf kullancağız Key value olarak tokenda bilgi saklayacağız. 
    /// Token Model ise kullanıcının Access Token ve bu token geçerlilik süresi için açtığımız model
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Sisteme giriş yapacak kullanıcılar için Erişim Bileti Access Token oluşturacağız.
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        TokenModel CreateAccessToken(List<TokenClaim> claims);
        /// <summary>
        /// KUllanıcya ait Access Token nilgisinin artık kullanılmaması için çalıştıracamız method. Bu token bilgisi kullanıcdan giriş alınacaktır.
        // Oturum açmaişleminde bu tokenın bir daha bu kullanıcı tarafından kullanılmaması için var.
        /// </summary>
        /// <param name="token"></param>
        void RevokeAccessToken(string token); 
    }
}
