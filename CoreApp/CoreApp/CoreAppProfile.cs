using AutoMapper;
using CoreApp.Data.Dtos;
using CoreApp.Data.Models;

namespace CoreApp;

public class CoreAppProfile : Profile
{
    public CoreAppProfile()
    {
        CreateMap<CreateStudentDto, Student>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != srcMember));

        CreateMap<Student, ReadStudentDto>();

        CreateMap<Role, ReadRoleDto>();

        CreateMap<CreateRoleDto, Role>()
            .ForAllMembers(opts=>opts.Condition((src, dest, srcMember)=> srcMember != srcMember));

        CreateMap<Section, ReadSectionDto>();

        CreateMap<CreateSectionDto, Section>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != srcMember));

        CreateMap<Project, ReadProjectDto>();

        CreateMap<CreateProjectDto, Project>();
    }
}