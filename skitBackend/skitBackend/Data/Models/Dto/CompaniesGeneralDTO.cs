using Data.Models;
using skitBackend.Data.Enums;

namespace skitBackend.Data.Models.Dto
{
    public class CompaniesGeneralDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public CompanyWorkLocation WorkLocation { get; set; }
        public List<AddressDto>? Addresses { get; set; }
        public List<TechnologyDto>? Technologies { get; set; }
    }
}
