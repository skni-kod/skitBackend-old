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
            .FirstOrDefault(r => r.Id == id);

        if (project == null) throw new Exception();

        var result = _mapper.Map<ReadProjectDto>(project);

        return result;
    }

    public int Create(CreateProjectDto dto)
    {
        var project = _mapper.Map<Project>(dto);

        _context
            .Projects
            .Add(project);
        _context.SaveChanges();

        return project.Id;
    }

    public List<ReadStudentDto> GetAllStudents(int id)
    {
        throw new NotImplementedException();
    }
}
