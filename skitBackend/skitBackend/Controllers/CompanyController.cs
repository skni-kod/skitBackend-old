using Microsoft.AspNetCore.Mvc;
using Data.Models;
using skitBackend.Services;

namespace skitBackend.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class CompanyController : ControllerBase
    {
        //downloading resources from the db
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
               _companyService= companyService;
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<CompanyDto>> GetAll()
        //{
        //    var companyDataDtos = _companyService.GetAll();

        //    return Ok(companyDataDtos);
        //}

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Company>> GetSpecific([FromRoute]int id)
        {
            var particularCompanies = _companyService.GetById(id);

            return Ok(particularCompanies);
        }


    }
}
