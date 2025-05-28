using Microsoft.OpenApi.Models;
using System.Reflection;

namespace CL.WebApi.Configuration;

public static class SwaggerConfig
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Loja do Manoel",
                    Version = "v1",
                    Description = "API da aplicação.",
                    Contact = new OpenApiContact
                    {
                        Name = "Breno fernandes",
                        Email = "brenofs1997@gmail.com",
                        Url = new Uri("https://github.com/brenofs1997")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "OSD",
                        Url = new Uri("https://opensource.org/osd")
                    },
                    TermsOfService = new Uri("https://opensource.org/osd")
                });

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Insira o token",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference= new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id ="Bearer"
                        }
                    },
                        Array.Empty<string>()
                    }
            });

        });
    }

    public static void UseSwaggerConfiguration(this IApplicationBuilder app)
    {
        app.UseSwagger();

        app.UseSwaggerUI(c =>
        {
            c.RoutePrefix = string.Empty;
            c.SwaggerEndpoint("./swagger/v1/swagger.json", "ManoelMarket V1");
        });
    }
}