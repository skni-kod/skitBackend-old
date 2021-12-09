namespace CoreApp.Data.Models;

public class Project
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string? Description { get; set; }

    public int SectionId { get; set; }
    public virtual Section Section { get; set; }
    public virtual List<ProjectParticipant>? ProjectParticipant { get; set; }
}