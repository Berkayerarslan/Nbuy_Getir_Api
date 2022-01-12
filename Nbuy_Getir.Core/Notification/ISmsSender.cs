using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Notification
{
    public interface ISmsSender
    {
        /// <summary>
        /// Hangi telefon numarasına hangi mesajı atacağımızı bu servis ile yapacağız. Twilio diye bir oaket kullanacağız.
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendSmsAsync(string PhoneNumber, string message);
    }
}
