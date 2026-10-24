namespace Clean_Architecture_And_CQRS.Application.Products.Queries
{
    public record GetProductByIdQuery(int Id)
    : IRequest<ProductDto?>;
}
