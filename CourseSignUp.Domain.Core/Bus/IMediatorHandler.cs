using System.Threading.Tasks;
using CourseSignUp.Domain.Core.Commands;
using CourseSignUp.Domain.Core.Events;
using FluentValidation.Results;

namespace CourseSignUp.Domain.Core.Bus
{
    public interface IMediatorHandler
    {        
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
