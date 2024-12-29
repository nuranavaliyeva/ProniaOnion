using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProniaOnion.Application.Abstractions.Repositories;
using ProniaOnion.Application.Abstractions.Services;
using ProniaOnion.Persistence.Contexts;
using ProniaOnion.Persistence.Implementations.Repositories;
using ProniaOnion.Persistence.Implementations.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Persistence.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("Default")));

            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<IColorRepository,ColorRepository>();
            services.AddScoped<IProductRepository,ProductRepository>();

            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
