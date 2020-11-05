using Myframework.Libraries.Common.Results;
using MediatR;
using System;

namespace Myframework.Libraries.Infra.CQRS.Commands
{
    /// <summary>
    /// Interface para comandos que especifica um retorno genérico.
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    public interface ICommand<TResult> : IRequest<TResult>
        where TResult : Result
    {
        /// <summary>
        /// Protocolo do comando.
        /// </summary>
        Guid Protocol { get; set; }
    }
}