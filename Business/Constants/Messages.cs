using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {

        public static string LocationDeleted = "Konum silindi.";
        public static string LocationsListed = "Konumlar listelendi.";
        public static string AuthorizationDenied = "Erişim reddedildi.";
        public static string UserAlreadyExists = "Kullanıcı zaten var.";
        public static string SuccessfulLogin = "Başarılı giriş.";
        public static string PasswordError = "Şifre hatası.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string UserRegistered = "Kullanıcı kaydedildi.";
        public static string locationUpdated = "Konum güncellendi.";
        public static string LocationAdded = "Konum eklendi..";
        public static string TimeZoneInvalid = "Zaman Dilimi Bulunamadı.";
        public static string LocationNotFound = "Konum bulunamadı.";
    }
}
