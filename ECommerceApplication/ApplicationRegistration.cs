using ECommerceApplication.Common;
using ECommerceApplication.Interface;
using ECommerceApplication.Service;
using ECommerceInfrastructure.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddRegistrationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfiles));
            services.AddScoped(typeof(IPaginationService<,>), typeof(PaginationService<,>));
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<ICategoriesService,CategoriesService>();
            services.AddScoped<ISubCategoryService ,SubCategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
