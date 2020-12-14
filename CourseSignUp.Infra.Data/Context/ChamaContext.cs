using CourseSignUp.Domain.Models;
using CourseSignUp.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Hosting;

namespace CourseSignUp.Infra.Data.Context
{
    [DbContext(typeof(ChamaContext))]
    public class ChamaContext : DbContext
    {
        private readonly IHostingEnvironment _env;

        public ChamaContext(IHostingEnvironment env)
        {
            _env = env;
        }

        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CourseMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //// get the configuration from the app settings
            //var config = new ConfigurationBuilder()
            //    .SetBasePath(_env.ContentRootPath)
            //    .AddJsonFile("appsettings.json")
            //    .Build();

            //// define the database to use
            //optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            optionsBuilder.UseSqlServer("Server=chamaapp.database.windows.net;Database=Chama;User Id=chama;Password=Leo@951#xyz!;");
        }
    }
}
