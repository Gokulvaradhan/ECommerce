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
    public class SubCategoryRepository : GenericRepository<SubCategory>,ISubCategoryRepository
    {
        public SubCategoryRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {

        }

        public async Task<List<SubCategory>> GetAllSubCategoriesAsync()
        {
            return await _dbContext.SubCategories.Include(x => x.category).Include(x => x.category).AsNoTracking().ToListAsync();

        }

        public async Task<SubCategory> GetByDetailAsync(int id)
        {
            return await _dbContext.SubCategories.Include(x => x.category).Include(x => x.category).AsNoTracking().FirstOrDefaultAsync(x => x.SubCategoryId == id);
        }

        public async Task UpdateAsync(SubCategory subCategory)
        {
           _dbContext.Update(subCategory);
            await _dbContext.SaveChangesAsync();
        }
    }
}
