using System.ComponentModel.DataAnnotations;

namespace CoreApp.Data.Dtos;

public class CreateProjectDto
{
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }
    public string? Description { get; set; }
    [Required]
    public int SectionId { get; set; }
}