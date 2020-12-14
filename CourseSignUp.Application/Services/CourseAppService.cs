using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CourseSignUp.Application.EventSourcedNormalizers;
using CourseSignUp.Application.Interfaces;
using CourseSignUp.Application.ViewModels;
using CourseSignUp.Domain.Commands;
using CourseSignUp.Domain.Commands.Course;
using CourseSignUp.Domain.Core.Bus;
using CourseSignUp.Domain.Interfaces;
using CourseSignUp.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results;

namespace CourseSignUp.Application.Services
{
    public class CourseAppService : ICourseAppService
    {
        private readonly IMapper _mapper;
        private readonly ICourseRepository _courseRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public CourseAppService(IMapper mapper,
                                  ICourseRepository courseRepository,
                                  IMediatorHandler mediator,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _courseRepository = courseRepository;
            _mediator = mediator;
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task<IEnumerable<CourseViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<CourseViewModel>>(await _courseRepository.GetAll());
        }

        public async Task<CourseViewModel> GetById(string id)
        {
            return _mapper.Map<CourseViewModel>(await _courseRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(CourseViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCourseCommand>(customerViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(CourseViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateCourseCommand>(customerViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Remove(string id)
        {
            var removeCommand = new RemoveCourseCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<IList<CourseHistoryData>> GetAllHistory(string id)
        {
            return CourseHistory.ToJavaScriptCourseHistory(await _eventStoreRepository.All(id));
        }
        public Task<ValidationResult> Signup(SignupViewModel signupViewModel)
        {
            var ValidationResult = new ValidationResult();
            // Verifica a capacidade com o numero de inscritos e retorna o ValidationResult 
            // Após a inscrição as estatisticas são atualizadas 
            // com a chamada de uma lambda functions atualizando a entidade de estatisticas

            return Task.FromResult(ValidationResult);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
