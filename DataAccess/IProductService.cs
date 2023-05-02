public interface IProductService
{
    Task<List<Wine>> GetWinesAsync();
    Task<Wine> GetWineAsync(Guid productGuid);
    Task<Wine> CreateWineAsync(Wine wine);
    Task<Wine> UpdateWineAsync(Guid productGuid, Wine wine);
    Task DeleteWineAsync(Guid productGuid);
}