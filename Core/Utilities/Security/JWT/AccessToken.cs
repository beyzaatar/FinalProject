using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        public string Token { get; set; } //jwt değeri.kullanıcı bize kullanıcı adı şifre verecek bizde ona token vereceğiz.
        public DateTime Expiration { get; set; } //token'ın bitiş zamanı
    }
}
