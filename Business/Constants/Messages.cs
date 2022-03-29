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
        public static string ProductAdded = "Ürün eklendi.";  //public değişkenler büyük harfle yazılır.
        public static string ProductNameInvalid = "Ürün ismi geçersiz.";

        public static string ProductUpdated = "Ürün güncellendi.";
        public static string LocationDeleted = "Ürün silindi.";

        public static string MaintenanceTime = "Sistem bakımda.";
        public static string LocationsListed = "Ürünler listelendi.";

        public static string TooManyProductsInCategory = "Kategori içinde çok fazla ürün var.";

        public static string ProductNameAlreadyExists = "Bu isimde zaten başka bir ürün var.";
        public static string AuthorizationDenied = "Erişim reddedildi.";
        public static string UserAlreadyExists = "Kullanıcı zaten var.";
        public static string AccessTokenCreated = "Access token created";
        public static string SuccessfulLogin = "Başarılı giriş.";
        public static string PasswordError = "Şifre hatası.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string UserRegistered = "Kullanıcı kaydedildi.";
        public static string CategoriesListed = "Kategoriler listelendi.";
        internal static string locationUpdated;
        internal static string LocationAdded;

        public static string TooManyCategoriesToAddProduct { get; internal set; }
    }
}
