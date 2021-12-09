using CoreApp.Data.Models;

namespace CoreApp.Data.Dtos;

public class ReadStudentDto
{
    public string Indeks { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DiscordName { get; set; }
    public int? YearOfStudies { get; set; }
    public string? StudiesTag { get; set; }
    public string? Description { get; set; }

    public int? RoleId { get; set; }
    public virtual List<Role>? Role { get; set; }
    public virtual List<ProjectParticipant>? ProjectParticipant { get; set; }
}