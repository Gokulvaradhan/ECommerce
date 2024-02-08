using ECommerceInfrastructure.Contracts;
using ECommerceInfrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceInfrastructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoriesRepository,CategoriesRepository>();
            services.AddScoped<ISubCategoryRepository,SubCategoryRepository>();
            services.AddScoped<IProductRepository,ProductRepository>(); 
            services.AddScoped<IAddToCartRepository,AddToCartRepository>();
            return services;
        }
    }
}
