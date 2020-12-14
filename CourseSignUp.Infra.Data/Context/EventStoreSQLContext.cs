using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using CourseSignUp.Domain.Core.Events;
using CourseRepository.Infra.Data.Mappings;

namespace CourseSignUp.Infra.Data.Context
{
    public class EventStoreSQLContext : DbContext
    {
        public DbSet<StoredEvent> StoredEvent { get; set; }
        private readonly IHostingEnvironment _env;

        public EventStoreSQLContext(IHostingEnvironment env)
        {
            _env = env;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            // define the database to use
            optionsBuilder.UseSqlServer("Server=chamaapp.database.windows.net;Database=Chama;User Id=chama;Password=Leo@951#xyz!;");
        }
    }
}