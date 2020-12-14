using CourseSignUp.Domain.Commands.Course;

namespace CourseSignUp.Domain.Validations.Course
{
    public class RegisterNewCourseCommandValidation : CourseValidation<RegisterNewCourseCommand>
    {
        public RegisterNewCourseCommandValidation()
        {
            ValidateCapacity();
        }
    }
}