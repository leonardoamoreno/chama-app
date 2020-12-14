using CourseSignUp.Application.Interfaces;
using CourseSignUp.Application.Services;
using CourseSignUp.Domain.CommandHandlers;
using CourseSignUp.Domain.Commands.Course;
using CourseSignUp.Domain.Core.Bus;
using CourseSignUp.Domain.Core.Events;
using CourseSignUp.Domain.Core.Notifications;
using CourseSignUp.Domain.EventHandlers;
using CourseSignUp.Domain.Events.Course;
using CourseSignUp.Domain.Interfaces;
using CourseSignUp.Infra.CrossCuting.Bus;
using CourseSignUp.Infra.Data.Context;
using CourseSignUp.Infra.Data.EventSourcing;
using CourseSignUp.Infra.Data.Repository.EventSourcing;
using CourseSignUp.Infra.Data.UoW;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace CourseSignUp.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<ICourseAppService, CourseAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CourseRegisteredEvent>, CourseEventHandler>();
            services.AddScoped<INotificationHandler<CourseUpdatedEvent>, CourseEventHandler>();
            services.AddScoped<INotificationHandler<CourseRemovedEvent>, CourseEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCourseCommand, ValidationResult>, CourseCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCourseCommand, ValidationResult>, CourseCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCourseCommand, ValidationResult>, CourseCommandHandler>();

            // Infra - Data
            services.AddScoped<ICourseRepository, Data.Repository.CourseRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ChamaContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();
        }
    }
}
