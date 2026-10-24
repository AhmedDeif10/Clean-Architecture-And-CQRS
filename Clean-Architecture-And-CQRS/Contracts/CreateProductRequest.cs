using System.ComponentModel.DataAnnotations;

namespace Clean_Architecture_And_CQRS.Contracts
{
    public record CreateProductRequest(
    [Required]
    [StringLength(100, MinimumLength = 2)]
    string Name,

    [Range(typeof(decimal), "0.01", "999999999")]
    decimal Price
);

    public record UpdateProductRequest(

    [Required]
    [StringLength(100, MinimumLength = 2)]
    string Name,

    [Range(typeof(decimal), "0.01", "999999999")]
    decimal Price
    );
}
