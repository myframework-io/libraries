using System;
using System.Runtime.Serialization;

namespace Myframework.Libraries.Infra.Log.Models
{
    /// <summary>
    /// Classe para representar o log de requisição.
    /// </summary>
    [DataContract]
    public class LogRequest
    {
        /// <summary>Id do log de requisição.</summary>
        [DataMember] public Guid Id { get; set; }

        /// <summary>Protocolo gerado no response da requisição.</summary>
        [DataMember] public Guid Protocol { get; set; }

        /// <summary>Endereço ip que realizou o request.</summary>
        [DataMember] public string ClientIP { get; set; }

        /// <summary>Host da URL. Ex: www.google.com.br/teste/123 => www.google.com.br. Incluir o protocolo nesta propriedade: http://www.google.com.br.</summary>
        [DataMember] public string UrlHost { get; set; }

        /// <summary>Parte da URL, sem levar em conta o host. Ex: www.google.com.br/teste/123 => /teste/123.</summary>
        [DataMember] public string UrlPath { get; set; }

        /// <summary>Content type do request.</summary>
        [DataMember] public string RequestContentType { get; set; }

        /// <summary>Content body do request.</summary>
        [DataMember] public string RequestBody { get; set; }

        /// <summary>Tipo método do request (GET, POST, etc).</summary>
        [DataMember] public string RequestMethod { get; set; }

        /// <summary>Headers do request.</summary>
        [DataMember] public string RequestHeaders { get; set; }

        /// <summary>Timestamp do request.</summary>
        [DataMember] public DateTime RequestDate { get; set; }

        /// <summary>Content type do response.</summary>
        [DataMember] public string ResponseContentType { get; set; }

        /// <summary>Content body do response.</summary>
        [DataMember] public string ResponseBody { get; set; }

        /// <summary>Status code do response.</summary>
        [DataMember] public int? ResponseStatusCode { get; set; }

        /// <summary>Headres do response.</summary>
        [DataMember] public string ResponseHeaders { get; set; }

        /// <summary>Timestamp do response.</summary>
        [DataMember] public DateTime ResponseDate { get; set; }

        /// <summary>Tempo de resposta da requisição em milisegundos.</summary>
        [DataMember] public long ResponseTimeMs { get; set; }

        /// <summary>Tags separadas por ";".</summary>
        [DataMember] public string Tags { get; set; }

        /// <summary>Identificador de entidade customizável.</summary>
        [DataMember] public string IdEntidade { get; set; }

        /// <summary>Dados customizados.</summary>
        [DataMember] public string CustomData { get; set; }
    }
}