using FluentValidation;
using CourseSignUp.Domain.Commands.Course;

namespace CourseSignUp.Domain.Validations.Course
{
    public abstract class CourseValidation<T> : AbstractValidator<T> where T : CourseCommand
    {
        protected void ValidateCapacity()
        {
            RuleFor(c => c.Capacity)
                .NotEmpty().WithMessage("Please ensure you have entered the Capacity");                
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(string.Empty);
        }    
    }
}
