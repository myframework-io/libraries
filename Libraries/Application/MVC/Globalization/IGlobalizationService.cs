using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Myframework.Libraries.Application.MVC.Globalization
{
    public interface IGlobalizationService
    {
        Task<List<TermTranslation>> GetTermsTranslationsByTagAsync(string token, Guid protocol, string product, string tag, string culture);
    }
}