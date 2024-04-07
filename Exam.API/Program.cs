using Exam.Application;
using Exam.Persistence;
using Exam.Infrastructure;
using System.Reflection;
using Exam.API.Middlewares;
using Exam.Infrastructure.Filters;
using FluentValidation.AspNetCore;
using Exam.Application.Validators.Lessons;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

builder.Services.AddCors(options =>
    options.AddDefaultPolicy(policy =>
        policy
        .WithOrigins("http://localhost:4200", "https://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
));

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
