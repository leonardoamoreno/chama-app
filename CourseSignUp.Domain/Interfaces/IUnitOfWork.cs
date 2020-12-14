using System;
using System.Threading.Tasks;

namespace CourseSignUp.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
