using AutoMapper;
using ProjectListHiumanLab.Domain.Dtos;
using ProjectListHiumanLab.Domain.Entities;

namespace ProjectListHiumanLab.Mappers;

public class AutoMapping : Profile
{
    public AutoMapping()
    {
        CreateMap<Project, ProjectDto>().ReverseMap();
        CreateMap<CreateProjectDto, Project>().ReverseMap();
        CreateMap<UpdateProjectDto, Project>()
            .ForMember(dest => dest.Id, src => src.Ignore())
            .ForMember(dest => dest.CreatedAt, src => src.Ignore())
            .ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
    }
}
