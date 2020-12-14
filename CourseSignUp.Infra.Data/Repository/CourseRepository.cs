using CourseSignUp.Domain.Interfaces;
using CourseSignUp.Domain.Models;
using CourseSignUp.Infra.Data.Context;

namespace CourseSignUp.Infra.Data.Repository
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(ChamaContext context) : base(context)
        {
        }
    }
}
