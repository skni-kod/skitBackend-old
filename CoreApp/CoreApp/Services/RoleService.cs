using AutoMapper;
using CoreApp.Data;
using CoreApp.Data.Dtos;
using CoreApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.Services;
public interface IRoleService
{
    List<ReadRoleDto> GetAll();
    public ReadRoleDto GetById(int id);
    public void PutRole(int id, CreateRoleDto dto);
    public void PatchRole(int id, CreateRoleDto dto);
    public void Delete(int id);
    public int Create(CreateRoleDto dto);
    List<ReadStudentDto> GetAllStudents(int id);
}

public class RoleService : IRoleService
{
    private readonly CoreAppDbContext _context;
    private readonly IMapper _mapper;

    public RoleService(CoreAppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public List<ReadRoleDto> GetAll()
    {
        var roles = _context
            .Roles
            .ToList();
        
        if (roles == null) throw new Exception();

        var result = _mapper.Map<List<ReadRoleDto>>(roles);

        return result;
    }

    public void Delete(int id)
    {
        var role = _context
            .Roles
            .FirstOrDefault(r => r.Id == id);
        
        if (role == null) throw new Exception();

        _context.Roles.Remove(role);
        _context.SaveChanges();
    }

    public ReadRoleDto GetById(int id)
    {
        var role = _context
            .Roles
            .FirstOrDefault(r => r.Id == id);

        if (role == null) throw new Exception();

        var result = _mapper.Map<ReadRoleDto>(role);

        return result;
    }

    public int Create(CreateRoleDto dto)
    {
        var role = _mapper.Map<Role>(dto);

        _context
            .Roles
            .Add(role);
        _context.SaveChanges();

        return role.Id;
    }

    public List<ReadStudentDto> GetAllStudents(int id)
    {
        var role = _context
            .Roles
            .Include(r => r.Students)
            .FirstOrDefault(r => r.Id == id);

        if(role == null) throw new Exception();

        var students = role.Students.ToList();

        var result = _mapper.Map<List<ReadStudentDto>>(students);

        return result;
    }

    public void PutRole(int id, CreateRoleDto dto)
    {
        var role = _context
            .Roles
            .FirstOrDefault(r => r.Id == id);

        if (role == null) throw new Exception();

        _mapper.Map(dto, role);

        _context.SaveChanges();
    }

    public void PatchRole(int id, CreateRoleDto dto)
    {
        var role = _context
            .Roles
            .FirstOrDefault(r => r.Id == id);

        if (role == null) throw new Exception();

        _mapper.Map(dto, role);

        _context.SaveChanges();
    }
}

