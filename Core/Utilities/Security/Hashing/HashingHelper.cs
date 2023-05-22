using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    //çıplak kalabilir bir araç
    //burasu hashing oluşturmaya ve onu doğrulamaya yarıyor
    public class HashingHelper
    {
        //bu kod verilen pasword değerinin salt ve hash değerini oluşturur
        public static void CreatePasswordHash
            (string password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key; //key:o an kullandığımız algoritmanın oluşturduğu key değeridir.dolayısıyla her kullanıcı için bir key oluşturur
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)); //password'u string'den byte'a çevirir
            }
        }
        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }           
        }
    }
}
