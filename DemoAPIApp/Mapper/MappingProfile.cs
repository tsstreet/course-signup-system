namespace DemoAPIApp.Mapper;
using DemoAPIApp.Data.Model;
using AutoMapper;
using System;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ClassDto, Class>();
    }
}
