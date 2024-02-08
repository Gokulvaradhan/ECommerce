using ECommerceApplication.DTO.CartItem;
using ECommerceDomain.CartItem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApplication.Interface
{
    public interface IAddToCartService
    {

        Task<IEnumerable <AddToCartDto>> AddToCartAsync ();

        Task DeleteAsync (int id);
    }
}
