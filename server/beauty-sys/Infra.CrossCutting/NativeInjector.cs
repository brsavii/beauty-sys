using Application.AppServices;
using Application.Interfaces;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Services;
using Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.CrossCutting
{
    public static class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<ICustomerAppService, CustomerAppService>();

            services.AddScoped<IEmployeeAppService, EmployeeAppService>();

            services.AddScoped<ICustomerService, CustomerService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
