using Exam.Persistence.Configurations.BaseConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Persistence.Configurations;

public class ExamConfiguration : IEntityTypeConfiguration<Domain.Entites.Exam>
{
    public void Configure(EntityTypeBuilder<Domain.Entites.Exam> builder)
    {
        builder.ConfigureByConvention();

        builder.Property(exam => exam.Date)
            .IsRequired();

        builder.Property(exam => exam.Grade)
            .IsRequired()
            .HasMaxLength(1);

        builder.HasKey(exam => new { exam.LessonId, exam.StudentId });

        builder
            .HasOne(exam => exam.Lesson)
            .WithMany(lesson => lesson.Exams)
            .HasForeignKey(exam => exam.LessonId);

        builder
            .HasOne(exam => exam.Student)
            .WithMany(student => student.Exams)
            .HasForeignKey(exam => exam.StudentId);
    }
}
