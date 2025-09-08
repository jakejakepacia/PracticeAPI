using PracticeAPI.Data;
using PracticeAPI.Models.Api;
using PracticeAPI.Models.Entities;

namespace PracticeAPI.Services
{
    public class ProductService
    {
        private readonly ApplicationDBContext _dbContext;

        public ProductService(ApplicationDBContext dbContext) => _dbContext = dbContext;

        public async Task<OperationResult> AddProductAsync(ProductRequestModel model)
        {
            if (model == null)
                return OperationResult.FailureResult(["Faied to add product"]);

            try
            {
                var newProduct = new Product
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    UserId = model.UserId
                };

                await _dbContext.Products.AddAsync(newProduct);
                await _dbContext.SaveChangesAsync();

                return OperationResult.SuccessResult("Added product successfully");
            }
            catch (Exception ex)
            {
                // Log the exception here (if using logging)
                return OperationResult.FailureResult(["Faied to add product" + ex.Message]);
            }
        }

    }
}
