using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DependencyResolvers
{
    //uygulama seviyesinde servis bağımlılıklarımızı çözümleyeceğimiz yer
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); //istek-yanıt arasındaki süreçte kullanıcının isteğinin takip edilme işini yapar

        }
    }
}
