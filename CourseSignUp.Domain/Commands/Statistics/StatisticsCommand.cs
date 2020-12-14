using CourseSignUp.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Domain.Commands.Statistics
{
    public abstract class StatisticsCommand : Command
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }
        public decimal AverageAge { get; set; }
    }
}
