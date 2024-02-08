using ECommerceDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceInfrastructure.Contracts
{
    public interface ICategoriesRepository : IGenericRepository<Categories>
    {
        Task<List<Categories>> GetAllCategoriesAsync();
        Task<Categories> GetByDetailAsync(int id);
        Task UpdateAsync(Categories category);
    }
}
