public class Query
{
    private readonly IProductService _productService;

    public Query(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<Wine> GetWineByIdAsync(Guid id)
    {
        return await _productService.GetWineAsync(id);
    }

    public async Task<List<Wine>> GetAllWinesAsync()
    {
        return await _productService.GetWinesAsync();
    }
}