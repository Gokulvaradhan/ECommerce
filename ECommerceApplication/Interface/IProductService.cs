using ECommerceApplication.DTO.MenClothing;
using ECommerceInfrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Interface
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();

        Task<ProductDto> GetByIdAsync(int id);

        Task<IEnumerable<ProductDto>> GetByFilterAsync(int? ProductId, int? categoryId,int ? subcategoryId);

        Task<ProductDto>CreateAsync(CreateProductDto menClothingCreateDto);

        Task UpdateAsync (UpdateProductDto menClothingUpdateDto);

        Task DeleteAsync (int id);
  
    }
}
