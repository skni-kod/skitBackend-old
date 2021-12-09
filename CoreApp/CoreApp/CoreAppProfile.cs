using AutoMapper;
using CoreApp.Data.Dtos;
using CoreApp.Data.Models;

namespace CoreApp;

public class CoreAppProfile : Profile
{
    public CoreAppProfile()
    {
        CreateMap<CreateStudentDto, Student>();

        CreateMap<Student, ReadStudentDto>();

        CreateMap<Role, ReadRoleDto>();

        CreateMap<CreateRoleDto, Role>();

        CreateMap<Section, ReadSectionDto>();

        CreateMap<CreateSectionDto, Section>();
    }
}