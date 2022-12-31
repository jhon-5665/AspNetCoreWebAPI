using AutoMapper;
using SmartSchool.WebAPI.V1.Dtos;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.Helpers;

namespace SmartSchool.WebAPI.V1.Profiles
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name} {src.Surname}"))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.BirthDate.GetCurrentAge()));

            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentRegisterDto>().ReverseMap();

            CreateMap<Teacher, TeacherDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Name} {src.Surname}"));

            CreateMap<TeacherDto, Teacher>();
            CreateMap<Teacher, TeacherRegisterDto>().ReverseMap();            
        }
    }
}