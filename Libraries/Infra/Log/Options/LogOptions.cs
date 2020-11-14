using System;
using System.Collections.Generic;

namespace Myframework.Libraries.Infra.Log.Options
{
    /// <summary>Configurações do sistema dos middlewares de log.</summary>
    public class LogOptions
    {
        /// <summary>Indica se deve logar ou não as requisições.</summary>
        public bool EnableLogRequest { get; set; }

        /// <summary>Indica se deve logar ou não os erros.</summary>
        public bool EnableLogError { get; set; }

        /// <summary>Indica se deve logar ou não logar as requisições sem aguardar resposta.</summary>
        public bool LogRequestsInBackground { get; set; }

        /// <summary>Indica se deve logar ou não logar os erros sem aguardar resposta.</summary>
        public bool LogErrorInBackground { get; set; }

        /// <summary>Indica se deve mostrar detalhes da exception no retorno da API. Caso false, retornar mensagem padrão de erro do sistema.</summary>
        public bool ShowErrorDetailsInResponse { get; set; }

        /// <summary>Indica se deve ignorar exceptions ocorridas no processo de log. Caso true, exceções não serão repassadas (com throw) no caso de falha do log.</summary>
        public bool IgnoreExceptionsOccuredInLogProcess { get; set; }

        /// <summary>Indica se deve ignorar exceptions ocorridas no processo de log de arquivo (segunda tentativa). Caso true, exceções não serão repassadas (com throw) no caso de falha do log em arquivos.</summary>
        public bool IgnoreExceptionsOccuredInLogFileProcess { get; set; }

        /// <summary>Propriedades sensíveis que serão substituídas ao logar. Ex: caso "cartão" esteja nessa lista, propriedades com esse nome serão salvar no log com "***".</summary>
        public List<string> SensitiveProperties { get; set; } = new List<string>();

        /// <summary>Nome da aplicação.</summary>
        public string ApplicationName { get; set; }

        /// <summary>Nome/alias do servidor.</summary>
        public string ServerName { get; set; }

        /// <summary>Ip do servidor.</summary>
        public string ServerIp { get; set; }

        /// <summary>Url base para logar erro em um serviço externo.</summary>
        public string HttpApiErrorLogBaseUrl { get; set; }

        /// <summary>Rota da api para logar erro em um serviço externo.</summary>
        public string HttpApiErrorLogRoute { get; set; }

        /// <summary>Timeout da api de log de erro.</summary>
        public TimeSpan HttpApiErrorLogTimeout { get; set; }

        /// <summary>Diretório para logar erros caso o log de erro padrão não funcione. Ou seja, o log do log.</summary>
        public string DirectoryToLogErrorsOnFail { get; set; }

        /// <summary>Opcional. Url para redirecionamento quando o request não é do tipo Ajax.</summary>
        public string RedirectToPageIfIsNotAjaxRequest { get; set; }

        /// <summary>Indica se deve passar o token do usuário da chamada HTTP. Caso falso, irá usar o processo de token do client (IClientTokenManager).</summary>
        public bool LogUsingHttpContextAccessToken { get; set; } = false;
    }
}