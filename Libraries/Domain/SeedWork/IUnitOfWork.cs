using Myframework.Libraries.Common.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Myframework.Libraries.Domain.SeedWork
{
    /// <summary>
    /// Interface com os comandos públicos para serem executados fora do contexto de banco de dados.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Persiste de forma síncrona todas as modificações feitas no contexto.
        /// </summary>
        Result SaveChanges();

        /// <summary>
        /// Persiste de forma assíncrona todas as modificações feitas no contexto.
        /// </summary>
        /// <param name="cancellationToken"></param>
        Task<Result> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Habilita ou desabilita a detecção automática de mudanaças realizadas no contexto.
        /// </summary>
        bool AutoDetectChangesEnabled { get; set; }
    }
}