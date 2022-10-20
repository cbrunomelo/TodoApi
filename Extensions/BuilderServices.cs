using System.Reflection;
using Microsoft.OpenApi.Models;
using TodoAPi.Data;
using TodoAPi.Repositories;
using TodoAPi.Repositories.Contracts;

namespace TodoAPi.Externsions;


public static class DependenciesExtension
{


    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddDbContext<TodoAPiDataContext>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ITodoRepository, TodoRepository>();
    }

    public static void AddSwagger(this IServiceCollection services)
    {

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(
            (c =>
                    {
                        c.SwaggerDoc("v1", new OpenApiInfo
                        {
                            Version = "v1",
                            Title = "Tarefas do usuário",
                            Description = "Link da modelagem de dados",
                            TermsOfService = new Uri("https://example.com/terms")
                        });


                        var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                        var xmlApiPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                        c.IncludeXmlComments(xmlApiPath);

                        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme 
                        {
                            In=ParameterLocation.Header,
                            Description="Insert Token Here !",
                            Name="Authorization",
                            Type=SecuritySchemeType.Http,
                            BearerFormat="JWT",
                            Scheme="bearer"
                        });
                        c.AddSecurityRequirement(new OpenApiSecurityRequirement
                        {
                                {
                                    new OpenApiSecurityScheme{
                                        Reference = new OpenApiReference
                                        {
                                            Type=ReferenceType.SecurityScheme,
                                            Id="Bearer"
                                        }
                                    },
                                        new string[]{}
                                }


                        });
                    })
                    
                    
                    );
    }


}