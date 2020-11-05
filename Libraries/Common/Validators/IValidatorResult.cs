using System.Collections.Generic;

namespace Myframework.Libraries.Common.Validators
{
    /// <summary>
    /// Interface para resutlados de validações.
    /// </summary>
    public interface IValidatorResult
    {
        /// <summary>
        /// Indica se o resultado de todos os validadores é válido ou não.
        /// </summary>
        bool Valid { get; }

        /// <summary>
        /// Mensagens de erros.
        /// </summary>
        List<string> Messages { get; }

        /// <summary>
        /// Mensagem sumarizada de erros.
        /// </summary>
        string Message { get; }

        /// <summary>
        /// Validadores que geraram este resultado.
        /// </summary>
        List<IValidator> Validators { get; }
    }
}