using Microsoft.Extensions.Logging;

namespace Clean_Architecture_And_CQRS.Application.Products.Commands.Handle
{
    public class DeleteProductHandler
    : IRequestHandler<DeleteProductCommand, bool>
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<DeleteProductHandler> _logger;
        public DeleteProductHandler(IProductRepository repository , ILogger<DeleteProductHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<bool> Handle(
            DeleteProductCommand request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
               "Deleting product with ID {ProductId}",
               request.Id);

            var product = await _repository.GetByIdAsync(
                request.Id,
                cancellationToken);

            if (product is null)
            {
                _logger.LogWarning(
                   "Cannot delete product. Product with ID {ProductId} was not found",
                   request.Id);

                return false;
            }

            await _repository.DeleteAsync(
                product,
                cancellationToken);

            _logger.LogInformation(
                "Product with ID {ProductId} deleted successfully",
                request.Id);

            return true;
        }
    }
}
