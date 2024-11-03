using Commont.Dto;
using Commont.Entity;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Service.interfaces;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddScoped<IService<CategoriesDto>, CategoriesService>();
            services.AddScoped<ILoginService, CustomersService>();
            services.AddScoped<IService<MedicinesDto>, MedicinesService>();
            services.AddScoped<IService<QuestionDto>, QuestionService>();
            services.AddScoped<IService<CommentsDto>, CommentsService>();
            services.AddAutoMapper(typeof(MapperproFile));
            return services;
        }
    }
}
