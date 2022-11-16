namespace Data.Models;
public class Address
{
    public int Id { get; set; }
    public string? City { get; set; }
    public string? RegisteredAddress { get; set; }
    public int CompanyId { get; set; }
    public Company? Company { get; set; }

}