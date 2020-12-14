using CourseSignUp.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Domain.Commands.Lecturer
{
    public abstract class LectureCommand : Command
    {
        public string Name { get; set; }
    }
}
