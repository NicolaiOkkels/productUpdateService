using Microsoft.EntityFrameworkCore;
using product_update_service.DataAccess;

namespace product_update_service
{
public class Query
{

    public Query()
    {
    }

    public async Task<List<Wine>> GetWinesAsync([Service] ProductContext context)
    {
        return await context.Wine.ToListAsync();
    }
}
}