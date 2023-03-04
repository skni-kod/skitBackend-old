using Microsoft.AspNetCore.Mvc;
using Data.Models;
using skitBackend.Services;
using Microsoft.AspNetCore.Authorization;

namespace skitBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
               _companyService= companyService;
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Company>> GetSpecific([FromRoute]int id)
        {
            var result = _companyService.GetById(id);

            return Ok(result);
        }
    }
}
