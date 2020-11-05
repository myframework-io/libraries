namespace Myframework.Libraries.Common.Validators.Types
{
    /// <summary>
    /// Classe base para os validadores com propriedades e métodos comum a todos.
    /// </summary>
    public class BaseValidator : IValidator
    {
        /// <summary>
        /// Indica se o valor está válido ou não.
        /// </summary>
        public bool Valid { get; protected set; }

        /// <summary>
        /// Mensagem de erro caso o valor não seja válido.
        /// </summary>
        public string ErrorMessage { get; protected set; }
    }
}