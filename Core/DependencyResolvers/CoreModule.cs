﻿using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers
{
    // startup icerisinde eklenecek servisler burada merkezi bir ortamda yazilir
    public class CoreModule:ICoreModule
    {
        public void Load(IServiceCollection services)
        {
           //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager,MemoryCacheManager>();
        }
    }
}