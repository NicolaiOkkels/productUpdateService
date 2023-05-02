public class ProductServiceClient : IProductService
{
    private readonly HttpClient _httpClient;

    public ProductServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Wine>> GetWinesAsync()
    {
        var response = await _httpClient.GetAsync("api/wine");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<List<Wine>>();
    }

    public async Task<Wine> GetWineAsync(Guid productGuid)
    {
        var response = await _httpClient.GetAsync($"api/wine/{productGuid}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<Wine>();
    }

    public async Task<Wine> CreateWineAsync(Wine wine)
    {
        var response = await _httpClient.PostAsJsonAsync("api/wine", wine);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<Wine>();
    }

    public async Task<Wine> UpdateWineAsync(Guid productGuid, Wine wine)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/wine/{productGuid}", wine);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<Wine>();
    }

    public async Task DeleteWineAsync(Guid productGuid)
    {
        var response = await _httpClient.DeleteAsync($"api/wine/{productGuid}");
        response.EnsureSuccessStatusCode();
    }
}