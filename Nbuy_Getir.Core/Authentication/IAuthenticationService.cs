using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Authentication
{
    public class AuthenticationError
    {
        public string Code { get; set; } // 202 UserNotFound
        public string Message { get; set; } // Böyle bir kullanıcı sistemde bulunamadı
        public string Key { get; set; } // username
    }
    public class AuthenticationResult
    {
        public bool IsSucceded { get; private set; } = true;
        public string AccessToken { get; private set; }
        public List<AuthenticationError> Errors { get; private set; }

        public void AddError(AuthenticationError error)
        {
            IsSucceded = false;
            Errors.Add(error);
        }
        public void SetAccessToken(string token)
        {
            AccessToken = token;
        }


    }

    public interface IAuthenticationService
    {
        /// <summary>
        /// Login olduktan sonra rememberMe true  olursa bu token 1 aylık bir token olsun diğer türlü 1 günlük token oluşturacağız.
        /// JWT Json web token
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="rememberMe"></param>
        /// <returns></returns>
        AuthenticationResult Login(string email, string password, bool rememberMe);
        void LogOut(string accessToken); // kullanıcaya giriş işlemleri için verilen accessToken expire edeceğiz.Artık access tok geçersiz olacak. Kullanıcının sistemnden güvenli çıkışı için var.
    }
 
}
