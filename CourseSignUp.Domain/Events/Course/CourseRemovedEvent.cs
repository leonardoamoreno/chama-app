using System;
using CourseSignUp.Domain.Core.Events;

namespace CourseSignUp.Domain.Events.Course
{
    public class CourseRemovedEvent : Event
    {
        public CourseRemovedEvent(string id)
        {
            Id = id;
            AggregateId = id;
        }

        public string Id { get; set; }
    }
}