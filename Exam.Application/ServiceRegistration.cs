using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Exam.Application;
public static class ServiceRegistration
{
    public static void AddApplicationServices(this IServiceCollection collection)
    {
        collection.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        collection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        AddFluentValidation(collection);

        // API-ın default formada error mesajı verməsini dayanır
        collection.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);
    }

    private static void AddFluentValidation(IServiceCollection collection)
    {
        collection.AddFluentValidationAutoValidation();
        collection.AddFluentValidationClientsideAdapters();
        collection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
