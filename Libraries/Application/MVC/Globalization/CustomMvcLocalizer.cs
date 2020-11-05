using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Myframework.Libraries.Application.MVC.Globalization
{
    /// <summary>
    /// Derivação do StringLocalizer que permite buscar resources de um serviço ao invés de arquivo físico.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CustomMvcLocalizer<T> : StringLocalizer<T>
    {
        private readonly List<char> charactersToBeRemovedOnRegex = new List<char> { ',', '.', ';', ':' };
        private readonly Guid protocol;
        private readonly List<TermTranslation> translations;

        public CustomMvcLocalizer(IStringLocalizerFactory factory, IGlobalizationService globalizationService, IHttpContextAccessor httpContextAccessor)
            : base(factory)
        {
            string token = httpContextAccessor.HttpContext.GetTokenAsync("access_token").GetAwaiter().GetResult();

            if (httpContextAccessor.HttpContext.Request.Headers.ContainsKey(Common.Constants.Constant.Protocol))
                protocol = new Guid(httpContextAccessor.HttpContext.Request.Headers[Common.Constants.Constant.Protocol]);
            else
                protocol = Guid.NewGuid();

            Type type = typeof(T);
            object[] attrs = type.GetCustomAttributes(typeof(Microsoft.AspNetCore.Mvc.AreaAttribute), false);

            string area;

            if (attrs.Length > 0)
                area = (attrs[0] as Microsoft.AspNetCore.Mvc.AreaAttribute).RouteValue;
            else
                area = "Shared";

            string tag = type.Name?.Replace("Controller", "");

            IRequestCultureFeature requestCultureFeature = httpContextAccessor.HttpContext.Features.Get<IRequestCultureFeature>();
            RequestCulture requestCulture = requestCultureFeature.RequestCulture;
            string culture = requestCulture.Culture.Name?.ToLower();

            translations = globalizationService.GetTermsTranslationsByTagAsync(token, protocol, area, tag, culture).GetAwaiter().GetResult();
        }

        public override LocalizedString this[string name]
        {
            get
            {
                TermTranslation resource = translations?.FirstOrDefault(it => it.Term?.Trim().ToLower() == name?.Trim().ToLower());

                if (resource?.Translation != null && !string.IsNullOrWhiteSpace(resource.Translation))
                    return new LocalizedString(name, resource?.Translation, resource == null);
                else
                {
                    resource = TryTranslateTermUsingRegex(name);

                    if (resource?.Translation != null && !string.IsNullOrWhiteSpace(resource.Translation))
                        return new LocalizedString(name, resource?.Translation, resource == null);
                    else
                        return new LocalizedString(name, name, resource == null);
                }
            }
        }

        public override LocalizedString this[string name, params object[] arguments] => this[name];

        private TermTranslation TryTranslateTermUsingRegex(string term)
        {
            TermTranslation termTranslation = null;

            if (string.IsNullOrWhiteSpace(term))
                return termTranslation;

            var regexTerms = translations?.Where(it => it.RegexPattern).ToList();

            if (regexTerms == null || regexTerms.Count == 0)
                return termTranslation;

            termTranslation = regexTerms.FirstOrDefault(it => Regex.IsMatch(term, it.TermRegex));

            TranslateTermRegex(term, termTranslation);

            return termTranslation;
        }

        private void TranslateTermRegex(string term, TermTranslation regexTerm)
        {
            if (string.IsNullOrWhiteSpace(term) || regexTerm == null)
                return;

            string translation = term;

            //Split phrases into word arrays
            string[] phrase1Words = translation.Split(' ');
            string[] phrase2Words = regexTerm.Term.Split(' ');

            phrase1Words = Clean(phrase1Words);
            phrase2Words = Clean(phrase2Words);

            //Find the intersection of the two arrays (find the matching words)
            IEnumerable<string> wordsInPhrase = phrase1Words.Intersect(phrase2Words);

            //Find the differing words
            var wordsOnlyInPhrase1 = phrase1Words.Except(wordsInPhrase).ToList();

            translation = regexTerm.Translation;

            int i = 0;
            foreach (string item in wordsOnlyInPhrase1)
            {
                string itemTranslation = translations?.FirstOrDefault(it => it.Term?.Trim().ToLower() == item?.Trim().ToLower())?.Translation ?? item;
                translation = translation.Replace($"{{{i}}}", itemTranslation);
                i++;
            }

            regexTerm.Translation = translation;
        }

        private string[] Clean(string[] words)
        {
            string[] cleanneds = new string[words.Length];

            for (int i = 0; i < words.Length; i++)
            {
                char lastCharacter = words[i].Last();

                if (charactersToBeRemovedOnRegex.Any(it => it == lastCharacter))
                    cleanneds[i] = words[i].Substring(0, words[i].Length - 1);
                else
                    cleanneds[i] = words[i];
            }

            return cleanneds;
        }
    }
}