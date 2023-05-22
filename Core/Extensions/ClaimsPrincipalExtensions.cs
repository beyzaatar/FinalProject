using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Core.Extensions
{ //bir kişinin claim'lerini ararken .net uğraştırır. claimpricipal'ı extens ederek jwt ile gelen kişinin claim'lerine erişiriz
    public static class ClaimsPrincipalExtensions
    {
        public static List<string> Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var result = claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList(); //buradaki soru işareti null olabileceğini gösterir
            return result;
        }

        public static List<string> ClaimRoles(this ClaimsPrincipal claimsPrincipal) //direk rolleri döndürür
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }
    }
}
