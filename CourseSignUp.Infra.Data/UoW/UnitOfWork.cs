using CourseSignUp.Domain.Interfaces;
using CourseSignUp.Infra.Data.Context;
using System.Threading.Tasks;

namespace CourseSignUp.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ChamaContext _context;

        public UnitOfWork(ChamaContext context)
        {
            _context = context;
        }

        public async Task<bool> Commit()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
