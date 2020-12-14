using CourseSignUp.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseSignUp.Infra.Data.Mappings
{
    public class CourseMap : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(c => c.Id)
                .HasColumnName("Id")
                .IsRequired();
                
            builder.Property(c => c.Capacity)
                .HasColumnName("Capacity");

            builder.Property(c => c.NumberOfStudents)
                .HasColumnName("NumberOfStudents");

        }
    }
}
