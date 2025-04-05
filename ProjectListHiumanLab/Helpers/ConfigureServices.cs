using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProjectListHiumanLab.Behaviors;
using ProjectListHiumanLab.Domain.Dtos;
using ProjectListHiumanLab.Infrastructure.Data;
using ProjectListHiumanLab.Validators;

namespace Sendola.Core.Black.Helpers;

public static class ConfigureServices
{
    public static IServiceCollection AddDependency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ProjectContext>(options => options.UseInMemoryDatabase("ProjectList"));
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddHttpContextAccessor();

        return services;
    }
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddControllers().ConfigureApiBehaviorOptions(BehaviorBadRequest.ParseModelErrors);
        //Swagger
        services.AddSwaggerGen(c =>
        {
            c.IncludeXmlComments(XmlCommentsFilePath);
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Projects API", Version = "v1" });
        });

        return services;
    }

    static string XmlCommentsFilePath
    {
        get
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            return xmlPath;
        }
    }

    public static void AddFluentValidationsExtension(this IServiceCollection services)
    {
        services.AddFluentValidationRulesToSwagger();
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = false;
        });
    }
}