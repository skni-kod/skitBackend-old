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

    [HttpPut("{id}")]
    public ActionResult PutStudent([FromRoute] int id, [FromBody]CreateStudentDto dto)
    {
        _service.PutStudent(id, dto);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete([FromRoute] int id)
    {
        _service.Delete(id);
        return NoContent();
    }

    [HttpDelete("{studentId}/role/{projectId}")]
    public ActionResult DeleteProjectFromStudent([FromRoute] int studentId, [FromRoute] int projectId)
    {
        _service.DeleteProjectFromStudent(studentId, projectId);
        return NoContent();
    }

    [HttpDelete("{studentId}/project/{roleId}")]
    public ActionResult DeleteRoleFromStudent([FromRoute] int studentId, [FromRoute] int roleId)
    {
        _service.DeleteRoleFromStudent(studentId, roleId);
        return NoContent();
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
}