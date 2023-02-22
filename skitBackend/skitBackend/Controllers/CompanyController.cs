using AutoMapper;
using Data;
using Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using skitBackend.Data.Models;
using skitBackend.Data.Models.Dto;
using skitBackend.Wrappers;

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
        public ActionResult<CompaniesGeneralData> GetGeneral([FromQuery] PaginationFilter filter)
        {

            var query = _dbContext.Companies
                .Include(c => c.Addresses)
                .Include(c => c.Technologies)
                .AsQueryable();
                
            filter.ItemsCount = query.Count();

            var records = query
                .Skip(filter.Offset)
                .Take(filter.PageSize)
                .ToList();

            var CompaniesGeneralDto = _mapper.Map<List<CompaniesGeneralDTO>>(records);

            CompaniesGeneralData result = new() 
            { 
                Pager = filter,
                Records = CompaniesGeneralDto
            };


            return Ok(result);
            
        }


    }
}
