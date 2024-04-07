using Exam.Domain;
using Exam.Persistence.Contexts;
using Exam.Persistence.SeedData;

try
{
    ExamDataSeederContributor seederContributor = new();
    using (ExamDbContext context = new ExamDbContext())
    {
        Console.WriteLine("added data...");
        var response = DbInitializer.Initialize(context);
        Console.WriteLine("finish");
        Console.WriteLine(response);
    }
    Console.Read();
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}"); ;
}