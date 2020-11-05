namespace Myframework.Libraries.Common.Results
{
    /// <summary>
    /// Classe para representar uma validação do result.
    /// </summary>
    public class ResultValidation
    {
        /// <summary>
        /// Campo da validação. Ex: "Cep".
        /// </summary>
        public string Attribute { get; set; }

        /// <summary>
        /// Mensagem para a validação do campo. Ex: "Campo obrigatório".
        /// </summary>
        public string Message { get; set; }
    }
}