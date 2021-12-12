namespace CoreApp.Data.Models;

public class Student
{
    public int Id { get; set; }
    public string Indeks { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string DiscordName { get; set; }
    public int? YearOfStudies { get; set; }
    public string? StudiesTag { get; set; }
    public string? Description { get; set; }

    public virtual List<Role>? Roles { get; set; }
    public virtual List<Project>? Projects { get; set; }
}