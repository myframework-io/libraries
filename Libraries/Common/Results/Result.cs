using Myframework.Libraries.Common.Constants;
using Myframework.Libraries.Common.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Myframework.Libraries.Common.Results
{
    /// <summary>
    /// Representa um resultado de operação. Por padrão o resultado é assumido como válido ao ser instanciado.
    /// </summary>
    [DataContract]
    public class Result
    {
        /// <summary>
        /// Construtor padrão. Por padrão o resultado é assumido como válido.
        /// </summary>
        public Result() => SetoToOK();

        /// <summary>
        /// Erros de validações ocorridas. Geralmente usadas para validações sobre propriedades.
        /// </summary>
        [DataMember(Name = "validations")]
        public List<ResultValidation> Validations { get; set; } = new List<ResultValidation>();

        /// <summary>
        /// Mensagem do resultado.
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; private set; }

        /// <summary>
        /// Protocolo para tracking.
        /// </summary>
        [DataMember(Name = "protocol")]
        public Guid Protocol { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Código do resultado. Utilize a propriedade Valid para checar de forma fácil se o resultado foi bem sucedido ou não.
        /// </summary>
        [IgnoreDataMember, System.Text.Json.Serialization.JsonIgnore]
        public ResultCode ResultCode { get; private set; }

        /// <summary>
        /// Indica se o resultado foi bem sucedido ou não.
        /// </summary>
        [IgnoreDataMember, System.Text.Json.Serialization.JsonIgnore]
        public bool Valid => (int)ResultCode < 400;

        /// <summary>
        /// Configura este result com as informações desejadas.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        /// <param name="validations"></param>
        public virtual Result Set(ResultCode code, string message, List<ResultValidation> validations)
        {
            Set(code, message);
            Validations = validations ?? new List<ResultValidation>();

            return this;
        }

        /// <summary>
        /// Configura este result com as informações desejadas.
        /// </summary>
        /// <param name="code"></param>
        /// <param name="message"></param>
        public virtual Result Set(ResultCode code, string message)
        {
            switch (code)
            {
                case ResultCode.Ok:
                    SetoToOK(message);
                    break;

                case ResultCode.GenericError:
                    Message = string.IsNullOrWhiteSpace(message) ? Constant.DefaultErrorMsg : message;
                    ResultCode = ResultCode.GenericError;
                    break;

                case ResultCode.BusinessError:
                    Message = message;
                    ResultCode = ResultCode.BusinessError;
                    break;

                default:
                    Message = message;
                    ResultCode = code;
                    break;
            }

            return this;
        }

        /// <summary>
        /// Configura este result para o status "BusinessError" (ou seja, inválido) com a mensagem desejada.
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public virtual Result SetBusinessMessage(string message)
        {
            Message = message;
            ResultCode = ResultCode.BusinessError;

            return this;
        }

        /// <summary>
        /// Configura este result com as informações de outro result (message, messageCode e validations).
        /// </summary>
        /// <param name="result"></param>
        public virtual Result SetFromAnother(Result result)
        {
            if (result == null)
                return this;

            Message = result.Message;
            ResultCode = result.ResultCode;

            if (result.Validations != null && result.Validations.Any())
            {
                if (Validations == null)
                    Validations = new List<ResultValidation>();

                foreach (ResultValidation validation in result.Validations)
                {
                    Validations.Add(validation);
                }
            }
            else
                Validations = new List<ResultValidation>();

            return this;
        }

        /// <summary>
        /// Adiciona uma validação e seta o result code para BusinessError caso o status atual seja OK (válido).
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="message"></param>
        public virtual Result AddValidation(string attribute, string message)
        {
            if (string.IsNullOrWhiteSpace(attribute))
                throw new ArgumentException($"The parameter {nameof(attribute)} is required to add validation to result.");

            if (string.IsNullOrWhiteSpace(message))
                throw new ArgumentException($"The parameter {nameof(message)} is required to add validation to result.");

            Validations.Add(new ResultValidation { Attribute = attribute, Message = message });

            if (ResultCode == ResultCode.Ok)
                Set(ResultCode.BusinessError, Constant.Validations);

            return this;
        }

        /// <summary>
        /// Adiciona uma validação baseda no validador do Framework Common. Caso o validador seja inválido e este result tenha status OK, ele será atualizado para status BusinessError e a validação será adicionada à lista de validações.
        /// </summary>
        /// <param name="attribute"></param>
        /// <param name="validatorResult"></param>
        /// <returns></returns>
        public virtual Result AddValidationsIfFails(string attribute, IValidatorResult validatorResult)
        {
            if (validatorResult.Valid)
                return this;

            return AddValidation(attribute, validatorResult.Message);
        }

        /// <summary>
        /// Retorna a mensagem e possíveis validações do result.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(Message);

            if (!Valid && Validations != null && Validations.Any())
            {
                sb.AppendLine("");
                Validations.ForEach(val => sb.AppendLine($"- {val.Attribute}: {val.Message}"));
            }

            string toString = sb.ToString();

            if (toString.EndsWith("\r\n"))
                toString = toString.Substring(0, toString.Length - 2);

            return toString;
        }

        /// <summary>
        /// Configura este result para status OK (válido).
        /// </summary>
        private void SetoToOK(string msg = null)
        {
            Message = string.IsNullOrWhiteSpace(msg) ? Constant.Success : msg;
            ResultCode = ResultCode.Ok;
        }
    }
}