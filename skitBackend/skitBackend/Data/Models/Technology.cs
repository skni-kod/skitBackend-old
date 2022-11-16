namespace Data.Models;

public class Technology
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Company>? Companies { get; set; }
}