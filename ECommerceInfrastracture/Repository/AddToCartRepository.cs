using ECommerceDomain.CartItem;
using ECommerceInfrastructure.Contracts;
using ECommerceInfrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceInfrastructure.Repository
{
    public class AddToCartRepository :GenericRepository<AddToCart>, IAddToCartRepository
    {
        private readonly ApplicationDbContext _context;

        public AddToCartRepository(ApplicationDbContext context) : base(context) { }
   

    }
}
