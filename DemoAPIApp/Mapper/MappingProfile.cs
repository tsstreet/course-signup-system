namespace DemoAPIApp.Mapper;
using DemoAPIApp.Data.Model;
using AutoMapper;
using System;
using DemoAPIApp.Data.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ClassDto, Class>();
        CreateMap<SubjectDto, Subject>();
        CreateMap<ScheduleDto, Schedule>();
    }
}
