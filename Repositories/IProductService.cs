using product_update_service.Entities;

namespace product_update_service.Repositories
{
    public interface IProductService
    {
        public Task<List<Wine>> WineListAsync();

        public Task<Wine?> GetWineByIdAsync(Guid productId);
    }
}