using CourseSignUp.Domain.Core.Models;

namespace CourseSignUp.Domain.Models
{
    public class Course : Entity
    {
        public Course()
        {

        }
        public Course(string id, int capacity, int numberOfStudents)
        {
            Id = id;
            Capacity = capacity;
            NumberOfStudents = numberOfStudents;

        }

        public string Id { get; set; }
        public int Capacity { get; set; }
        public int NumberOfStudents { get; set; }
    }
}
