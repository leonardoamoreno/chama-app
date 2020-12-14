using System.Threading;
using System.Threading.Tasks;
using CourseSignUp.Domain.Events.Course;
using MediatR;

namespace CourseSignUp.Domain.EventHandlers
{
    public class CourseEventHandler :
        INotificationHandler<CourseRegisteredEvent>,
        INotificationHandler<CourseUpdatedEvent>,
        INotificationHandler<CourseRemovedEvent>
    {
        public Task Handle(CourseUpdatedEvent message, CancellationToken cancellationToken)
        {
            // dispara evento de Update

            return Task.CompletedTask;
        }

        public Task Handle(CourseRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Calcular as estatisticas a cada Signup registrado 

            return Task.CompletedTask;
        }

        public Task Handle(CourseRemovedEvent message, CancellationToken cancellationToken)
        {
            // Dispara evento de Remoção

            return Task.CompletedTask;
        }
    }
}