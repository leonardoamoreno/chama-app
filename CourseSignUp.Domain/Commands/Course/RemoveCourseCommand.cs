using CourseSignUp.Domain.Validations.Course;

namespace CourseSignUp.Domain.Commands.Course
{
    public class RemoveCourseCommand : CourseCommand
    {
        public RemoveCourseCommand(string id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveCourseCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}