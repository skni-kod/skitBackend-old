using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Data;
using Data.Models;
using skitBackend.Data.Models.Dto;
using skitBackend.Exceptions;

namespace skitBackend.Services
{
    public interface ICompanyService
    {
        CompanyDto GetById(int id);
        //IEnumerable<CompanyDto> GetAll();
    }

    public class CompanyService : ICompanyService
    {
        private readonly ApiDbContext _dbContext;
        public readonly IMapper _mapper;

        public CompanyService(ApiDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public CompanyDto GetById(int id)
        {
            var particularCompanies = _dbContext.Companies
                .Include(company => company.Addresses)
                .Include(company => company.Technologies)
                .FirstOrDefault(company => company.Id == id);

            if (particularCompanies is null)
                throw new NotFoundException("Company not found");

            var result = _mapper.Map<CompanyDto>(particularCompanies);
            return result;
        }

        //public IEnumerable<CompanyDto> GetAll()
        //{
        //    var companyData = _dbContext.Companies
        //        .Include(c => c.Addresses)
        //        .Include(c => c.Technologies)
        //        .ToList();

        //    var companyDataDtos = _mapper.Map<List<CompanyDto>>(companyData);

        //    return companyDataDtos;
        //}
    }
}
