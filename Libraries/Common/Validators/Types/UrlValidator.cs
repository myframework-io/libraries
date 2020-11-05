using System;

namespace Myframework.Libraries.Common.Validators.Types
{
    /// <summary>
    /// Validador para url.
    /// </summary>
    internal class UrlValidator : BaseValidator
    {
        private readonly string defaultErrorMessage = "Invalid url.";

        public UrlValidator(string url, string msg = null)
        {
            if (url == null)
                Valid = true;
            else
                Valid = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);

            ErrorMessage = Valid ? null : msg ?? defaultErrorMessage;
        }
    }
}