using Exam.Domain.Entites;
using Exam.Persistence.Configurations.BaseConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Persistence.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ConfigureByConvention();

        builder.HasKey(x => x.Id);

        builder
            .HasIndex(x => x.No)
            .IsUnique();

        builder.Property(student => student.No)
            .IsRequired()
            .HasMaxLength(5);

        builder.Property(student => student.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(student => student.Surname)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(student => student.Class)
            .IsRequired()
            .HasMaxLength(2);
    }
}