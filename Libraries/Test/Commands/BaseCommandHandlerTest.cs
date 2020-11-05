using Myframework.Libraries.Common.Results;
using Myframework.Libraries.Domain.SeedWork;
using Myframework.Libraries.Infra.CQRS.Commands;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using System;
using System.Threading;
using Xunit;

namespace Myframework.Libraries.Test.Commands
{
    /// <summary>
    /// Classe base com métodos úteis para testar commands handles.
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TCommandHandle"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    public abstract class BaseCommandHandlerTest<TCommand, TCommandHandle, TResult>
        where TCommand : ICommand<TResult>
        where TCommandHandle : IRequestHandler<TCommand, TResult>
        where TResult : Result
    {
        /// <summary>
        /// Mock default para UnitOfWork.
        /// </summary>
        protected readonly Mock<IUnitOfWork> mockUnitOfWork;

        public BaseCommandHandlerTest()
        {
            mockUnitOfWork = new Mock<IUnitOfWork>();
            MockSaveChanges();
        }

        [Fact(DisplayName = "Command cannot be null")]
        public void CommandCannotBeNull()
        {
            TCommand command = default;

            TCommandHandle handle = CreateInstanceOfCommandHandle();
            TResult result = handle.Handle(command, default).GetAwaiter().GetResult();

            Assert.False(result.Valid);
            AssertSaveChangesCall(Times.Never);
        }

        /// <summary>
        /// Método abstrato para criação do handle do teste.
        /// </summary>
        /// <returns></returns>
        protected abstract TCommandHandle CreateInstanceOfCommandHandle();

        /// <summary>
        /// Verifica se o SaveChangesAsync foi chamado x vezes, de acordo com o desejado.
        /// </summary>
        /// <param name="times"></param>
        protected void AssertSaveChangesAsyncCall(Func<Times> times) =>
            mockUnitOfWork.Verify(it => it.SaveChangesAsync(It.IsAny<CancellationToken>()), times);

        /// <summary>
        /// Verifica se o SaveChanges foi chamado x vezes, de acordo com o desejado.
        /// </summary>
        /// <param name="times"></param>
        protected void AssertSaveChangesCall(Func<Times> times) =>
            mockUnitOfWork.Verify(it => it.SaveChanges(), times);

        /// <summary>
        /// Cria uma instância do memory cache para uso nos testes.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        protected IMemoryCache CreateInstanceOfMemoryCache(MemoryCacheOptions options = null) =>
            new MemoryCache(options ?? new MemoryCacheOptions());

        private void MockSaveChanges()
        {
            mockUnitOfWork.Setup(it => it.SaveChanges()).Returns(new Result());
            mockUnitOfWork.Setup(it => it.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(new Result());
        }
    }
}