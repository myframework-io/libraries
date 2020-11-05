using Myframework.Libraries.Application.Configurations.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Myframework.Libraries.Application.Configurations
{
    /// <summary>
    /// Extensões do IServiceCollection para configurações de documentação da API.
    /// </summary>
    public static class DocumentationConfigurations
    {
        /// <summary>
        /// Adiciona o gerador do swagger ao ASP.NET.
        /// </summary>
        /// <param name="services"></param>
        /// <param name="xmlAPIFileName">Nome do arquivo XML usado na documentação.</param>
        /// <param name="info">Informações da publicação da documentação.</param>
        /// <param name="uriFriendlyName">Versão da documentação. Padrão: v1.</param>
        /// <param name="useCustomSchemaIdsFullName">Adiciona a opção "options.CustomSchemaIds(it => it.FullName)" ao swagger.</param>
        /// <returns></returns>
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services, string xmlAPIFileName, OpenApiInfo info, string uriFriendlyName = "v1", bool useCustomSchemaIdsFullName = true) =>
            services.AddSwaggerGen(options =>
            {
                if (useCustomSchemaIdsFullName)
                    options.CustomSchemaIds(it => it.FullName);

                options.SwaggerDoc(uriFriendlyName, info);

                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlAPIFileName));

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme { Scheme = "Bearer", In = ParameterLocation.Header, Description = "Please enter JWT with Bearer into field", Name = "Authorization", Type = SecuritySchemeType.ApiKey });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

                options.SchemaFilter<SwaggerIgnoreBaseCommandPropertiesSchemaFilter>();
            });

        /// <summary>
        /// Adiciona o swagger para a aplicação.
        /// </summary>
        /// <param name="app"></param>
        /// <param name="swaggerEndpointName"></param>
        /// <param name="swaggerEndpointUrl"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwagger(this IApplicationBuilder app, string swaggerEndpointName, string swaggerEndpointUrl = "/swagger/v1/swagger.json")
        {
            app
            .UseSwagger()
            .UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(swaggerEndpointUrl, swaggerEndpointName);
                options.DefaultModelsExpandDepth(-1);
                options.DefaultModelExpandDepth(10);
                options.DisplayRequestDuration();
                options.EnableFilter();
            });

            return app;
        }
    }
}