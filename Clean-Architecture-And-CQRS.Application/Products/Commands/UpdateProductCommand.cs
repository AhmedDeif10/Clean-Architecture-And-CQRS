using MediatR;
namespace Clean_Architecture_And_CQRS.Application.Products.Commands
{
    public record UpdateProductCommand(
    int Id,
    string Name,
    decimal Price) : IRequest<bool>;
}
