namespace ModelsDb;

public class Technology
{
    public int Id { get; set; }
    public string Name { get; set; }
    List<CompanyTechnology> CompanyTechnologies { get; set; }
}