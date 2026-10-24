namespace Clean_Architecture_And_CQRS.Application.Products.RepositoryInterface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(
        CancellationToken cancellationToken);

        Task<Product?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken);

        Task<Product> AddAsync(
            Product product,
            CancellationToken cancellationToken);

        Task UpdateAsync(
            Product product,
            CancellationToken cancellationToken);

        Task DeleteAsync(
            Product product,
            CancellationToken cancellationToken);

    }
}
