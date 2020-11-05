using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Myframework.Libraries.Common.DataAnnotation
{
    /// <summary>
    /// Validação para parametro lista requerido.
    /// Tem que ter pelo menos um elemento.
    /// </summary>
    public class RequiredListAttribute : ValidationAttribute
    {
        /// <summary>
        /// Construtor inicializando a msg ErrorMessage default
        /// </summary>
        public RequiredListAttribute() => base.ErrorMessage = "{0} is required";

        /// <summary>
        /// Método que define se os pré-requesitos foram atendidos
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) =>
            (value as IList)?.Count > 0 ? ValidationResult.Success : new ValidationResult(string.Format(base.ErrorMessage, validationContext.DisplayName));
    }
}
