using AutoMapper;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skitBackend.Data.Models.Dto;

namespace skitBackend.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class CompanyController : ControllerBase
    {
        //downloading resources from the db
        private readonly ApiDbContext _dbContext;
        private readonly IMapper _mapper;

        public CompanyController(ApiDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

/*        [HttpGet]
        public ActionResult<IEnumerable<CompanyDto>> GetAll()
        {
            var companyData = _dbContext.Companies
                .Include(c => c.Addresses)
                .Include(c => c.Technologies)
                .ToList();

            var companyDataDtos = _mapper.Map<List<CompanyDto>>(companyData);

            return Ok(companyDataDtos);
        }*/

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Company>> GetSpecific([FromRoute]int id)
        {
            var particularCompanies = _dbContext.Companies
                .Include(c => c.Addresses)
                .Include(c => c.Technologies)
                .FirstOrDefault(company => company.Id == id);
            
            if(particularCompanies is null) 
            { 
                return NotFound(); 
            }

            var particularCompaniesDto = _mapper.Map<CompanyDto>(particularCompanies);

            return Ok(particularCompaniesDto);
        }


    }
}
