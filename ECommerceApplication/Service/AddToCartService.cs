using AutoMapper;
using ECommerceApplication.DTO.CartItem;
using ECommerceApplication.DTO.Categories;
using ECommerceApplication.Interface;
using ECommerceDomain.CartItem;
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
    public class AddToCartService : IAddToCartService
    {

        private readonly IAddToCartRepository _addToCartRepository;

        protected readonly IMapper _mapper;

        public AddToCartService(IAddToCartRepository addToCartRepository,IMapper mapper)
        {
        }

        public async Task<IEnumerable<AddToCartDto>> AddToCartAsync()
        {
            var cart = await _addToCartRepository.GetAllAsync();
            return   _mapper.Map<List<AddToCartDto>>(cart); 
        }

        public async Task DeleteAsync(int id)
        {
            var cart = await _addToCartRepository.GetByIdAsync(x=>x.CartItemId==id);
            await _addToCartRepository.DeleteAsync(cart);
        }
    }
}
