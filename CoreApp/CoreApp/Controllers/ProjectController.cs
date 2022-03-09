using CoreApp.Data.Dtos;
using CoreApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers;
[Route("/api/project")]
[ApiController]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _service;

    public ProjectController(IProjectService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<List<ReadProjectDto>> GetAll()
    {
        var result = _service.GetAll();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public ActionResult<ReadProjectDto> GetById([FromRoute] int id)
    {
        var result = _service.GetById(id);
        return Ok(result);
    }

    [HttpGet("{id}/student")]
    public ActionResult<List<ReadProjectDto>> GetAllStudents([FromRoute] int id)
    {
        var result = _service.GetAllStudents(id);
        return Ok(result);
    }

    [HttpPut("{id}")]
    public ActionResult PutProject([FromRoute] int id, [FromBody] CreateProjectDto dto)
    {
        _service.PutProject(id, dto);
        return Ok();
    }

    [HttpPatch("{id}")]
    public ActionResult PatchProject([FromRoute] int id, [FromBody] CreateProjectDto dto)
    {
        _service.PatchProject(id, dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        _service.Delete(id);
        return NoContent();
    }

    [HttpPost]
    public ActionResult Create([FromBody] CreateProjectDto dto)
    {
        var id = _service.Create(dto);
        return Created($"/api/project/{id}", null);
    }
}