using ECommerceDomain.Model;
using ECommerceInfrastructure.Contracts;
using ECommerceInfrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceInfrastructure.Repository
{
    public class CategoriesRepository : GenericRepository<Categories>, ICategoriesRepository
    {

        public CategoriesRepository(ApplicationDbContext dbContext) :base (dbContext)
        {
            
        }

        public async Task<List<Categories>> GetAllCategoriesAsync()
        {
            return await _dbContext.Categories.Include(x => x.category).Include(x => x.category).AsNoTracking().ToListAsync();

        }

        public async Task<Categories> GetByDetailAsync(int id)
        {
            return await _dbContext.Categories.Include(x => x.category).Include(x => x.category).AsNoTracking().FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task UpdateAsync(Categories categories)
        {
            _dbContext.Update(categories);
            await _dbContext.SaveChangesAsync();
        }
    }
}
