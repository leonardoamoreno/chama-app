using AutoMapper;
using CourseSignUp.Application.ViewModels;
using CourseSignUp.Domain.Models;

namespace CourseSignUp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Course, CourseViewModel>();
        }
    }
}
