namespace Clean_Architecture_And_CQRS.Application.Products.Queries
{
    public record GetProductsQuery
        : IRequest<List<ProductDto>>; 
    
}
