using CourseSignUp.Domain.Validations.Course;

namespace CourseSignUp.Domain.Commands.Course
{
    public class UpdateCourseCommand : CourseCommand
    {

        public UpdateCourseCommand(string id, int capacity, int numberOfStudents)
        {
            Id = id;
            Capacity = capacity;
            NumberOfStudents = numberOfStudents;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCourseCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}