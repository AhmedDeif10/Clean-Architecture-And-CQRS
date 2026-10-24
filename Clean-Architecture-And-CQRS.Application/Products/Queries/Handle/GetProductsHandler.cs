using Clean_Architecture_And_CQRS.Application.Products.DTO;
using Clean_Architecture_And_CQRS.Application.Products.RepositoryInterface;
using MediatR;

namespace Clean_Architecture_And_CQRS.Application.Products.Queries.Handle
{
    public class GetProductsHandler
    : IRequestHandler<GetProductsQuery, List<ProductDto>>
    {
        private readonly IProductRepository _repository;

        public GetProductsHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ProductDto>> Handle(
            GetProductsQuery request,
            CancellationToken cancellationToken)
        {
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
