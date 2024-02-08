using ECommerceApplication.DTO.Categories;
using ECommerceApplication.DTO.MenClothingType;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Interface
{
    public interface ISubCategoryService 
    {
        Task<SubCategoryDto> GetByIdAsync(int id);

        Task<IEnumerable<SubCategoryDto>> GetAllAsync();

        Task<SubCategoryDto> CreateAsync (CreateSubCategoryDto createSubCategoryDto);

        Task<IEnumerable<SubCategoryDto>> GetByFilterAsync(int? CategoryId , int? SubCategoryId);

        Task UpdateAsync (UpdateSubCategoryDto updateSubCategoryDto); 

        Task DeleteAsync (int id);

    }
}
