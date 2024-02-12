using System.ComponentModel.DataAnnotations;

namespace Bardi_demo_project.Models.RequestDto;

public class RegisterEmployeeDto
{
    [Required]
    [MinLength(4, ErrorMessage = "Username must be at least 4 characters long.")]
    public string Name { get; set; }
    
    public int IdentificationNumber { get; set; }
    
    [Required]
    public IFormFile Image { get; set; }
}