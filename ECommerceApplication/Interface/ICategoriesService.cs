using ECommerceApplication.DTO.Categories;
using ECommerceApplication.DTO.Category;
using ECommerceApplication.DTO.MenClothing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Interface
{
    public interface ICategoriesService
    {
        Task<CategoriesDto> GetByIdAsync(int id);

        Task<IEnumerable<CategoriesDto>> GetAllAsync();

        Task<CategoriesDto> createAsync(CreateCategoriesDto createCategoriesDto);

        Task<IEnumerable<CategoriesDto>> GetByFilterAsync(int? Id, int? CategoryId);


        Task UpdateAsync (UpdateCategoriesDto updateCategoriesDto); 

        Task DeleteAsync(int id);

    }
}
