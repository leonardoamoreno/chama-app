using CourseSignUp.Domain.Commands.Course;

namespace CourseSignUp.Domain.Validations.Course
{
    public class UpdateCourseCommandValidation : CourseValidation<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidation()
        {
            ValidateId();
            ValidateCapacity();
        }
    }
}