namespace CourseSignUp.Application.EventSourcedNormalizers
{
    public class CourseHistoryData
    {
        public string Action { get; set; }
        public string Id { get; set; }
        public int Capacity { get; set; }
        public int NumberOfStudents { get; set; }
        public string Timestamp { get; set; }  
        public string Who { get; set; }

    }
}