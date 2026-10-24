using Clean_Architecture_And_CQRS.Application.Products.RepositoryInterface;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture_And_CQRS.Application.Products.Commands.Handle
{
    public class UpdateProductHandler
     : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _repository;

        public UpdateProductHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(
            UpdateProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(
                request.Id,
                cancellationToken);

            if (product is null)
            {
                return false;
            }

            product.Update(
                request.Name,
                request.Price);

            await _repository.UpdateAsync(
                product,
                cancellationToken);

            return true;
        }
    }
}
