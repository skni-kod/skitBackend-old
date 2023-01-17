using Data.Models;
using skitBackend.Data.Enums;

namespace skitBackend.Data.Models.Dto
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public CompanyWorkLocation WorkLocation { get; set; }
        public CompanySize Size { get; set; }
        public List<string>? Links { get; set; }
        public List<AddressDto>? Addresses { get; set; }
        public List<TechnologyDto>? Technologies { get; set; }

    }
}
