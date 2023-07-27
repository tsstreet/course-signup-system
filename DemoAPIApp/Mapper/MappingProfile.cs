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
        CreateMap<DepartmentDto, Department>();
        CreateMap<AcademicYearDto, AcademicYear>();
        CreateMap<FalcutyDto, Falcuty>();
        CreateMap<StudentDto, Student>();
        CreateMap<Student, StudentDto>();
        CreateMap<TeacherDto, Teacher>();
    }
}
