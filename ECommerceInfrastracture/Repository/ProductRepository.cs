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
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {

        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {

        }

        public async Task<List<Product>> GetAllProductAsync()
        {
            return await _dbContext.Products.Include(x=>x.Category).Include(x=>x.SubCategory).AsNoTracking().ToListAsync();
        }

        public async  Task<Product> GetByDetailAsync(int id)
        {
            return await _dbContext.Products.Include(x => x.Category).Include(x => x.SubCategory).AsNoTracking().FirstOrDefaultAsync(x=>x.CategoryID==id);

        }

        public async Task UpdateAsync(Product product)
        {
            _dbContext.Update(product);
           await _dbContext.SaveChangesAsync(); 
        }
    }
}
