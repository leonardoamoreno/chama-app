using CourseSignUp.Domain.Core.Bus;
using CourseSignUp.Domain.Core.Commands;
using CourseSignUp.Domain.Core.Notifications;
using CourseSignUp.Domain.Interfaces;
using FluentValidation.Results;
using MediatR;
using System.Threading.Tasks;

namespace CourseSignUp.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;
        private ValidationResult ValidationResult;

        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _uow = uow;
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
            ValidationResult = new ValidationResult();
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        public async Task<ValidationResult> Commit(IUnitOfWork uow, string message)
        {
            if (!await _uow.Commit()) AddError(message);

            return ValidationResult;
        }

        public async Task<ValidationResult> Commit(IUnitOfWork uow)
        {
            return await Commit(uow, "There was an error saving data").ConfigureAwait(false);
        }

        public void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }
    }
}