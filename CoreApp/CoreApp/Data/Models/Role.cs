namespace CoreApp.Data.Models;

public class Role
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }

    public virtual List<Student>? Students { get; set; }
}