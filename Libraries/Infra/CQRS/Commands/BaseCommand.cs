using Myframework.Libraries.Common.Results;
using System;

namespace Myframework.Libraries.Infra.CQRS.Commands
{
    /// <summary>
    /// Classe base para comandos que tem resultado (Result).
    /// </summary>
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public abstract class BaseCommand<TResult> : ICommand<TResult>
        where TResult : Result
    {
        /// <summary>
        /// Protocolo do comando.
        /// </summary>
        public Guid Protocol { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Token de autorização da requisição.
        /// </summary>
        public string Authorization { get; set; } = null;

        /// <summary>
        /// Usuário do token de autorização da requisição.
        /// </summary>
        public string AuthorizationUser { get; set; } = null;
    }

    /// <summary>
    /// Classe base para comandos que tem resultado (Result) com valor de retorno.
    /// </summary>
    public abstract class BaseCommandResult : BaseCommand<Result>
    {
    }

    /// <summary>
    /// Classe base para comandos que tem resultado (Result) com valor de retorno.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public abstract class BaseCommandResult<TResult> : BaseCommand<Result<TResult>>
        where TResult : class
    {
    }
}