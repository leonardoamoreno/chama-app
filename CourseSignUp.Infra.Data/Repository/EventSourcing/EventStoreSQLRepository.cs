using System;
using System.Linq;
using System.Collections.Generic;
using CourseSignUp.Infra.Data.Context;
using CourseSignUp.Domain.Core.Events;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CourseSignUp.Infra.Data.Repository.EventSourcing
{
    public class EventStoreSQLRepository : IEventStoreRepository
    {
        private readonly EventStoreSQLContext _context;

        public EventStoreSQLRepository(EventStoreSQLContext context)
        {
            _context = context;
        }

        public async Task<IList<StoredEvent>> All(string aggregateId)
        {
            return await (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToListAsync();
        }

        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}