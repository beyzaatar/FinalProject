using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; //her istek için bir hhtpcontext'i oluşur

        public SecuredOperation(string roles)
        {
            _roles = roles.Split(','); //bir metni benim blirttiğim karaktere göre ayırıp array'e atıyor
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();//servicetool injection altyapımızı aynen okuyabilmemize yarayan bir araçtır

        }

        protected override void OnBefore(IInvocation invocation) //ekleme metodunun önüne yazdık diyelimki. ekleme metodunun önünde çalıştır demek.
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles(); //kullanıcının claim rollerini bul
            foreach (var role in _roles) //bu kullanıcının rollerini gez. Claim'lerinin içinde
            {
                if (roleClaims.Contains(role)) //ilgili role varsa return et, metodu çalıştırmaya devam et
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied); //yetkin yok hatası ver
        }
    }
}
