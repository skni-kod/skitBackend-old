using skitBackend.Data.Models.Dto;
using skitBackend.Wrappers;

namespace skitBackend.Data.Models
{
    public class CompaniesGeneralData 
    {
        public PaginationFilter Pager { get; set; } 
        public List<CompaniesGeneralDTO> Records { get; set; }
    }
}
