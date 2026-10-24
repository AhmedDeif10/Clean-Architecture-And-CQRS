namespace Clean_Architecture_And_CQRS.Application.Products.Commands
{
    public record CreateProductCommand(
     string Name,
     decimal Price) : IRequest<ProductDto>;
}
