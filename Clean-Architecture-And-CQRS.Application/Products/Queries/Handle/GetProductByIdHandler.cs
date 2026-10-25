using Microsoft.Extensions.Logging;

namespace Clean_Architecture_And_CQRS.Application.Products.Queries.Handle
{
    public class GetProductByIdHandler
    : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<GetProductByIdHandler> _logger;

        public GetProductByIdHandler(IProductRepository repository, ILogger<GetProductByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ProductDto?> Handle(
            GetProductByIdQuery request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
            "Getting product with ID {ProductId}",
            request.Id);


            var product = await _repository.GetByIdAsync(
                request.Id,
                cancellationToken);

            if (product is null)
            {
                _logger.LogInformation(
            "Product with ID {ProductId} was retrieved successfully",
            product.Id);
                return null;
            }

            return new ProductDto(
                product.Id,
                product.Name,
                product.Price);
        }
    }
}
