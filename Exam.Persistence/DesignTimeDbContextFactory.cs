using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exam.Persistence.Contexts;

namespace Exam.Persistence;
public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ExamDbContext>
{
    public ExamDbContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        DbContextOptionsBuilder<ExamDbContext> dbContextOptionsBuilder = new();
        var connectionString = configuration.GetConnectionString("SqlServer");

        dbContextOptionsBuilder.UseSqlServer(connectionString);
        return new(dbContextOptionsBuilder.Options);
    }
}