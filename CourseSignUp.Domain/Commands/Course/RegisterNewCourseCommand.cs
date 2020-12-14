using CourseSignUp.Domain.Validations.Course;

namespace CourseSignUp.Domain.Commands.Course
{
    public class RegisterNewCourseCommand : CourseCommand
    {
        public RegisterNewCourseCommand(string id, int capacity, int numberOfStudents)
        {
            Id = id;
            Capacity = capacity;
            NumberOfStudents = numberOfStudents;

        }        

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewCourseCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}