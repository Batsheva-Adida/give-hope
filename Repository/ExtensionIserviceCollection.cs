using Microsoft.Extensions.DependencyInjection;
using Repository.Entity;
using Repository.Interface;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public static class ExtensionIserviceCollection
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<Categories>), typeof(CategoryRepository));
            services.AddScoped(typeof(ILogin),typeof(CustomerRepository));
            services.AddScoped(typeof(IRepository<Medicines>),typeof(MedicinesRepository));
            services.AddScoped(typeof(IRepository<Question>),typeof(QuestionRepository));
            services.AddScoped(typeof(IRepository<Comments>),typeof(CommentsRepository));
            return services;
        }
       /* public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Customers>, CustomerRepository>();

            return services;
        }
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Medicines>, MedicinesRepository>();

            return services;
        }*/
    }
}
