using System.ComponentModel.DataAnnotations;

namespace Bardi_demo_project.Models.RequestDto;

public class LoginEmployeeDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public int IdentificationNumber { get; set; }
    
    [Required]
    public IFormFile Image { get; set; }
}