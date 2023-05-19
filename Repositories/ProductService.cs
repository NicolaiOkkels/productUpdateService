using product_update_service.DataAccess;
using product_update_service.Entities;
using Microsoft.EntityFrameworkCore;

namespace product_update_service.Repositories
{
    public class ProductService : IProductService
    {
        private readonly ProductDbContext dbContext;

        public ProductService(ProductDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Wine>> WineListAsync()
        {
            return await dbContext.Wines.ToListAsync();
        }

        public async Task<Wine?> GetWineByIdAsync(Guid productId)
        {
            var wine = await dbContext.Wines.Where(x => x.ProductGuid == productId).FirstOrDefaultAsync();

            if (wine == null)
            {
                throw new Exception("Wine not found");
            }

            return wine;
        }
    }
}