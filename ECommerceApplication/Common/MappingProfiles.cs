using AutoMapper;
using ECommerceApplication.DTO.Categories;
using ECommerceApplication.DTO.Category;
using ECommerceApplication.DTO.MenClothing;
using ECommerceApplication.DTO.MenClothingType;
using ECommerceDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Common
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Category, UpdateCategoryDto>().ReverseMap();
            CreateMap<Category, CreateCategoryDto>().ReverseMap();


            CreateMap<SubCategory, CreateSubCategoryDto>().ReverseMap();
            CreateMap<SubCategory, UpdateSubCategoryDto>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDto>()
            .ForMember(x => x.Category, opt => opt.MapFrom(src => src.category.CategoryName));



            CreateMap<Product, CreateProductDto>().ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ProductDto>()
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.CategoryName))
            .ForPath(dest => dest.SubCateGory, opt => opt.MapFrom(src => src.SubCategory.SubCategoryName));

            CreateMap< Categories,CreateCategoriesDto>().ReverseMap();
            CreateMap<Categories,UpdateCategoriesDto>().ReverseMap();
            CreateMap<Categories, CategoriesDto>()
            .ForMember(x => x.Category, opt => opt.MapFrom(src => src.category.CategoryName));
       



        }
    }
}
