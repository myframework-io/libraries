using System.Collections.Generic;
using System.Linq;

namespace Myframework.Libraries.Common.Validators
{
    /// <summary>
    /// Classe base com informações e comportamentos padrões de resultados de validações.
    /// </summary>
    public abstract class BaseValidatorResult : IValidatorResult
    {
        private bool firstValidationDone = false;

        /// <summary>
        /// Indica se o resultado de todos os validadores é válido ou não.
        /// </summary>
        public bool Valid { get; private set; }

        /// <summary>
        /// Mensagens de erros.
        /// </summary>
        public List<string> Messages { get; private set; } = new List<string>();

        /// <summary>
        /// Mensagem sumarizada de erros.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Validadores que geraram este resultado.
        /// </summary>
        public List<IValidator> Validators { get; private set; } = new List<IValidator>();

        /// <summary>
        /// Agrega um ou mais resultados de validação em apenas um.
        /// </summary>
        protected void AggregateBase(List<IValidatorResult> results)
        {
            if (results == null || !results.Any())
                return;

            foreach (IValidatorResult result in results)
            {
                if (result == null)
                    continue;

                if (firstValidationDone)
                    Valid = Valid && result.Valid;
                else
                {
                    Valid = result.Valid;
                    firstValidationDone = true;
                }

                Validators.AddRange(result.Validators);
                Messages.AddRange(result.Messages?.Where(it => !string.IsNullOrWhiteSpace(it)).ToList());
                IncrementSummaryMessage(result.Message);
            }
        }

        /// <summary>
        /// Adiciona um validador ao resultado.
        /// </summary>
        /// <param name="validator"></param>
        protected void AddValidatorBase(IValidator validator)
        {
            if (validator == null)
                return;

            Validators.Add(validator);

            if (firstValidationDone)
                Valid = Valid && validator.Valid;
            else
            {
                Valid = validator.Valid;
                firstValidationDone = true;
            }

            if (!string.IsNullOrWhiteSpace(validator.ErrorMessage))
            {
                Messages.Add(validator.ErrorMessage);
                IncrementSummaryMessage(validator.ErrorMessage);
            }

            return;
        }

        private void IncrementSummaryMessage(string msg)
        {
            if (string.IsNullOrWhiteSpace(msg))
                return;

            if (Message == null)
                Message = msg;
            else
                Message += "\r\n" + msg;
        }
    }
}