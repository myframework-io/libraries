using Myframework.Libraries.Application.MVC;
using Myframework.Libraries.Common.Constants;
using Myframework.Libraries.Common.Helpers;
using Myframework.Libraries.Common.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Myframework.Libraries.Application.Base
{
    public abstract class BaseMvcController : Controller
    {
        /// <summary>
        /// Retorna o token de acesso do usuário logado.
        /// </summary>
        /// <returns></returns>
        protected async Task<string> GetCurrentUserAccessTokenAsync() =>
            await HttpContext.GetTokenAsync("access_token");

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
        /// Retorna o protocolo da requisição. Se não houver, retornará uma nova instância.
        /// </summary>
        /// <returns></returns>
        protected Guid GetRequestProtocol()
        {
            if (!Request.Headers.ContainsKey(Constant.Protocol))
                return Guid.NewGuid();

            string protocolStr = Request.Headers[Constant.Protocol];

            if (Guid.TryParse(protocolStr, out Guid protocol))
                return protocol;

            return Guid.NewGuid();
        }

        protected CultureInfo GetCurrentCulture()
        {
            IRequestCultureFeature rqf = Request.HttpContext.Features.Get<IRequestCultureFeature>();
            return rqf.RequestCulture.Culture;
        }

        ///// <summary>
        ///// Coloca as notificações desejadas no TempData.
        ///// Utilize o método RetornarNotificacoesLayoutPendentes para recuperar estas notificações.
        ///// </summary>
        ///// <param name="notificacoes"></param>
        //protected void PostPendingNotifications(List<PendingNotificationViewModel> notificacoes)
        //{
        //    if (notificacoes == null || !notificacoes.Any())
        //        return;

        //    if (!TempData.ContainsKey(Constants.TempDataPendingNotifications) || TempData[Constants.TempDataPendingNotifications] == null)
        //        TempData[Constants.TempDataPendingNotifications] = new List<PendingNotificationViewModel>();

        //    var notificacoesExistentes = TempData[Constants.TempDataPendingNotifications] as List<PendingNotificationViewModel>;

        //    notificacoesExistentes.AddRange(notificacoes);

        //    TempData[Constants.TempDataPendingNotifications] = notificacoesExistentes;
        //}

        ///// <summary>
        ///// Coloca as notificações desejadas no TempData.
        ///// Utilize o método RetornarNotificacoesLayoutPendentes para recuperar estas notificações.
        ///// </summary>
        ///// <param name="notificacoes"></param>
        //protected void PostPendingNotification(PendingNotificationViewModel notificacao) => PostPendingNotifications(new List<PendingNotificationViewModel> { notificacao });

        //public string RenderRazorViewToString(string viewName, object model)
        //{
        //    ViewData.Model = model;
        //    using (var sw = new StringWriter())
        //    {
        //        var viewResult = Microsoft.AspNetCore.Mvc.ViewEngines.Engines.FindPartialView(ControllerContext,
        //                                                                 viewName);
        //        var viewContext = new ViewContext(ControllerContext, viewResult.View,
        //                                     ViewData, TempData, sw);
        //        viewResult.View.Render(viewContext, sw);
        //        viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
        //        return sw.GetStringBuilder().ToString();
        //    }
        //}

        protected JsonResult CreateSuccessJsonResult(string msg, object response = null) =>
            Json(new MvcJsonResult { Status = MvcJsonResult.StatusEnum.Success, Message = msg, Response = response });

        protected JsonResult CreateWarningJsonResult(string msg, object response = null) =>
            Json(new MvcJsonResult { Status = MvcJsonResult.StatusEnum.Warning, Message = msg, Response = response });

        protected JsonResult CreateErrorJsonResult(string msg, object response = null) =>
            Json(new MvcJsonResult { Status = MvcJsonResult.StatusEnum.Error, Message = msg, Response = response });

        protected JsonResult CreateJsonResultFromDomainResult(Result domainResult, object response = null)
        {
            var jsonResult = new MvcJsonResult
            {
                Status = domainResult.Valid ? MvcJsonResult.StatusEnum.Success : MvcJsonResult.StatusEnum.Warning,
                Response = response,
                Message = domainResult.Message
            };

            if (domainResult.Validations != null)
            {
                jsonResult.Validations = new List<ValidationMessage>();

                foreach (ResultValidation validation in domainResult.Validations)
                {
                    jsonResult.Validations.Add(
                        new ValidationMessage
                        {
                            Atributo = validation.Attribute,
                            Mensagem = validation.Message
                        });
                }
            }

            return Json(jsonResult);
        }

        protected JsonResult CreateJsonResultForInvalidModelState<TModelValidate, TLocalizer>(IStringLocalizer<TLocalizer> sharedLocalizer, object response = null)
            where TModelValidate : class
        {
            var jsonResult = new MvcJsonResult
            {
                Status = MvcJsonResult.StatusEnum.Warning,
                Response = response,
                Message = null,
            };

            var sb = new StringBuilder();
            sb.AppendLine(sharedLocalizer["There are errors in fields:"]);

            sb.AppendLine("<ul>");

            foreach (KeyValuePair<string, ModelStateEntry> entry in ModelState)
            {
                if (entry.Value.ValidationState != ModelValidationState.Invalid)
                    continue;

                DisplayAttribute displayAttr = ReflectionHelper.GetAttribute<TModelValidate, DisplayAttribute>(entry.Key);

                sb.Append($"<li>{sharedLocalizer[displayAttr?.Name ?? entry.Key]}: {entry.Value.Errors.First().ErrorMessage}</li>");
            }

            sb.AppendLine("</ul>");

            jsonResult.Message = sb.ToString();

            return Json(jsonResult);
        }

        protected int NormalizePage(int page)
        {
            if (page < 0)
                page = 0;

            return page;
        }

        protected int NormalizeItensPerPage(int itensPerPage)
        {
            if (itensPerPage <= 0)
                itensPerPage = 10;
            else if (itensPerPage > 100)
                itensPerPage = 100;

            return itensPerPage;
        }

        protected async Task<string> RenderViewAsync<TModel>(string viewName, TModel model, bool partial = false)
        {
            if (string.IsNullOrEmpty(viewName))
            {
                viewName = ControllerContext.ActionDescriptor.ActionName;
            }

            ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                IViewEngine viewEngine = HttpContext.RequestServices.GetService(typeof(ICompositeViewEngine)) as ICompositeViewEngine;
                ViewEngineResult viewResult = viewEngine.FindView(ControllerContext, viewName, !partial);

                if (!viewResult.Success)
                    return $"A view with the name {viewName} could not be found";

                var viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    ViewData,
                    TempData,
                    writer,
                    new HtmlHelperOptions()
                );

                await viewResult.View.RenderAsync(viewContext);

                return writer.GetStringBuilder().ToString();
            }
        }
    }
}