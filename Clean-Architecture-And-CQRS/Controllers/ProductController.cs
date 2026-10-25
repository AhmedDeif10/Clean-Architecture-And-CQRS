namespace Clean_Architecture_And_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ISender sender, ILogger<ProductController> logger)
        {
            _sender = sender;
            _logger = logger;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Getting all products");

            var products = await _sender.Send(
                new GetProductsQuery(),
                cancellationToken);

            _logger.LogInformation(
                "Retrieved {ProductCount} products",
                products.Count);

            return Ok(products);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Getting product with ID {ProductId}",
                id);

            var product = await _sender.Send(
                new GetProductByIdQuery(id),
                cancellationToken);

            if (product is null)
            {
                _logger.LogWarning(
                    "Product with ID {ProductId} was not found",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Product with ID {ProductId} retrieved successfully",
                id);

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody] CreateProductRequest request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Creating a product");

            var command = new CreateProductCommand(
                request.Name,
                request.Price);

            var product = await _sender.Send(
                command,
                cancellationToken);

            _logger.LogInformation(
               "Product created successfully. ProductId: {ProductId}",
               product.Id);

            return CreatedAtAction(
                nameof(GetById),
                new { id = product.Id },
                product);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateProductRequest request,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Updating product with ID {ProductId}",
                id);

            var command = new UpdateProductCommand(
                id,
                request.Name,
                request.Price);

            var updated = await _sender.Send(
                command,
                cancellationToken);

            if (!updated)
            {
                _logger.LogWarning(
                    "Cannot update product. ProductId: {ProductId} was not found",
                    id);
                return NotFound();
            }
            _logger.LogInformation(
                "Product with ID {ProductId} updated successfully",
                id);

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(
            int id,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
               "Deleting product with ID {ProductId}",
               id);

            var deleted = await _sender.Send(
                new DeleteProductCommand(id),
                cancellationToken);

            if (!deleted)
            {
                _logger.LogWarning(
                   "Cannot delete product. ProductId: {ProductId} was not found",
                   id);

                return NotFound();
            }

            _logger.LogInformation(
               "Product with ID {ProductId} deleted successfully",
               id);

            return NoContent();
        }
    }
}
