using AutoMapper;
using ECommerceApplication.DTO.Categories;
using ECommerceApplication.DTO.Category;
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
    public class SubCategoryService  : ISubCategoryService
    {
        private readonly ISubCategoryRepository _SubCategoryRepository;

        private readonly IMapper _Mapper;
        
        public SubCategoryService(ISubCategoryRepository subcategoryRepository,IMapper mapper)
        {
            _SubCategoryRepository = subcategoryRepository;
            _Mapper = mapper;
        }

        public async Task<SubCategoryDto> CreateAsync (CreateSubCategoryDto createsubcategoryTypeDto)
        {
            var Type = _Mapper.Map<SubCategory>(createsubcategoryTypeDto);
            var AddEntity = await _SubCategoryRepository.CreateAsync(Type);
            var Entity = _Mapper.Map<SubCategoryDto>(AddEntity);
            return Entity;  
        }

        public async Task DeleteAsync(int id)
        {
            var Type = await _SubCategoryRepository.GetByIdAsync(x => x.SubCategoryId == id);
            await _SubCategoryRepository.DeleteAsync(Type);
        }

        public async Task<IEnumerable<SubCategoryDto>> GetAllAsync()
        {
            var Type = await _SubCategoryRepository.GetAllSubCategoriesAsync();
            return  _Mapper.Map<List <SubCategoryDto>>(Type);
        }

        public async Task<SubCategoryDto> GetByIdAsync(int id)
        {
            var Type = await _SubCategoryRepository.GetByDetailAsync(id);
              return _Mapper.Map<SubCategoryDto>(Type);
        }

        public async Task UpdateAsync(UpdateSubCategoryDto updatesubcategoryDto)
        {
            var Type = _Mapper.Map<SubCategory>(updatesubcategoryDto);
            await _SubCategoryRepository.UpdateAsync(Type);
        }
        public async Task<IEnumerable<SubCategoryDto>> GetByFilterAsync(int? CategoryId, int? SubCategoryId)
        {
            var data = await _SubCategoryRepository.GetAllSubCategoriesAsync();

            IEnumerable<SubCategory> query = data;
            if (SubCategoryId > 0)
            {
                query = query.Where(x => x.SubCategoryId == SubCategoryId);
            }
            if (CategoryId> 0)
            {
                query = query.Where(x => x.CategoryId == CategoryId);
            }
            var result = _Mapper.Map<List<SubCategoryDto>>(query);
            return result;
        }

    }
}
