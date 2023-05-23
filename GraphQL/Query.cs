using Microsoft.EntityFrameworkCore;
using Nest;
using product_update_service.Entities;
using product_update_service.DataAccess;
using product_update_service.Repositories;

namespace product_update_service.GraphQL
{
    public class Query
    {
        [GraphQLDescription("Get all wines")]
        public async Task<List<Wine>> GetWinesAsync([Service] IProductService productService)        
        {
            try
            {
                return await productService.WineListAsync();
            }
            catch (Exception e)
            {
                // Log the exception
                Console.WriteLine(e);
                throw;
            }
        }

        [GraphQLDescription("Get a wine by id")]
        public async Task<Wine?> GetWine([Service] IProductService productService, Guid id)
        {
            try
            {
                return await productService.GetWineByIdAsync(id);
            }
            catch (Exception e)
            {
                // Log the exception
                Console.WriteLine(e);
                throw;
            }
        }

        /* [GraphQLDescription("Search wines by category")]
        public async Task<List<Wine>> SearchWinesByCategoryAsync([Service] IElasticClient elasticClient, int categoryId)
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
                throw;
            }
        } */
    }
}