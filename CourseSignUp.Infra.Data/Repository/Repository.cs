using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using CourseSignUp.Domain.Interfaces;
using CourseSignUp.Infra.Data.Context;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CourseSignUp.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ChamaContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public IUnitOfWork UnitOfWork => null;

        public Repository(ChamaContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }
                
        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public virtual async Task<TEntity> GetById(string id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        public virtual void Remove(string id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
