using AutoMapper;
using ECommerceApplication.DTO.Category;
using ECommerceApplication.Interface;
using ECommerceDomain.Model;
using ECommerceInfrastructure.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        private readonly IMapper _Mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _Mapper = mapper;
        }

        public async Task<CategoryDto> CreateAsync(CreateCategoryDto createCategoryDto)
        {
            var category = _Mapper.Map<Category>(createCategoryDto);
            var AddEntity = await _categoryRepository.CreateAsync(category);
            var Entity = _Mapper.Map<CategoryDto>(AddEntity);
            return Entity;

        }

        public async Task DeleteAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(x => x.CategoryId ==id);
            await _categoryRepository.DeleteAsync(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            var category = await _categoryRepository.GetAllAsync();
            return _Mapper.Map<List<CategoryDto>>(category);
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(x => x.CategoryId == id);
            return _Mapper.Map<CategoryDto>(category);
        }

        public async Task UpdateAsync(UpdateCategoryDto updateCategoryDto)
        {
            var category = _Mapper.Map<Category>(updateCategoryDto);
            await _categoryRepository.UpdateAsync(category);
        }
    }
}
