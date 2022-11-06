namespace ModelsDb;

public class CompanyTechnology
{
    public int Id { get; set; }
    public int TechnologyId { get; set; }
    public Company Company { get; set; }
    public Technology Technology { get; set; }
}