using System;

namespace Myframework.Libraries.Common.Extensions
{
    /// <summary>
    /// Extensões para exceções.
    /// </summary>
    public static class ExceptionExtension
    {
        /// <summary>
        /// Verifica se a Exception é um timeout pela mensagem de erro.
        /// </summary>
        /// <param name="exc"></param>
        /// <returns></returns>
        public static bool CheckIsTimeoutExceptionByMessage(this Exception exc)
        {
            if (exc == null)
                return false;

            if (exc.InnerException != null)
                return exc.InnerException.CheckIsTimeoutExceptionByMessage();

            return
                exc.Message != null
                &&
                (
                    exc.Message.ToLower().Contains("o tempo limite da operação foi atingido")
                    || exc.Message.ToLower().Contains("the operation has timed out")
                );
        }
    }
}