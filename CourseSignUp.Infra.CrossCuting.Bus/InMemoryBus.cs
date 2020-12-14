using CourseSignUp.Domain.Core.Bus;
using CourseSignUp.Domain.Core.Commands;
using CourseSignUp.Domain.Core.Events;
using FluentValidation.Results;
using MediatR;
using System.Threading.Tasks;

namespace CourseSignUp.Infra.CrossCuting.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IEventStore _eventStore;

        public InMemoryBus(IEventStore eventStore, IMediator mediator)
        {
            _eventStore = eventStore;
            _mediator = mediator;
        }

        public Task<ValidationResult> SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send<ValidationResult>(command);
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStore?.Save(@event);

            return _mediator.Publish(@event);
        }        
    }
}
