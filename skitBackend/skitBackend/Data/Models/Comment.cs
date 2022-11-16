namespace Data.Models;

public class Comment
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public int Rating { get; set; }
    public int CompanyId { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public Company? Company { get; set; }
}