using CourseSignUp.Domain.Commands.Course;

namespace CourseSignUp.Domain.Validations.Course
{
    public class RemoveCourseCommandValidation : CourseValidation<RemoveCourseCommand>
    {
        public RemoveCourseCommandValidation()
        {
            ValidateId();
        }
    }
}