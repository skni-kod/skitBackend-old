using CoreApp.Data.Dtos;
using CoreApp.Data.Models;
using CoreApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoreApp.Controllers;
[Route("api/student")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _service;

    public StudentController(IStudentService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public ActionResult<ReadStudentDto> GetById([FromRoute] int id)
    {
        var student = _service.GetById(id);
        return Ok(student);
    }

    [HttpGet]
    public ActionResult<IEnumerable<ReadStudentDto>> GetAll()
    {
        var result = _service.GetAll();
        return Ok(result);
    }

    [HttpGet("noproject")]
    public ActionResult<List<ReadStudentDto>> GetAllNoProject()
    {
        var result = _service.GetAllNoProject();
        return Ok(result);
    }

    [HttpPost]
    public ActionResult CreateStudent([FromBody]CreateStudentDto dto)
    {
        var id = _service.Create(dto);
        return Created($"/api/student/{id}", null);
    }

    [HttpPost("{studentId}/project/{projectId}")]
    public ActionResult AddProjectToStudent([FromRoute] int studentId, [FromRoute] int projectId)
    {
        _service.AddProjectToStudent(studentId, projectId);
        return NoContent();
    }

    [HttpPost("{studentId}/role/{roleId}")]
    public ActionResult AddRoleToStudent([FromRoute] int studentId, [FromRoute] int roleId)
    {
        _service.AddRoleToStudent(studentId, roleId);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        _service.Delete(id);
        return NoContent();
    }
}