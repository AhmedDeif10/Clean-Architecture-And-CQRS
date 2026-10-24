using Clean_Architecture_And_CQRS.Application.Products.DTO;
using MediatR;

namespace Clean_Architecture_And_CQRS.Application.Products.Queries
{
    public record GetProductByIdQuery(int Id)
    : IRequest<ProductDto?>;
}
