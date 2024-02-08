using ECommerceApplication.DTO.Category;

using ECommerceDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Interface
{
    public interface ICategoryService
    {
        Task<CategoryDto> GetByIdAsync(int id);

        Task<CategoryDto> CreateAsync(CreateCategoryDto createCategoryDto);

        Task UpdateAsync(UpdateCategoryDto updateCategoryDto);

        Task<IEnumerable<CategoryDto>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
