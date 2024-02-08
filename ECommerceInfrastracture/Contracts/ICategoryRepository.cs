using ECommerceDomain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceInfrastructure.Contracts
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task UpdateAsync(Category category);
    }
}

