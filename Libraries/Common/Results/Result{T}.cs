using Myframework.Libraries.Common.Validators;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Myframework.Libraries.Common.Results
{
    /// <summary>
    /// Representa um resultado de operação, com retorno genérico. Por padrão o resultado é assumido como válido ao ser instanciado.
    /// </summary>
    /// <typeparam name="T">Genérico que deve ser uma classe.</typeparam>
    [DataContract]
    public class Result<T> : Result
        where T : class
    {
        /// <summary>
        /// Construtor padrão. Por padrão o resultado é assumido como válido.
        /// </summary>
        public Result(T value = null)
            : base() => Value = value;

        /// <summary>
        /// Valor de retorno do result. Só deve possuir valor caso seja válido.
        /// </summary>
        [DataMember(Name = "response")]
        public T Value { get; set; }

        /// <summary>
        /// Adiciona uma validação e seta o result code para BusinessError caso o status atual seja OK (válido).
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="message"></param>
        public new Result<T> AddValidation(string attribute, string message)
        {
            base.AddValidation(attribute, message);
            return this;
        }

        /// <summary>
        /// Adiciona uma validação baseda no validador do Framework Common. Caso o validador seja inválido e este result tenha status OK, ele será atualizado para status BusinessError e a validação será adicionada à lista de validações.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="validatorResult"></param>
        /// <returns></returns>
        public new Result<T> AddValidationsIfFails(string attribute, IValidatorResult validatorResult)
        {
            base.AddValidationsIfFails(attribute, validatorResult);
            return this;
        }

        /// <summary>
        /// Configura este result com as informações desejadas.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public new Result<T> Set(ResultCode code, string message)
        {
            base.Set(code, message);
            return this;
        }

        /// <summary>
        /// Configura este result com as informações desejadas.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="validations"></param>
        public new Result<T> Set(ResultCode code, string message, List<ResultValidation> validations)
        {
            base.Set(code, message, validations);
            return this;
        }

        /// <summary>
        /// Configura este result para o status "BusinessError" (ou seja, inválido) com a mensagem desejada.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public new Result<T> SetBusinessMessage(string message)
        {
            base.SetBusinessMessage(message);
            return this;
        }

        /// <summary>
        /// Configura este result com as informações de outro result (message, messageCode e validations).
        /// </summary>
        /// <param name="result"></param>
        public new Result<T> SetFromAnother(Result result)
        {
            base.SetFromAnother(result);
            return this;
        }
    }
}
