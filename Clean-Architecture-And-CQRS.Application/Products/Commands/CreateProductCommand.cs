using Clean_Architecture_And_CQRS.Application.Products.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture_And_CQRS.Application.Products.Commands
{
    public record CreateProductCommand(
     string Name,
     decimal Price) : IRequest<ProductDto>;
}
