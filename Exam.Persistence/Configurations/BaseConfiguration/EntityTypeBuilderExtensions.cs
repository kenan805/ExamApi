using Exam.Domain.Entites.Common;
using Exam.Domain.Entites.Common.Auditing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Persistence.Configurations.BaseConfiguration;
public static class EntityTypeBuilderExtensions
{
    public static void ConfigureByConvention(this EntityTypeBuilder builder)
    {
        builder.TryConfigureSoftDelete();
        builder.TryConfigureDeletionTime();
        builder.TryConfigureCreationTime();
        builder.TryConfigureLastModificationTime();
    }

    private static void TryConfigureSoftDelete(this EntityTypeBuilder builder)
    {
        if (builder.Metadata.ClrType.IsAssignableTo(typeof(ISoftDelete)))
        {
            builder.Property(nameof(ISoftDelete.IsDeleted))
                .IsRequired()
                .HasDefaultValue(false)
                .HasColumnName(nameof(ISoftDelete.IsDeleted));
        }
    }

    private static void TryConfigureCreationTime(this EntityTypeBuilder builder)
    {
        if (builder.Metadata.ClrType.IsAssignableTo(typeof(IHasCreationTime)))
        {
            builder.Property(nameof(IHasCreationTime.CreationTime))
                .IsRequired()
                .HasColumnName(nameof(IHasCreationTime.CreationTime));
        }
    }

    private static void TryConfigureLastModificationTime(this EntityTypeBuilder builder)
    {
        if (builder.Metadata.ClrType.IsAssignableTo(typeof(IHasModificationTime)))
        {
            builder.Property(nameof(IHasModificationTime.LastModificationTime))
                .IsRequired(false)
                .HasColumnName(nameof(IHasModificationTime.LastModificationTime));
        }
    }

    private static void TryConfigureDeletionTime(this EntityTypeBuilder builder)
    {
        if (builder.Metadata.ClrType.IsAssignableTo(typeof(IHasDeletionTime)))
        {
            builder.TryConfigureSoftDelete();

            builder.Property(nameof(IHasDeletionTime.DeletionTime))
                .IsRequired(false)
                .HasColumnName(nameof(IHasDeletionTime.DeletionTime));
        }
    }
}
