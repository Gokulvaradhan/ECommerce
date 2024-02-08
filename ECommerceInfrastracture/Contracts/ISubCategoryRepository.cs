using ECommerceDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceInfrastructure.Contracts
{
    public interface ISubCategoryRepository : IGenericRepository<SubCategory>
    {

        Task<List<SubCategory>> GetAllSubCategoriesAsync();
        Task<SubCategory> GetByDetailAsync(int id);
        Task UpdateAsync(SubCategory subCategory);
    }
}
