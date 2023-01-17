using Microsoft.EntityFrameworkCore.Metadata.Internal;
using skitBackend.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;

namespace Data.Models;

public class Company
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public CompanyWorkLocation WorkLocation { get; set; }
    public CompanySize Size { get; set; }
    [Column(TypeName = "jsonb")]
    public List<string>? Links { get; set; }
    public List<Comment>? Comments { get; set; } 
    public List<Address>? Addresses { get; set; }  
    public List<Technology>? Technologies { get; set; }

}