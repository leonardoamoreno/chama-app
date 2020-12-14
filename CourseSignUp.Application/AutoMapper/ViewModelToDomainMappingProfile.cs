using AutoMapper;
using CourseSignUp.Application.ViewModels;
using CourseSignUp.Domain.Commands;
using CourseSignUp.Domain.Commands.Course;

namespace CourseSignUp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CourseViewModel, RegisterNewCourseCommand>()
                .ConstructUsing(c => new RegisterNewCourseCommand(c.Id, c.Capacity, c.NumberOfStudents));
            CreateMap<CourseViewModel, UpdateCourseCommand>()
                .ConstructUsing(c => new UpdateCourseCommand(c.Id, c.Capacity, c.NumberOfStudents));
        }
    }
}
