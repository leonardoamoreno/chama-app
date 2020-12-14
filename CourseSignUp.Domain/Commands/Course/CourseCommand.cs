using CourseSignUp.Domain.Core.Commands;

namespace CourseSignUp.Domain.Commands.Course
{
    public abstract class CourseCommand : Command
    {
        public string Id { get; set; }
        public int Capacity { get; set; }
        public int NumberOfStudents { get; set; }
    }
}
