using CourseSignUp.Domain.Core.Events;

namespace CourseSignUp.Domain.Events.Course
{
    public class CourseRegisteredEvent : Event
    {
        public CourseRegisteredEvent(string id, int capacity, int numberOfStudents)
        {
            Id = id;
            Capacity = capacity;
            NumberOfStudents = numberOfStudents;
            AggregateId = id;
        }
        public string Id { get; set; }
        public int Capacity { get; set; }
        public int NumberOfStudents { get; set; }
    }
}