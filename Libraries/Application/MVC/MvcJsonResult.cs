using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Myframework.Libraries.Application.MVC
{
    /// <summary>
    /// Padrão de retorno para sites MVC.
    /// </summary>
    [DataContract()]
    public class MvcJsonResult
    {
        /// <summary>
        /// 
        /// </summary>
        public enum StatusEnum
        {
            /// <summary></summary>
            Success = 0,

            /// <summary></summary>
            Warning = 1,

            /// <summary></summary>
            Error = 2
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "response")]
        public object Response { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "protocol")]
        public Guid Protocol { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "status")]
        public StatusEnum Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "validations", EmitDefaultValue = false)]
        public List<ValidationMessage> Validations { get; set; } = new List<ValidationMessage>();

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "message", EmitDefaultValue = false)]
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "urlLocal", EmitDefaultValue = false)]
        public bool UrlLocal { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "urlRedirect", EmitDefaultValue = false)]
        public string UrlRedirect { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "reload", EmitDefaultValue = false)]
        public bool Reload { get; set; } = false;

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "html", EmitDefaultValue = false)]
        public string Html { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "exception", EmitDefaultValue = false)]
        public ExceptionMvcJson Exception { get; set; }
    }

    /// <summary>
    /// Representa uma mensagem de validação.
    /// </summary>
    [DataContract()]
    public class ValidationMessage
    {
        /// <summary>
        /// Campo com erro de validação. Ex: "Cep".
        /// </summary>
        [DataMember(Name = "attribute")]
        public string Atributo { get; set; }

        /// <summary>
        /// Mensagem para a validação do campo. Ex: "Campo obrigatório".
        /// </summary>
        [DataMember(Name = "message")]
        public string Mensagem { get; set; }
    }

    /// <summary>
    /// Padrão de retorno de erro para sites MVC.
    /// </summary>
    [DataContract]
    public class ExceptionMvcJson
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exc"></param>
        public ExceptionMvcJson(Exception exc)
        {
            Message = exc.Message;
            Type = exc.GetType().Name;
            StackTrace = exc.StackTrace;

            if (exc.InnerException != null)
                InnerException = new ExceptionMvcJson(exc.InnerException);
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "type")]
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "stackTrace")]
        public string StackTrace { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "message")]
        public string Message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember(Name = "innerException")]
        public ExceptionMvcJson InnerException { get; set; }
    }
}