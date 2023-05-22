using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "ürün eklendi";
        public static string ProductNameInvalid = "ürün ismi geçersiz";
        public static string MaintenanceTime = "sistem bakımda";
        public static string ProductsListed = "ürünler listelendi";
        public static string ProductCountOfCategoryError="ürün sayısı fazla";
        public static string ProductNameAlreadyExists="bu isimde bir ürün zaten var";
        public static string CategoryLimitExceded="kategori limiti aşıldı";
        public static string AuthorizationDenied="yetkiniz yok";
        internal static string UserRegistered="kullanıcı kayıt edildi";
        internal static string UserNotFound="kullanıcı bulunamadı";
        internal static string PasswordError="parola hatalı";
        internal static string SuccessfulLogin="başarılı giriş";
        internal static string UserAlreadyExists="kullanıcı mevcut";
        internal static string AccessTokenCreated;
    }
}
