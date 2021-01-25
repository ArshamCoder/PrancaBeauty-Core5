using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using PrancaBeauty.WebApp.Localization.Resource;
using System;
using System.Reflection;

namespace PrancaBeauty.WebApp.Localization
{
    public class FactoryLocalizer
    {
        public IStringLocalizer Set(IStringLocalizerFactory factory, Type typeOfSharedResource)
        {
            var assemblyName = new AssemblyName(typeOfSharedResource.GetTypeInfo().Assembly.FullName ?? throw new NullReferenceException());
            return factory.Create(nameof(SharedResource), assemblyName.Name ?? throw new NullReferenceException());
        }


        public IStringLocalizer Set(IServiceCollection services, Type typeOfSharedResource)
        {
            var factory = services.BuildServiceProvider().GetService<IStringLocalizerFactory>();
            var assemblyName = new AssemblyName(typeOfSharedResource.GetTypeInfo().Assembly.FullName ?? throw new NullReferenceException());
            return factory.Create(nameof(SharedResource), assemblyName.Name ?? throw new NullReferenceException());

        }
    }
}
