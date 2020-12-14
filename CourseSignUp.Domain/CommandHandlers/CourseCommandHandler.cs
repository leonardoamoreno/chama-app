using System.Threading;
using System.Threading.Tasks;
using CourseSignUp.Domain.Commands.Course;
using CourseSignUp.Domain.Core.Bus;
using CourseSignUp.Domain.Core.Notifications;
using CourseSignUp.Domain.Events.Course;
using CourseSignUp.Domain.Interfaces;
using CourseSignUp.Domain.Models;
using FluentValidation.Results;
using MediatR;

namespace CourseSignUp.Domain.CommandHandlers
{
    public class CourseCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCourseCommand, ValidationResult>,
        IRequestHandler<UpdateCourseCommand, ValidationResult>,
        IRequestHandler<RemoveCourseCommand, ValidationResult>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMediatorHandler Bus;

        public CourseCommandHandler(ICourseRepository courseRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _courseRepository = courseRepository;
            Bus = bus;
        }

        public async Task<ValidationResult> Handle(RegisterNewCourseCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var course = new Course()
            {
                Id = request.Id,
                Capacity = request.Capacity,
                NumberOfStudents = request.NumberOfStudents
            };

            _courseRepository.Add(course);

            await Bus.RaiseEvent(new CourseRegisteredEvent(course.Id, course.Capacity, course.NumberOfStudents));

            return await Commit(_courseRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            var course = new Course(request.Id, request.Capacity, request.NumberOfStudents);

            _courseRepository.Update(course);

            await Bus.RaiseEvent(new CourseRegisteredEvent(request.Id, request.Capacity, request.NumberOfStudents));

            return await Commit(_courseRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveCourseCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;

            _courseRepository.Remove(request.Id);

            await Bus.RaiseEvent(new CourseRemovedEvent(request.Id));

            return await Commit(_courseRepository.UnitOfWork);
            
        }
        public void Dispose()
        {
            _courseRepository.Dispose();
        }
    }
}