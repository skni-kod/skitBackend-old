using System.ComponentModel.DataAnnotations.Schema;

namespace ModelsDb;

public enum CompanySize
{
    small,
    medium,
    large
}

public enum CompanyWorkLocation
{
    bad,
    avarage,
    good
}

public class Company
{
    public int Id { get; set; }
    public string Name { get; set; }
    public CompanyWorkLocation WorkLocation { get; set; }
    public CompanySize Size { get; set; }
    public string Links { get; set; }
    public List<Comment> Comments { get; set; } 
    public List<Address> Addresses { get; set; }  
    public List<CompanyTechnology> CompanyTechnologies { get; set; }

}