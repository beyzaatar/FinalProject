using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    //appsettings'deki uyduruk string securiykey ile encrpytion'a parametre geçemiyoruz. onu bir byteArray haline getirmemiz gerekiyor. burada yapılır.
    //onu simetrik anahtar haline getirmeye yarıyor
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey) //appsettings'deki key
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}
