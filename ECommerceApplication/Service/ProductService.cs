using AutoMapper;
using ECommerceApplication.DTO.MenClothing;
using ECommerceApplication.DTO.MenClothingType;
using ECommerceApplication.Interface;
using ECommerceDomain.Model;
using ECommerceInfrastructure.Contracts;
using ECommerceInfrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Service
{
    public class ProductService  : IProductService
    {
        private readonly IProductRepository _ProductRepository;

        private readonly IMapper _Mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            
            _ProductRepository = productRepository;
            _Mapper = mapper;
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto createProductDto)
        {
            var Men = _Mapper.Map<Product>(createProductDto);
            var AddEntity = await _ProductRepository.CreateAsync(Men);
            var Entity = _Mapper.Map<ProductDto>(AddEntity);
            return Entity;
        }

        public async Task DeleteAsync(int id)
        {
            var Men = await _ProductRepository.GetByIdAsync(x => x.ProductID == id);
            await _ProductRepository.DeleteAsync(Men);
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var Men = await _ProductRepository.GetAllProductAsync();
            return _Mapper.Map<List<ProductDto>>(Men);
        }

        public async Task<IEnumerable<ProductDto>> GetByFilterAsync(int? ProductId, int? categoryId,int? subcategoryId)
        {
            var data = await _ProductRepository.GetAllProductAsync();

            IEnumerable<Product> query = data;
            if (categoryId > 0)
            {
                query = query.Where(x => x.CategoryID == categoryId);
            }
            if (ProductId > 0)
            {
                query = query.Where(x => x.ProductID == ProductId);
            }
            if (subcategoryId > 0)
            {
                query = query.Where(x => x.SubCategoryID == ProductId);
            }
            var result = _Mapper.Map<List<ProductDto>>(query);
            return result;
        }

        public async Task<ProductDto> GetByIdAsync(int id)
        {
            var Men = await _ProductRepository.GetByDetailAsync(id);
            return _Mapper.Map<ProductDto>(Men);
        }


        public async Task UpdateAsync(UpdateProductDto menClothingUpdateDto)
        {
            var Type = _Mapper.Map<Product>(menClothingUpdateDto);
            await _ProductRepository.UpdateAsync(Type);
        }

      
    }
}

