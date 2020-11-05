using Myframework.Libraries.Common.Extensions;
using Myframework.Libraries.Common.Results;
using Myframework.Libraries.Infra.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Myframework.Libraries.Application.Filters
{
    /// <summary>
    /// Filtro responsável por executar a verificação dos DataAnnotations dos comandos.
    /// </summary>
    public class ValidateCommandFilter : ActionFilterAttribute
    {
        /// <summary>
        /// Ocorre antes da action ser executada. Percorre os parâmetros da action e verifica se há algum comando inválido.
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ActionArguments.Any())
            {
                foreach (KeyValuePair<string, object> kvp in context.ActionArguments)
                {
                    if (kvp.Value != null && kvp.Value.GetType().IsSubclassOfRawGeneric(typeof(BaseCommand<>)))
                        ExecuteValidationInArgument(context, kvp.Value);
                }
            }
            else
            {
                // Esse caso acontece quando um valor passado não pode ser convertido para a propriedade adequada pelo ModelBinder. Quando isso acontece, o parametro da action fica nulo, o que quebra o padrao da arquitetura
                // Então, quando for detectado que não há um argumento para a action, mas ela espera um command, criamos uma instancia vazia para receber os erros de validação e retornar no padrão da arquitetura
                if (context.ActionDescriptor.Parameters.Any() && !context.ModelState.IsValid)
                {
                    Microsoft.AspNetCore.Mvc.Abstractions.ParameterDescriptor paramDescriptor = context.ActionDescriptor.Parameters
                        .FirstOrDefault(it => it.ParameterType.IsSubclassOfRawGeneric(typeof(BaseCommand<>)));

                    if (paramDescriptor == null) return;

                    object request = Activator.CreateInstance(paramDescriptor.ParameterType);
                    context.ActionArguments.Add(paramDescriptor.Name, request);
                    ExecuteValidationInArgument(context, request);
                }
            }
        }

        private void ExecuteValidationInArgument<TCommand>(ActionExecutingContext context, TCommand command)
            where TCommand : class
        {
            var result = new Result();

            if (command == null)
            {
                result.Set(ResultCode.BadRequest, "Command cannot be null.");
                context.Result = new BadRequestObjectResult(result);
                return;
            }

            if (context.ModelState.IsValid)
                return;

            foreach (KeyValuePair<string, ModelStateEntry> kvp in context.ModelState)
            {
                string key = kvp.Key.Split('.').LastOrDefault();
                ModelStateEntry value = kvp.Value;

                if (value.Errors == null || !value.Errors.Any())
                    continue;

                result.Validations.Add(new ResultValidation { Attribute = key, Message = value.Errors.First().ErrorMessage });
            }

            result.Set(ResultCode.BadRequest, "See validations.");
            context.Result = new BadRequestObjectResult(result);
        }
    }
}