namespace CoreApp.Data.Models;

public class ProjectParticipant
{
    public int Id { get; set; }

    public int StudentId { get; set; }
    public int ProjectId { get; set; }
    public virtual Student Student { get; set; }
    public virtual Project Project { get; set; }
}