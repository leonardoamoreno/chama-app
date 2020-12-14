using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseSignUp.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> GetById(string id);
        Task<IEnumerable<TEntity>> GetAll();
        void Add(TEntity obj);
        void Update(TEntity obj);
        void Remove(string id);
        int SaveChanges();
        IUnitOfWork UnitOfWork { get; }
    }
}
