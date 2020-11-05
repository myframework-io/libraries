using Myframework.Libraries.Application.Security.Authorization;
using Myframework.Libraries.Common.Helpers;
using Myframework.Libraries.Infra.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace Myframework.Libraries.Application.Filters
{
    /// <summary>
    /// Filtro responsável por restringir acesso geral a apenas as roles desejadas. Exemplo de utilização: é desejado que no Admin o usuário não consiga nem navegar.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class RestrictRolesAccessFilter : ActionFilterAttribute
    {
        private readonly List<Roles> roles;

        /// <summary>
        /// 
        /// </summary>
        public RestrictRolesAccessFilter(IOptions<SecurityOptions> options)
        {
            if (options?.Value?.AllowedRoles == null)
                roles = new List<Roles>();
            else
            {
                roles = options.Value.AllowedRoles
                    .Select(it => EnumHelper.GetEnumByDescription<Roles>(it))
                    .Where(it => it != null)
                    .Select(it => it.Value)
                    .ToList();
            }
        }

        /// <summary>
        /// Ação antes da action executar.
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var actionDesc = context?.ActionDescriptor as ControllerActionDescriptor;

            if (actionDesc?.ActionName == "Unauthorize" || actionDesc?.ActionName == "UnauthorizeRoot")
                return;

            List<string> userRoles = GetRolesFromClaims(context.HttpContext);
            var userRolesEnum = userRoles?
                .Select(it => EnumHelper.GetEnumByDescription<Roles>(it))
                .Where(it => it != null)
                .Select(it => it.Value)
                .ToList();

            if (!roles.Intersect(userRolesEnum).Any())
            {
                var controller = context.Controller as Controller;
                context.Result = controller.RedirectToAction("Unauthorize", "Shared");
            }
        }

        /// <summary>
        /// Retorna as claims pelo tipo.
        /// </summary>
        /// <param name="claimType"></param>
        /// <returns></returns>
        protected List<Claim> GetClaims(HttpContext context, string claimType)
        {
            if (context.User?.Claims == null)
                return new List<Claim>();

            return context.User?.Claims.Where(it => it.Type == claimType).ToList();
        }

        /// <summary>
        /// Retorna os valores das claims pelo tipo.
        /// </summary>
        /// <param name="claimType"></param>
        /// <returns></returns>
        protected List<string> GetClaimsValues(HttpContext context, string claimType) =>
            GetClaims(context, claimType).Select(it => it.Value).ToList();

        /// <summary>
        /// Retorna as roles presentes nas claims.
        /// </summary>
        /// <returns></returns>
        protected List<string> GetRolesFromClaims(HttpContext context) =>
            GetClaimsValues(context, "role");
    }
}