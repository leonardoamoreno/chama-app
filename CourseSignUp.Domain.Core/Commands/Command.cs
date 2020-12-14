using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;
using CourseSignUp.Domain.Core.Events;
using MediatR;

namespace CourseSignUp.Domain.Core.Commands
{
    public abstract class Command : Message, IRequest<ValidationResult>, IBaseRequest
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
            ValidationResult = new ValidationResult();
        }

        public abstract bool IsValid();
    }
}
