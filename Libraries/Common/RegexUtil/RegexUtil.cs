namespace Myframework.Libraries.Common.RegexUtil
{
    /// <summary>
    /// Regex utilitários.
    /// </summary>
    public class RegexUteis
    {
        /// <summary></summary>
        public const string CPF = @"([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})";

        /// <summary></summary>
        public const string CNPJ = @"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})";

        /// <summary></summary>
        public const string Email = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-||_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+([a-z]+|\d|-|\.{0,1}|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])?([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$";

        /// <summary></summary>
        public const string Iccid = @"8955(37|24|16|05|32|33|34|07|00|39|15|02|03|04|08|31|06|10|11|23)\\d{13,14}";

        /*
         Explicação:
         ^ - Início da string.
        \( - Um abre parênteses.
        [1-9]{2} - Dois dígitos de 1 a 9. Não existem códigos de DDD com o dígito 0.
        \) - Um fecha parênteses.
          - Um espaço em branco.
        (?:[2-8]|9[1-9]) - O início do número. Representa uma escolha entre o [2-8] e o 9[1-9]. O | separa as opções a serem escolhidas. O (?: ... ) agrupa tais escolhas. Telefones fixos começam com dígitos de 2 a 8. Telefones celulares começam com 9 e têm um segundo dígito de 1 a 9. O primeiro dígito nunca será 0 ou 1. Celulares não podem começar com 90 porque esse é o prefixo para ligações a cobrar.
        [0-9]{3} - Os demais três dígitos da primeira metade do número do telefone, perfazendo um total de 4 ou 5 dígitos na primeira metade.
        \- - Um hífen.
        [0-9]{4} - A segunda metade do número do telefone.
        $ - Final da string.
        */
        /// <summary></summary>
        public const string TelephoneOrCellPhone = @"^\([1-9]{2}\) (?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$";
    }
}