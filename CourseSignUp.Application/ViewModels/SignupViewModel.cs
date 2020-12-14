using System;
using System.Collections.Generic;
using System.Text;

namespace CourseSignUp.Application.ViewModels
{
    public class SignupViewModel
    {
        public string CourseId { get; set; }
        public StudentDto Student { get; set; }

        public class StudentDto
        {
            public string Email { get; set; }
            public string Name { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
    }
}
