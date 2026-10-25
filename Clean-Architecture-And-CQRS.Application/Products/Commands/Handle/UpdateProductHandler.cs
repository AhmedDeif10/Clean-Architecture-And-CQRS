using Microsoft.Extensions.Logging;

namespace Clean_Architecture_And_CQRS.Application.Products.Commands.Handle
{
    public class UpdateProductHandler
     : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<UpdateProductHandler> _logger;

        public UpdateProductHandler(IProductRepository repository , ILogger<UpdateProductHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(
            UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Updating product with ID {ProductId}",
                request.Id);

            var product = await _repository.GetByIdAsync(
                request.Id,
                cancellationToken);

            if (product is null)
            {
                _logger.LogWarning(
                    "Cannot update product. Product with ID {ProductId} was not found",
                    request.Id); 

                return false;
            }

            product.Update(
                request.Name,
                request.Price);

            await _repository.UpdateAsync(
                product,
                cancellationToken);

            _logger.LogInformation(
               "Product with ID {ProductId} updated successfully",
               request.Id);

            return true;
        }
    }
}
