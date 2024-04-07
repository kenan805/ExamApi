using Exam.Domain.Entites;
using Exam.Persistence.Configurations.BaseConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Persistence.Configurations;
public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        builder.ConfigureByConvention();

        builder.HasKey(x => x.Id);

        builder
            .HasIndex(x => x.Code)
            .IsUnique();

        builder.Property(lesson => lesson.Code)
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(lesson => lesson.Name)
            .IsRequired()
            .HasMaxLength(30);

        builder.Property(lesson => lesson.Class)
            .IsRequired()
            .HasMaxLength(2);

        builder.Property(lesson => lesson.TeacherName)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(lesson => lesson.TeacherSurname)
            .IsRequired()
            .HasMaxLength(20);
    }
}