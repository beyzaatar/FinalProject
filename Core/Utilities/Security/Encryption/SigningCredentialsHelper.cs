using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Encryption
{
    //credential:sisteme girmek için ihyiyacımız olan anahtarımız.
    //sen burada bir jwt sistemini yöneteceksin. güvenlik anahtarın budur,şifreleme algoritmanda budur.
    public class SigningCredentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //apsnet'e diyoruzki sen bir hashing işlemi yapıcaksın, anahtar olarak securitykey'i, şifrelemek için algoritmalardan şunu kullan
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
