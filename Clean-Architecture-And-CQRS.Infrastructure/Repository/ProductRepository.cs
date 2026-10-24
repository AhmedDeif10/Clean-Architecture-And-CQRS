using Clean_Architecture_And_CQRS.Application.Products.RepositoryInterface;
using Clean_Architecture_And_CQRS.Domain.Entities;
using Clean_Architecture_And_CQRS.Infrastructure.Dbcontext;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture_And_CQRS.Infrastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync(
            CancellationToken cancellationToken)
        {
            return await _context.Products
                .AsNoTracking()
                .OrderBy(product => product.Id)
                .ToListAsync(cancellationToken);
        }

        public async Task<Product?> GetByIdAsync(
            int id,
            CancellationToken cancellationToken)
        {
            return await _context.Products
                .FirstOrDefaultAsync(
                    product => product.Id == id,
                    cancellationToken);
        }

        public async Task<Product> AddAsync(
            Product product,
            CancellationToken cancellationToken)
        {
            _context.Products.Add(product);

            await _context.SaveChangesAsync(cancellationToken);

            return product;
        }

        public async Task UpdateAsync(
            Product product,
            CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(
            Product product,
            CancellationToken cancellationToken)
        {
            _context.Products.Remove(product);

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
