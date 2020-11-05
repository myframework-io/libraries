using System.Collections.Generic;

namespace Myframework.Libraries.Application.Options
{
    /// <summary>
    /// Configurações de globalização.
    /// </summary>
    public class GlobalizationOptions
    {
        /// <summary>
        /// Cultura padrão dos requests.
        /// </summary>
        public string DefaultRequestCulture { get; set; }

        /// <summary>
        /// Culturas suportadas.
        /// </summary>
        public List<string> SupportedCultures { get; set; } = new List<string>();

        /// <summary>
        /// Culturas de UI suportadas.
        /// </summary>
        public List<string> SupportedUICultures { get; set; } = new List<string>();

        /// <summary>
        /// Indica se deve usar ou ignorar troca de cultura quando houver parâmetro de cultura na query string.
        /// </summary>
        public bool UseQueryStringRequestCultureProvider { get; set; } = false;
    }
}