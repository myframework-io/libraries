namespace Myframework.Libraries.Common.Validators
{
    /// <summary>
    /// Interface para validadores.
    /// </summary>
    public interface IValidator
    {
        /// <summary>
        /// Indica se o valor está válido ou não.
        /// </summary>
        bool Valid { get; }

        /// <summary>
        /// Mensagem de erro caso o valor não seja válido.
        /// </summary>
        string ErrorMessage { get; }
    }
}