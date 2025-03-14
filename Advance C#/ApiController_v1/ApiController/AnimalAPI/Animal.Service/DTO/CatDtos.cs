using System.ComponentModel.DataAnnotations;

namespace Animal.Service.DTO
{
    public record CatDisplayDto(Guid Id, string Name, string Color);
    public record AddCatDto([Required] string Name, [Range(0, 50)] int Age, [Required] string Color);
    public record UpdateCatDto([Required] string Name, [Range(0, 50)] int Age, [Required] string Color);
}
