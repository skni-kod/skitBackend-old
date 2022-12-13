using AutoMapper;
using Data.Models;
using skitBackend.Data.Models.Dto;

namespace skitBackend.Data.MappingProfiles
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<Company, CompanyDto>();
            CreateMap<Address, AddressDto>();
            CreateMap<Technology, TechnologyDto>();
            CreateMap<Company, CompaniesGeneralDTO>();
        }
    }
}
