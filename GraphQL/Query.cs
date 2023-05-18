using Microsoft.EntityFrameworkCore;
using Nest;
using product_update_service;

namespace product_update_service
{
    public class Query
    {
        [GraphQLDescription("Get all wines")]
        public async Task<List<Wine>> GetWinesAsync([Service] ProductContext context)
        {
            try
            {
                return await context.Wine.ToListAsync();
            }
            catch (Exception e)
            {
                // Log the exception
                Console.WriteLine(e);
                // You could also consider returning a default value instead of re-throwing the exception
                throw;
            }
        }

        [GraphQLDescription("Get a wine by id")]
        public async Task<Wine> GetWine([Service] ProductContext context, Guid id)
        {
            try
            {
                return await context.Wine.FirstOrDefaultAsync(x => x.ProductGuid == id);
            }
            catch (Exception e)
            {
                // Log the exception
                Console.WriteLine(e);
                // You could also consider returning a default value instead of re-throwing the exception
                throw;
            }
        }

        [GraphQLDescription("Test database connection")]
        public async Task<bool> CanConnectAsync([Service] ProductContext context)
        {
            try
            {
                return await context.Database.CanConnectAsync();
            }
            catch (Exception e)
            {
                // Log the exception with more details
                Console.WriteLine("Exception caught in CanConnectAsync: " + e.ToString());
                throw;
            }
        }

        [GraphQLDescription("Search wines by category")]
        public async Task<List<Wine>> SearchWinesByCategoryAsync([Service] ProductContext context, [Service] IElasticClient elasticClient, int categoryId)
        {
            try
            {
                var searchResponse = await elasticClient.SearchAsync<Wine>(s => s
                    .Index("wine-category-index")
                    .Query(q => q
                        .Match(m => m
                            .Field(f => f.CategoryId)
                            .Query(categoryId.ToString())
                        )
                    )
                );

                return searchResponse.Documents.ToList();
            }
            catch (Exception e)
            {
                // Log the exception
                Console.WriteLine(e);
                // You could also consider returning a default value instead of re-throwing the exception
                throw;
            }
        }

    }
}