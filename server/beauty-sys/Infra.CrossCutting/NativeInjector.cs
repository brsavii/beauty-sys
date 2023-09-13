using Application.AppServices;
using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICustomerAppService, CustomerAppService>();
        }
    }
}
