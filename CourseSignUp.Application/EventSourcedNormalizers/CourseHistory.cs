using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using CourseSignUp.Domain.Core.Events;

namespace CourseSignUp.Application.EventSourcedNormalizers
{
    public static class CourseHistory
    {
        public static IList<CourseHistoryData> HistoryData { get; set; }

        public static IList<CourseHistoryData> ToJavaScriptCourseHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<CourseHistoryData>();
            CourseHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var list = new List<CourseHistoryData>();
            var last = new CourseHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new CourseHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Capacity = change.Capacity > 0 || change.Capacity == last.Capacity
                        ? 0
                        : change.Capacity,
                    NumberOfStudents = change.NumberOfStudents > 0 || change.NumberOfStudents == last.NumberOfStudents
                        ? 0
                        : change.NumberOfStudents,                   
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void CourseHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonSerializer.Deserialize<CourseHistoryData>(e.Data);
                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {
                    case "CourseRegisteredEvent":
                        historyData.Action = "Registered";
                        historyData.Who = e.User;
                        break;
                    case "CourseUpdatedEvent":
                        historyData.Action = "Updated";
                        historyData.Who = e.User;
                        break;
                    case "CourseRemovedEvent":
                        historyData.Action = "Removed";
                        historyData.Who = e.User;
                        break;
                    default:
                        historyData.Action = "Unrecognized";
                        historyData.Who = e.User ?? "Anonymous";
                        break;

                }
                HistoryData.Add(historyData);
            }
        }
    }
}