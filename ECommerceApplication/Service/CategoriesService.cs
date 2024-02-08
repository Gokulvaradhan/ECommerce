using AutoMapper;
using ECommerceApplication.DTO.Categories;
using ECommerceApplication.DTO.Category;
using ECommerceApplication.DTO.MenClothing;
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
    public class CategoriesService : ICategoriesService
    {

        private readonly ICategoriesRepository _categoriesRepository;

        private readonly IMapper _mapper;

        public CategoriesService(ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CategoriesDto>> GetAllAsync()
        {
            var category = await _categoriesRepository.GetAllCategoriesAsync();
            return _mapper.Map<List<CategoriesDto>>(category);
        }

        public async Task<CategoriesDto> GetByIdAsync(int id)
        {
            var category = await _categoriesRepository.GetByDetailAsync(id);
            return _mapper.Map<CategoriesDto>(category);
        }

        public async Task UpdateAsync(UpdateCategoriesDto updateCategoriesDto)
        {
            var category = _mapper.Map<Categories>(updateCategoriesDto);
            await _categoriesRepository.UpdateAsync(category);
        }
        public async Task<CategoriesDto> createAsync(CreateCategoriesDto createCategoriesDto)
        {
            var category = _mapper.Map<Categories>(createCategoriesDto);
            var AddEntity = await _categoriesRepository.CreateAsync(category);
            var Entity = _mapper.Map<CategoriesDto>(AddEntity);
            return Entity;

        }
        public async Task DeleteAsync(int id)
        {
            var category = await _categoriesRepository.GetByIdAsync(x=>x.Id==id);
            await _categoriesRepository.DeleteAsync(category);
        }

        public async Task<IEnumerable<CategoriesDto>> GetByFilterAsync(int? Id, int? CategoryId)
        {
            var data = await _categoriesRepository.GetAllCategoriesAsync();

            IEnumerable<Categories> query = data;
            if (CategoryId > 0)
            {
                query = query.Where(x => x.CategoryId == CategoryId);
            }
            if (Id > 0)
            {
                query = query.Where(x => x.Id == Id);
            }
            var result = _mapper.Map<List<CategoriesDto>>(query);
            return result;
        }
    }
}
