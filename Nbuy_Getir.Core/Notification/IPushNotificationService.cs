using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nbuy_Getir.Core.Notification
{
    public interface IPushNotificationService
    {
        /// <summary>
        /// Mobil uygulamayı bir kullanıcı indirince user hesabında DeviceId tutacağız. One Signal ile kişinin cihazına mesaj göndereceğiz.
        ///  AppId mobil uygulamayı indiren kullanıcıya one signal tarafından verilen Id Bu ıd değerini user tablosunda tutacağız. ve bildirim gönderirken bu ıd değere göre bildirim gönderecepiz.
        /// </summary>
        /// <param name="deviceId"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task SendPushNotificationAsync(string appId, string message);
    }
}
