using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ProniaOnion.Application.DTOs.Categories;
using ProniaOnion.Application.Validator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Application.ServiceRegistration
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddAplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services
            //    .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            //////services.AddTransient<IValidator<CreateCategoryDto>, CreateCategoryDtoValidator>(); register manually one by one

            services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters()
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
