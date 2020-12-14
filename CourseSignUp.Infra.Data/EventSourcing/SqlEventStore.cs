using Newtonsoft.Json;
using CourseSignUp.Domain.Core.Events;
using CourseSignUp.Infra.Data.Repository.EventSourcing;

namespace CourseSignUp.Infra.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;            
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                "SysAdmin");

            _eventStoreRepository.Store(storedEvent);
        }
    }
}