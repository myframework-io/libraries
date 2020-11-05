namespace Myframework.Libraries.Common.Helpers
{
    /// <summary>
    /// Métodos úteis para máscaras.
    /// </summary>
    public static class MasksHelper
    {
        /// <summary>
        /// Formata um CNPJ com a máscara informada. Caso o valor seja vazio, nulo, tenha apenas espaços ou seja um CNPJ inválido é retornado o mesmo valor sem aplicação da máscara.
        /// </summary>
        /// <param name="cnpj"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public static string MaskCnpj(string cnpj, string mask = @"{0:00\.000\.000\/0000\-00}")
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return cnpj;

            string cnpjEditado = cnpj.Replace(" ", "").Replace(".", "").Replace("-", "").Replace("/", "");

            if (cnpjEditado.Length != 14)
                return cnpj;

            if (!long.TryParse(cnpjEditado, out long cnpjLong))
                return cnpj;

            return Format(cnpj, mask, cnpjLong);
        }

        /// <summary>
        /// Formata um CPF com a máscara informada. Caso o valor seja vazio, nulo, tenha apenas espaços ou seja um CPF inválido é retornado o mesmo valor sem aplicação da máscara.
        /// </summary>
        /// <param name="cpf"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public static string MaskCpf(string cpf, string mask = @"{0:000\.000\.000\-00}")
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return cpf;

            string cpfEditado = cpf.Replace(" ", "").Replace(".", "").Replace("-", "").Replace("/", "");

            if (cpfEditado.Length != 11)
                return cpf;

            if (!long.TryParse(cpfEditado, out long cpfLong))
                return cpf;

            return Format(cpf, mask, cpfLong);
        }

        /// <summary>
        /// Formata uma declaração de nascido vido com a máscara informada. Caso o valor seja vazio, nulo, tenha apenas espaços ou seja inválido é retornado o mesmo valor sem aplicação da máscara.
        /// </summary>
        /// <param name="declaracao"></param>
        /// <param name="mask"></param>
        /// <returns></returns>
        public static string MaskDeclaracaoNascidoVivo(string declaracao, string mask = @"{0:00\-00000000\-0}")
        {
            if (string.IsNullOrWhiteSpace(declaracao))
                return declaracao;

            string declaracaoEditada = declaracao.Replace(" ", "").Replace(".", "").Replace("-", "").Replace("/", "");

            if (declaracaoEditada.Length != 11)
                return declaracao;

            if (!long.TryParse(declaracaoEditada, out long declaracaoLong))
                return declaracao;

            return Format(declaracao, mask, declaracaoLong);
        }

        private static string Format(string originalValue, string format, object valueToFormat)
        {
            try
            {
                return string.Format(format, valueToFormat);
            }
            catch
            {
                return originalValue;
            }
        }
    }
}