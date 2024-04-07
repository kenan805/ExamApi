using Exam.Domain.Entites;
using Exam.Domain.Entites.Common;
using Exam.Domain.Entites.Common.Auditing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Persistence.Contexts;
public class ExamDbContext : DbContext
{
    public ExamDbContext(DbContextOptions<ExamDbContext> options) : base(options)
    { }

    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Domain.Entites.Exam> Exams { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries().ToList();

        entries.ForEach(e =>
        {
            if (e.Entity is IHasCreationTime creationTimeEntity && e.State == EntityState.Added)
                creationTimeEntity.CreationTime = DateTime.UtcNow;

            if (e.Entity is IHasModificationTime modificationTimeEntity && e.State == EntityState.Modified)
                modificationTimeEntity.LastModificationTime = DateTime.UtcNow;

            if (e.Entity is IHasDeletionTime deletionTimeEntity && e.State == EntityState.Deleted)
                deletionTimeEntity.DeletionTime = DateTime.UtcNow;
        });

        return base.SaveChangesAsync(cancellationToken);
    }
}
