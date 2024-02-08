using ECommerceDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceInfrastructure.Contracts
{
    public interface IProductRepository  : IGenericRepository<Product>
    {
        Task<List<Product>> GetAllProductAsync();
        Task<Product> GetByDetailAsync(int id);
        Task UpdateAsync (Product product);  
        
    }
}
