using Myframework.Libraries.Common.Constants;
using Myframework.Libraries.Common.Extensions;
using Myframework.Libraries.Infra.CQRS.Commands;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Linq;

namespace Myframework.Libraries.Application.Configurations.Swagger
{
    /// <summary>
    /// Filtro do swagger para remover certas propriedades, como Protocol do command.
    /// </summary>
    public class SwaggerIgnoreBaseCommandPropertiesSchemaFilter : ISchemaFilter
    {
        private readonly string[] ignoreCommandProperties = new string[]
        {
            Constant.Protocol.Trim().LowerCaseFirstChar(),
            Constant.Authorization.Trim().LowerCaseFirstChar(),
            Constant.AuthorizationUser.Trim().LowerCaseFirstChar()
        };

        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (schema?.Properties == null || schema.Type == null || !schema.Properties.Any())
                return;

            bool hasCommandAsParameter = context?.Type != null && context.Type.IsSubclassOfRawGeneric(typeof(BaseCommand<>));

            if (!hasCommandAsParameter)
                return;

            foreach (string excludedProperty in ignoreCommandProperties)
            {
                if (schema.Properties.ContainsKey(excludedProperty))
                    schema.Properties.Remove(excludedProperty);
            }
        }
    }
}