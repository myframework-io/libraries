using Myframework.Libraries.Common.Constants;
using Myframework.Libraries.Common.Extensions;
using Myframework.Libraries.Common.Results;
using Myframework.Libraries.Infra.CQRS.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;
using System.Reflection;
using System.Security.Claims;

namespace Myframework.Libraries.Application.Filters
{
    /// <summary>
    /// Filtro responsável por configurar o protocolo tanto no header do request quanto no comando (quando a action esperar um). Além disso preenche o comando com o Auhtorization do header da requisição;
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class CommandConfigurationFilter : ActionFilterAttribute
    {
        /// <summary>
        /// 
        /// </summary>
        public CommandConfigurationFilter() { }

        /// <summary>
        /// Ação antes da action executar.
        /// Atribui o protocolo do header da requisição .
        /// Atribui também ao comando, quando houver. 
        /// Garante também que um comando não chegue nulo à action.
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            InitializeProtocol(context.HttpContext.Request);

            var keys = context.ActionArguments.Keys.ToList();
            foreach (string key in keys)
            {
                object paramValue = context.ActionArguments[key];

                Microsoft.AspNetCore.Mvc.Abstractions.ParameterDescriptor paramDescriptor = context.ActionDescriptor.Parameters.Where(it => it.Name == key).FirstOrDefault();

                if (!paramDescriptor.ParameterType.IsSubclassOfRawGeneric(typeof(BaseCommand<>)))
                    continue;

                if (paramValue == null)
                {
                    paramValue = Activator.CreateInstance(paramDescriptor.ParameterType);
                    context.ActionArguments[key] = paramValue;
                }

                ConfigureProtocolForCommand(context, paramValue);
                ConfigureAuthorizationForCommand(context, paramValue);
                ConfigureAuthorizationUserForCommand(context, paramValue);
            }
        }

        private void InitializeProtocol(HttpRequest request)
        {
            string protocoloStr = request.Headers[Constant.Protocol].ToString();

            if (string.IsNullOrWhiteSpace(protocoloStr) || !Guid.TryParse(protocoloStr, out Guid protocolo))
            {
                protocolo = Guid.NewGuid();

                if (string.IsNullOrWhiteSpace(protocoloStr))
                    request.Headers.Add(Constant.Protocol, protocolo.ToString());
                else
                    request.Headers[Constant.Protocol] = protocolo.ToString();
            }
        }

        private void ConfigureProtocolForCommand(ActionExecutingContext context, object command)
        {
            if (command == null)
                return;

            string protocoloStr = context.HttpContext.Request.Headers[Constant.Protocol].ToString();

            PropertyInfo protocolProperty = command.GetType().GetProperty(Constant.Protocol);

            if (protocolProperty != null)
                protocolProperty.SetValue(command, new Guid(protocoloStr));
        }

        private void ConfigureAuthorizationForCommand(ActionExecutingContext context, object command)
        {
            if (command == null)
                return;

            string authorizationStr = context.HttpContext.Request.Headers[Constant.Authorization].ToString();

            PropertyInfo auhtorizationProperty = command.GetType().GetProperty(Constant.Authorization);

            if (auhtorizationProperty != null)
                auhtorizationProperty.SetValue(command, authorizationStr);
        }

        private void ConfigureAuthorizationUserForCommand(ActionExecutingContext context, object command)
        {
            if (command == null)
                return;

            Claim authUserClaim = context?.HttpContext?.User?.Claims?.FirstOrDefault(it => it.Type == "preferred_username");

            PropertyInfo auhtorizationProperty = command.GetType().GetProperty(nameof(BaseCommand<Result>.AuthorizationUser));

            if (auhtorizationProperty != null)
                auhtorizationProperty.SetValue(command, authUserClaim?.Value);
        }
    }
}