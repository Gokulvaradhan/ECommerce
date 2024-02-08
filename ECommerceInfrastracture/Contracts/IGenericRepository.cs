using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceInfrastructure.Contracts
{
    public interface IGenericRepository<T> where T :class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(Expression<Func<T, bool>> condition);

        Task<T> CreateAsync(T entity);

        Task<T> DeleteAsync(T entity);
    }
}
