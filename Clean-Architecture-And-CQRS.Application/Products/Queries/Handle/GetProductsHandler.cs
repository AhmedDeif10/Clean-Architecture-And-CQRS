using Clean_Architecture_And_CQRS.Application.Products.DTO;
using Microsoft.Extensions.Logging;

namespace Clean_Architecture_And_CQRS.Application.Products.Queries.Handle
{
    public class GetProductsHandler
    : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<GetProductsHandler> _logger;

        public GetProductsHandler(IProductRepository repository, ILogger<GetProductsHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<List<ProductDto>> Handle(
            GetProductsQuery request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
            "Retrieving all products");

            var products = await _repository.GetAllAsync(
                cancellationToken);

            
            return products
                .Select(product => new ProductDto(
                    product.Id,
                    product.Name,
                    product.Price))
                .ToList();

        }
    }
}
