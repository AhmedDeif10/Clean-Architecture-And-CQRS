namespace Clean_Architecture_And_CQRS.Application.Products.Commands.Handle
{
    public class CreateProductHandler
    : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IProductRepository _repository;

        public CreateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductDto> Handle(
            CreateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = new Product(
                request.Name,
                request.Price);

            var createdProduct = await _repository.AddAsync(
                product,
                cancellationToken);

            return new ProductDto(
                createdProduct.Id,
                createdProduct.Name,
                createdProduct.Price);
        }
    }
}
