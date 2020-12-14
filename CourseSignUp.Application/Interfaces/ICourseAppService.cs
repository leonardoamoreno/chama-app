using CourseSignUp.Application.EventSourcedNormalizers;
using CourseSignUp.Application.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CourseSignUp.Application.Interfaces
{
    public interface ICourseAppService : IDisposable
    {
        Task<IEnumerable<CourseViewModel>> GetAll();
        Task<CourseViewModel> GetById(string id);

        Task<ValidationResult> Signup(SignupViewModel courseViewModel);
        Task<ValidationResult> Register(CourseViewModel courseViewModel);
        Task<ValidationResult> Update(CourseViewModel courseViewModel);
        Task<ValidationResult> Remove(string id);

        Task<IList<CourseHistoryData>> GetAllHistory(string id);
    }
}
