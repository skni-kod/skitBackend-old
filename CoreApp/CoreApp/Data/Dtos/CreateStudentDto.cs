using System.ComponentModel.DataAnnotations;

namespace CoreApp.Data.Dtos;

public class CreateStudentDto
{
    [Required]
    [MaxLength(255)]
    public string Indeks { get; set; }
    [Required]
    [MaxLength(255)]
    public string FirstName { get; set; }
    [Required]
    [MaxLength(255)]
    public string LastName { get; set; }
    [Required]
    [MaxLength(255)]
    public string DiscordName { get; set; }
    public int? YearOfStudies { get; set; }
    public string? StudiesTag { get; set; }
    public string? Description { get; set; }
    public int? RoleId { get; set; }
}