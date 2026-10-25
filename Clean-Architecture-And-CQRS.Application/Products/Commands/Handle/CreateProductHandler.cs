using Microsoft.Extensions.Logging;

namespace Clean_Architecture_And_CQRS.Application.Products.Commands.Handle
{
    public class CreateProductHandler
    : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _repository;
        private readonly ILogger<CreateProductHandler> _logger;

        public CreateProductHandler(IProductRepository repository, ILogger<CreateProductHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ProductDto> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Creating product with name {ProductName}",
                request.Name);

            var product = new Product(
                request.Name,
                request.Price);

            var createdProduct = await _repository.AddAsync(
                product,
                cancellationToken);

            _logger.LogInformation(
                "Product created successfully. ProductId: {ProductId}",
                createdProduct.Id);

            return new ProductDto(
                createdProduct.Id,
                createdProduct.Name,
                createdProduct.Price);
        }
    }
}
