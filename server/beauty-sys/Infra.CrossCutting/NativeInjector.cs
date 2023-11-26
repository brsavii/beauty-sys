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
            services.AddScoped<IProcedureAppService, ProcedureAppService>();
            services.AddScoped<ISchedulingAppService, SchedulingAppService>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IProcedureService, ProcedureService>();
            services.AddScoped<ISchedulingService, SchedulingService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISchedulingRepository, SchedulingRepository>();
            services.AddScoped<IProcedureRepository, ProcedureRepository>();
        }
    }
}
