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

        [HttpGet]
        public ActionResult<IEnumerable<Company>> GetGeneral()
        {
            var CompaniesGeneral = _dbContext.Companies
                .Include(c => c.Addresses)
                .Include(c => c.Technologies)
                .ToList();

            
            var CompaniesGeneralDto = _mapper.Map<List<CompaniesGeneralDTO>>(CompaniesGeneral);

            return Ok(CompaniesGeneralDto);
        }


    }
}
