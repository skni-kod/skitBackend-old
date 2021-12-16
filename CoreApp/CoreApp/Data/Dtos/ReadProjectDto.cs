using CoreApp.Data.Models;

namespace CoreApp.Data.Dtos;

public class ReadProjectDto
{
    public string Title { get; set; }
    public string? Description { get; set; }
    public ReadSectionDto Section { get; set; }
}