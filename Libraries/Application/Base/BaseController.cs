using Myframework.Libraries.Common.Constants;
using Myframework.Libraries.Common.Results;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;

namespace Myframework.Libraries.Application.Base
{
    /// <summary>
    /// Base controller com métodos úteis para controllers.
    /// </summary>
    public abstract class BaseController : ControllerBase
    {
        /// <summary>
        /// Converte o result do Framework.Common para IActionResult.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        [NonAction]
        protected IActionResult GetIActionResult(Result result)
        {
            if (result == null)
                return StatusCode(500, null);

            SetResultProtocolFromRequestHeader(result);

            return StatusCode((int)result.ResultCode, result);
        }

        /// <summary>
        /// Cria um result padrão para queries.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        [NonAction]
        protected IActionResult CreateResultForQueries<T>(T type) where T : class
        {
            var result = new Result<T> { Value = type };

            if (Request.Headers.ContainsKey(Constant.Protocol))
            {
                if (Guid.TryParse(Request.Headers[Constant.Protocol].ToString(), out Guid protocol))
                    result.Protocol = protocol;
            }

            return GetIActionResult(result);
        }

        /// <summary>
        /// Atualiza o result com o protocolo presente no Header, se houver.
        /// </summary>
        /// <param name="result"></param>
        [NonAction]
        protected void SetResultProtocolFromRequestHeader(Result result)
        {
            if (result == null)
                return;

            if (Request.Headers.ContainsKey(Constant.Protocol))
            {
                if (Guid.TryParse(Request.Headers[Constant.Protocol], out Guid protocol))
                    result.Protocol = protocol;
            }
        }

        /// <summary>
        /// Retorna a claim pelo tipo.
        /// </summary>
        /// <param name="claimType"></param>
        /// <returns></returns>
        [NonAction]
        protected Claim GetClaim(string claimType)
        {
            if (User?.Claims == null)
                return null;

            return User?.Claims.Where(it => it.Type == claimType).FirstOrDefault();
        }

        /// <summary>
        /// Retorna as claims pelo tipo.
        /// </summary>
        /// <param name="claimType"></param>
        /// <returns></returns>
        [NonAction]
        protected List<Claim> GetClaims(string claimType)
        {
            if (User?.Claims == null)
                return null;

            return User?.Claims.Where(it => it.Type == claimType).ToList();
        }

        /// <summary>
        /// Retorna os valores das claims pelo tipo.
        /// </summary>
        /// <param name="claimType"></param>
        /// <returns></returns>
        [NonAction]
        protected List<string> GetClaimsValues(string claimType) =>
            GetClaims(claimType).Select(it => it.Value).ToList();

        /// <summary>
        /// Retorna as roles presentes nas claims.
        /// </summary>
        /// <returns></returns>
        [NonAction]
        protected List<string> GetRolesFromClaims() =>
            GetClaimsValues("role");

        /// <summary>
        /// Retorna o user name presente nas claims através do claim type "preferred_username".
        /// </summary>
        /// <returns></returns>
        [NonAction]
        protected string GetUserNameFromClaims() =>
            GetClaim("preferred_username")?.Value;

        /// <summary>
        /// Retorna os scopes presentes nas claims através do ClaimType "scope".
        /// </summary>
        /// <returns></returns>
        [NonAction]
        protected List<string> GetScopesFromClaims() =>
            GetClaimsValues("scope");

        /// <summary>
        /// Retorna a cultura atual da requisição.
        /// </summary>
        /// <returns></returns>
        [NonAction]
        protected CultureInfo GetCurrentCulture()
        {
            IRequestCultureFeature rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            return rqf?.RequestCulture?.Culture;
        }

        [NonAction]
        protected Guid GetProtocol()
        {
            string protocoloStr = Request.Headers[Constant.Protocol].ToString();

            if (string.IsNullOrWhiteSpace(protocoloStr) || !Guid.TryParse(protocoloStr, out Guid protocolo))
                return Guid.NewGuid();
            else
                return protocolo;
        }

        [NonAction]
        protected string GetAccessToken() => Request.Headers[Constant.Authorization].ToString();
    }
}