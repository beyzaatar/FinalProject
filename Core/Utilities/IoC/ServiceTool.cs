using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        //bu kod webapi'de veya autofac'de  injectionları oluşturmamızı sağlıyor.
        //istediğimiz interface'in karşılığını bu tool vasıtasıyla alabiliriz. 
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceCollection Create(IServiceCollection services) //.net'in servislerini al ve onları build et
        {
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}
