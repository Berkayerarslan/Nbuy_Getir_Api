using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Notification
{

    public class EmailAttachement
    {
       
        /// <summary>
        /// Base 64 formatında veri resim excel word vs dosyası olabilir
        /// </summary>
        public string Base64 { get; set; }
        /// <summary>
        /// Dosya byte[] olarakda email saf halde gönderilebilir.
        /// </summary>
        public byte[] File { get; set; }
    }
    interface IEmailSender
    {
        /// <summary>
        /// E-posta atma işlemleri için bu servisi kullanacağız.
        /// </summary>
        /// <param name="to"> aralarında , olarak tek bir string ile birden fazla kişiye mail atılabilri.
        /// mert.alptekin@neominal.com,hamza.dagdeleb@gmail.com</param>
        /// <param name="subject"></param>
        /// <param name="message"></param>
        /// <param name="cc"></param>
        /// <param name="emailAttachements"></param>
        /// <returns></returns>
        Task SendEmailasync(string to, string subject, string message, string cc, List<EmailAttachement> emailAttachements = null);
       
    }
}
