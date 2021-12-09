using System.ComponentModel.DataAnnotations;

namespace CoreApp.Data.Dtos;

public class CreateRoleDto
{
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }
    public string? Description { get; set; }
}