using AutoMapper;
using CoreApp.Data;
using CoreApp.Data.Dtos;
using CoreApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.Services;

public interface IStudentService
{
    public int Create(CreateStudentDto dto);
    public ReadStudentDto GetById(int id);
    public IEnumerable<ReadStudentDto> GetAll();
    void Delete(int id);
    List<ReadStudentDto> GetAllNoProject();
    void AddProjectToStudent(int studentId, int projectId);
    void AddRoleToStudent(int studentId, int roleId);
}

public class StudentService : IStudentService
{
    private readonly CoreAppDbContext _context;
    private readonly IMapper _mapper;

    public StudentService(CoreAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public int Create(CreateStudentDto dto)
    {
        var student = _mapper.Map<Student>(dto);
        _context.Students.Add(student);
        _context.SaveChanges();

        return student.Id;
    }

    public ReadStudentDto GetById(int id)
    {
        var student = _context
            .Students
            //.Include(r => r.Role)
            //.Include(r => r.Projects)
            .FirstOrDefault(s => s.Id == id);

        if (student == null) throw new Exception();

        var result = _mapper.Map<ReadStudentDto>(student);
        return result;
    }

    public IEnumerable<ReadStudentDto> GetAll()
    {
        var students = _context
            .Students
            //.Include(r => r.Role)
            //.Include(r => r.Projects)
            .ToList();

        var result = _mapper.Map<IEnumerable<ReadStudentDto>>(students);
        return result;
    }

    public void Delete(int id)
    {
        var student = _context
            .Students
            .FirstOrDefault(s => s.Id == id);

        if (student == null) throw new Exception();

        _context.Students.Remove(student);
        _context.SaveChanges();
    }

    public List<ReadStudentDto> GetAllNoProject()
    {
        var students = _context
            .Students
            .Where(s => s.Projects == null)
            .ToList();

        var result = _mapper.Map<List<ReadStudentDto>>(students);

        return result;
    }

    public void AddProjectToStudent(int studentId, int projectId)
    {
        var student = _context
            .Students
            .FirstOrDefault(s => s.Id == studentId);

        if(student == null) throw new Exception();

        var project = _context
            .Projects
            .FirstOrDefault(p => p.Id == projectId);

        if (project == null) throw new Exception();

        student.Projects.Add(project);

        _context.SaveChanges();
    }

    public void AddRoleToStudent(int studentId, int roleId)
    {
        var student = _context
            .Students
            .FirstOrDefault(s => s.Id == studentId);

        if (student == null) throw new Exception();

        var role = _context
            .Roles
            .FirstOrDefault(r => r.Id == roleId);

        if (role == null) throw new Exception();

        student.Roles.Add(role);

        _context.SaveChanges();
    }
}