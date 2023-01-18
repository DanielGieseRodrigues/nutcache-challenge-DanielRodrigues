using ConEmployeeRegistratationtatos.Domain.Interfaces;
using EmployeeRegistratation.Context.Persistence;
using EmployeeRegistratation.Domain.Entities;
using EmployeeRegistratation.Domain.Interfaces;
using EmployeeRegistratation.Domain.Services;
using EmployeeRegistratation.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace EmployeeRegistration.Application.DI
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services, string conection)
        {
            services.AddDbContext<EmployeeContext>(options => options.UseSqlServer(conection));
            services.AddScoped(typeof(IRepository<Employee>), typeof(EmployeeRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IEmployeeService), typeof(EmployeeService));
        }
    }
}
