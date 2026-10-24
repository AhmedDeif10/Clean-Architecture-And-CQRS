namespace Clean_Architecture_And_CQRS.Application.Products.Commands
{
    public record DeleteProductCommand(int Id)
    : IRequest<bool>;
}
