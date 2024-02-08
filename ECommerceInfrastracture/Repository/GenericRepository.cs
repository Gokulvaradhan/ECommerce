using ECommerceInfrastructure.Contracts;
using ECommerceInfrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceInfrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        protected readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> CreateAsync(T entity)
        {
            var AddEntity = await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return AddEntity.Entity;
        }

        public async Task<T> DeleteAsync(T entity)
        {
            _dbContext.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Expression<Func<T, bool>> condition)
        {
            return await _dbContext.Set<T>().AsNoTracking().FirstOrDefaultAsync(condition);
        }
    }
}
