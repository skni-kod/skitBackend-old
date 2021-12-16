using AutoMapper;
using CoreApp.Data;
using CoreApp.Data.Dtos;
using CoreApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.Services;
public interface IProjectService
{
    List<ReadProjectDto> GetAll();
    public ReadProjectDto GetById(int id);
    public void Delete(int id);
    public int Create(CreateProjectDto dto);
    List<ReadStudentDto> GetAllStudents(int id);
}

public class ProjectService : IProjectService
{
    private readonly CoreAppDbContext _context;
    private readonly IMapper _mapper;

    public ProjectService(CoreAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public List<ReadProjectDto> GetAll()
    {
        var projects = _context
            .Projects
            .Include(p => p.Section)
            .ToList();

        if (projects == null) throw new Exception();

        var result = _mapper.Map<List<ReadProjectDto>>(projects);

        return result;
    }

    public void Delete(int id)
    {
        var project = _context
            .Projects
            .FirstOrDefault(r => r.Id == id);

        if (project == null) throw new Exception();

        _context.Projects.Remove(project);
        _context.SaveChanges();
    }

    public ReadProjectDto GetById(int id)
    {
        var project = _context
            .Projects
            .Include(p => p.Section)
            .FirstOrDefault(r => r.Id == id);

        if (project == null) throw new Exception();

        var result = _mapper.Map<ReadProjectDto>(project);

        return result;
    }

    public int Create(CreateProjectDto dto)
    {
        var project = _mapper.Map<Project>(dto);

        var section = _context
            .Sections
            .FirstOrDefault(s => s.Id == project.SectionId);

        if(section == null) throw new Exception();

        project.Section = section;

        _context
            .Projects
            .Add(project);
        _context.SaveChanges();

        return project.Id;
    }

    public List<ReadStudentDto> GetAllStudents(int id)
    {
        var project = _context
            .Projects
            .Include(p => p.Students)
            .FirstOrDefault(p => p.Id == id);

        if(project == null) throw new Exception();

        var students = project.Students.ToList();

        var result = _mapper.Map<List<ReadStudentDto>>(students);

        return result;
    }
}
