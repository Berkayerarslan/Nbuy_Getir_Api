using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Exceptions
{
    public static class ExceptionCodes
    {
        public const string UserNotFound = "1001";
        public const string OrderRejected = "2001";
        public const string AccountDenied = "3001";


    }

    /// <summary>
    /// Uygulama içerisinde logic kaynaklı hataları fırlamtak için bu sınıfı kullanacağız
    /// uygulama içerisinde oluşadcak hatalarak exceptioCodes olarak birer kod veriyoruz
    /// Hata mesajı ile hangi kodu aldığımaza dair bilgileri bu sınıftan kalırım alan sınıflar veceğız 
    /// böylelikle uygulamada oluşan hataları daha kolay loglayabilceğiz
    /// Exception sınıfı ana hata sınıfı olup kendi uygulama hata sınıflarımızda oluşturacacğız
    /// </summary>
    public abstract class ExceptionBase: Exception
    {
        public string ErrorCode { get; private set; }
        public ExceptionBase(string message, string errorCode):base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
