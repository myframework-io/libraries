using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Myframework.Libraries.Common.Extensions
{
    /// <summary>
    /// Extensões para string.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Verifica se a string é nula ou está em branco usando a função string.IsNullOrWhiteSpace.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);

        /// <summary>
        /// Verifica se a string está vazia.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="removeWhiteSpacesToCheck">Indica se deve remover ou não espaços em branco.</param>
        /// <returns></returns>
        public static bool IsEmpty(this string str, bool removeWhiteSpacesToCheck = false)
        {
            if (str == null)
                return false;

            string strCheck;

            if (removeWhiteSpacesToCheck)
                strCheck = str.Replace(" ", string.Empty);
            else
                strCheck = str;

            return strCheck == string.Empty;
        }

        /// <summary>
        /// Retorna a string respeitando o número máximo de caracteres, ou seja, caso a string tenha mais caracteres do que o máximo informado, será usada a função string.Substring, caso contrário será retornada a string sem alterações.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="maxLength">Máximo de caracteres permitidos.</param>
        /// <returns></returns>
        public static string SubstringIfMaxLength(this string str, int maxLength) => str?.Length > maxLength ? str.Substring(0, maxLength) : str;

        /// <summary>
        /// Coloca a primeira letra em maiúscula.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UpperCaseFirstChar(this string str) => string.IsNullOrEmpty(str) ? str : char.ToUpper(str[0]) + str.Substring(1);

        /// <summary>
        /// Coloca a primeira letra de cada palavra em maiúscula.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string UpperCaseFirstCharEachWord(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            string[] strSplit = str.Split(null);
            string novString = "";

            for (int i = 0; i < strSplit.Length; i++)
            {
                novString += UpperCaseFirstChar(strSplit[i]) + (i == (strSplit.Length - 1) ? "" : " ");
            }

            return novString;
        }

        /// <summary>
        /// Coloca a primeira letra em minúsculo.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string LowerCaseFirstChar(this string str) => string.IsNullOrEmpty(str) ? str : char.ToLower(str[0]) + str.Substring(1);

        /// <summary>
        /// Coloca a primeira letra de cada palavra em minúsculo.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string LowerCaseFirstCharEachWord(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            string[] strSplit = str.Split(null);
            string novString = "";

            for (int i = 0; i < strSplit.Length; i++)
            {
                novString += LowerCaseFirstChar(strSplit[i]) + (i == (strSplit.Length - 1) ? "" : " ");
            }

            return novString;
        }

        /// <summary>
        /// Remove o último caractere.
        /// </summary>
        /// <param name="str"></param>
        public static string RemoveLastChar(this string str) => string.IsNullOrEmpty(str) ? str : str.Remove(str.Length - 1, 1);

        /// <summary>
        /// Remove último caractere informado.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="character"></param>
        /// <param name="caseInsensitive"></param>
        public static string RemoveLastChar(this string str, char character, bool caseInsensitive = false)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            string strCheck = caseInsensitive ? str.ToLower() : str;
            char charCheck = caseInsensitive ? character.ToString().ToLower().First() : character;

            int lastIndex = strCheck.LastIndexOf(charCheck);

            if (lastIndex != -1)
                return str.Remove(lastIndex, 1);

            return str;
        }

        /// <summary>
        /// Normaliza muitos espaços em branco consecutivos em apenas um. Isso inclui a substituição de "\t" por " " (espaço em branco).
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string NormalizeSpaces(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            int indexDelecao = 0;
            int qtdChar = 0;
            bool normalizando = false;

            str = str.Trim();

            str = str.Replace("\t", " ");

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == ' ')
                {
                    if (!normalizando)
                    {
                        normalizando = true;
                        indexDelecao = i;
                        qtdChar = 0;
                    }

                    qtdChar++;
                }
                else if (normalizando)
                {
                    normalizando = false;

                    if (qtdChar > 1)
                    {
                        str = str.Remove(indexDelecao, qtdChar - 1);

                        i = indexDelecao;
                    }
                }
            }

            if (normalizando && qtdChar > 1)
                str = str.Remove(indexDelecao, qtdChar - 1);

            return str;
        }

        /// <summary>
        /// Retorna quantidade de palavras na string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int WordCount(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            int qtd = str.NormalizeSpaces().Count(it => it == ' ') + 1;
            return qtd;
        }

        /// <summary>
        /// Remove a ultima palavra da string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveLastWord(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            int indiceUltimoEspaco = str.Trim().LastIndexOf(" ");

            if (indiceUltimoEspaco == -1)
                return "";

            return str.Substring(0, indiceUltimoEspaco);
        }

        /// <summary>
        /// Remove a última ocorrência da palavra informada.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="word"></param>
        /// <param name="caseInsensitive"></param>
        /// <returns></returns>
        public static string RemoveLastOccurrenceOfWord(this string str, string word, bool caseInsensitive = false)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(word))
                return str;

            string[] split = str.Split(null);

            if (caseInsensitive)
                split = split.Select(it => it?.Trim().ToLower()).ToArray();

            string wordCheck = caseInsensitive ? word?.ToLower().Trim() : word;

            if (split.Contains(wordCheck))
            {
                int lastIndexOf = str.LastIndexOf(wordCheck + " ");

                if (lastIndexOf != -1)
                    return str.Remove(lastIndexOf, wordCheck.Length + 1);

                lastIndexOf = str.LastIndexOf(" " + wordCheck);

                if (lastIndexOf != -1)
                    return str.Remove(lastIndexOf, wordCheck.Length + 1);

                lastIndexOf = str.LastIndexOf(wordCheck);

                return str.Remove(lastIndexOf, wordCheck.Length);
            }

            return str;
        }

        /// <summary>
        /// Verifica se uma string pode ser convertida em um número.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNumber(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            bool retorno = int.TryParse(str, out int testeInteiro);

            if (!retorno)
                return str.IsDecimal();

            return retorno;
        }

        /// <summary>
        /// Verifica se a string é um número decimal.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDecimal(this string str) => string.IsNullOrEmpty(str) ? false : decimal.TryParse(str, out decimal testeDecimal);

        /// <summary>
        /// Verifica se a string é um datetime.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDatetime(this string str) => string.IsNullOrEmpty(str) ? false : DateTime.TryParse(str, out DateTime testeDecimal);

        /// <summary>
        /// Concatena uma lista de strings em uma única string, utilizando o delimitador indicado.
        /// </summary>
        /// <param name="lista"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public static string JoinListInSingleString(this List<string> lista, string delimiter) => lista == null || !lista.Any() ? null : lista.Aggregate((i, j) => i + (delimiter ?? " ") + j);

        /// <summary>
        /// Verifica se a string possui número.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="regexOption"></param>
        /// <returns></returns>
        public static bool HasNumberChars(this string str) => string.IsNullOrWhiteSpace(str) ? false : str.Any(c => char.IsNumber(c));

        /// <summary>
        /// Verifica se a string possui ao menos uma letra maiuscula.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="regexOption"></param>
        /// <returns></returns>
        public static bool HasUppercaseChar(this string str) => string.IsNullOrWhiteSpace(str) ? false : str.Any(c => char.IsUpper(c));

        /// <summary>
        /// Verifica se a string possui ao menos uma letra minuscula.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="regexOption"></param>
        /// <returns></returns>
        public static bool HasLowercaseChar(this string str) => string.IsNullOrWhiteSpace(str) ? false : str.Any(c => char.IsLower(c));

        /// <summary>
        /// Verifica se a string possui ao menos uma letra.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="regexOption"></param>
        /// <returns></returns>
        public static bool HasLetter(this string str) => string.IsNullOrWhiteSpace(str) ? false : str.Any(c => char.IsLetter(c));

        /// <summary>
        /// Verifica se a string possui somente números.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool HasOnlyNumbers(this string str) => string.IsNullOrWhiteSpace(str) ? false : str.Length == str.CountNumbers();

        /// <summary>
        /// Verifica se a string possui somente letras.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool HasOnlyLetters(this string str) => string.IsNullOrWhiteSpace(str) ? false : str.Length == str.CountLetters();

        /// <summary>
        /// Remove caracteres não numéricos.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveNonNumeric(this string str) => new Regex(@"[^0-9]").Replace(str, string.Empty);

        /// <summary>
        /// Compara a string com outra, ignorando acentos e caracterres especiais.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="compareValue"></param>
        /// <param name="removeWhiteSpace"></param>
        /// <param name="removeSpecialCharacters"></param>
        /// <returns></returns>
        public static bool CompareCaseInsensitive(this string str, string compareValue, bool removeWhiteSpace = false, bool removeSpecialCharacters = false)
        {
            str = str?.ToLower().Trim();
            compareValue = compareValue?.ToLower().Trim();

            if (removeWhiteSpace)
            {
                str = str?.Replace(" ", string.Empty);
                compareValue = compareValue?.Replace(" ", string.Empty);
            }

            if (removeSpecialCharacters)
            {
                str = str?.RemoveSpecialCharacters();
                compareValue = compareValue?.RemoveSpecialCharacters();
            }

            return string.Compare(str, compareValue, CultureInfo.CurrentCulture, CompareOptions.IgnoreNonSpace | CompareOptions.IgnoreCase) == 0;
        }

        /// <summary>
        /// Remove preposições de um texto.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="removePrepositionFromBeginAndEnd">Indica se deve remover preposições do começo e fim da frase.</param>        
        /// <returns></returns>
        public static string RemoveBRPrepositions(this string str, bool removePrepositionFromBeginAndEnd = true)
        {
            if (string.IsNullOrEmpty(str))
                return str;

            string[] preposicoesMaiuscula = new[] { "A", "AS", "AO", "ANTES", "APÓS", "ATÉ", "COM", "CONTRA", "DESDE", "ENTRE", "PARA", "PER", "PERANTE", "SEM", "SOB", "SOBRE", "TRAZ", "DE", "DA", "DO", "EM", "NA", "NO", "DOS", "DAS", "AOS", "NAS", "NOS" };
            string[] preposicoesMinuscula = new[] { "a", "as", "ao", "antes", "após", "até", "com", "contra", "desde", "entre", "para", "per", "perante", "sem", "sob", "sobre", "traz", "de", "da", "do", "em", "na", "no", "dos", "das", "aos", "nas", "nos" };

            str = preposicoesMaiuscula.Aggregate(str, (current, preposicao) => current.Replace(" " + preposicao + " ", " "));
            str = preposicoesMinuscula.Aggregate(str, (current, preposicao) => current.Replace(" " + preposicao + " ", " "));

            str = preposicoesMinuscula.Aggregate(str, (current, preposicao) => (current.StartsWith(preposicao + " ") ? current.Remove(0, preposicao.Length + 1) : current));
            str = preposicoesMinuscula.Aggregate(str, (current, preposicao) => (current.StartsWith(preposicao + " ") ? current.Remove(0, preposicao.Length + 1) : current));

            str = preposicoesMinuscula.Aggregate(str, (current, preposicao) => (current.EndsWith(" " + preposicao) ? current.Remove(current.LastIndexOf(preposicao), preposicao.Length) : current));
            str = preposicoesMinuscula.Aggregate(str, (current, preposicao) => (current.EndsWith(" " + preposicao) ? current.Remove(current.LastIndexOf(preposicao), preposicao.Length) : current));

            return str.Trim();
        }

        /// <summary>
        /// Remove caracteres especiais, inclusive acentuação.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(this string input)
        {
            var regex = new Regex("(?:[^a-z0-9A-ZÁÉÍÓÚÂÊÔÀÔÃÇáéíóúâêôàõãç ]|(?<=['\"])s)", RegexOptions.CultureInvariant | RegexOptions.Compiled);
            return regex.Replace(input, string.Empty);
        }

        /// <summary>
        /// Remove os acentos do texto.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveAccents(this string str)
        {
            const string vWithAccent = "ÀÁÂÃÄÅÇÈÉÊËÌÍÎÏÒÓÔÕÖÙÚÛÜàáâãäåçèéêëìíîïòóôõöùúûü";
            const string vWithoutAccent = "AAAAAACEEEEIIIIOOOOOUUUUaaaaaaceeeeiiiiooooouuuu";
            string finalString = "";

            for (int i = 1; (i <= str.Length); i++)
            {
                int vPos = (vWithAccent.IndexOf(str.Substring((i - 1), 1), 0, System.StringComparison.Ordinal) + 1);
                if ((vPos > 0))
                {
                    finalString += vWithoutAccent.Substring((vPos - 1), 1);
                }
                else
                {
                    finalString += str.Substring((i - 1), 1);
                }
            }
            return finalString;
        }

        /// <summary>
        /// Método para comparar strings por similaridade até 2 letras divergentes considerado similar.
        /// </summary>
        /// <param name="str">string atual</param>
        /// <param name="target">string comparativa</param>
        /// <returns>True caso seja similar</returns>
        public static bool ContainSimilarity(this string str, string target)
        {
            if ((str == null) || (target == null)) return false;
            if ((str.Length == 0) || (target.Length == 0)) return false;
            if (str == target) return true;

            int sourceCount = str.Length;
            int targetWordCount = target.Length;

            // Step 1
            if (sourceCount == 0)
                return false;

            if (targetWordCount == 0)
                return false;

            string[] splitWords = str.Split(' ');

            foreach (string word in splitWords)
            {
                int sourceWordCount = word.Length;
                int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

                // Step 2
                for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
                for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

                for (int i = 1; i <= sourceWordCount; i++)
                {
                    for (int j = 1; j <= targetWordCount; j++)
                    {
                        // Step 3
                        int cost = (target[j - 1] == word[i - 1]) ? 0 : 1;

                        // Step 4
                        distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                    }
                }

                if (distance[sourceWordCount, targetWordCount] < 2)
                    return true;
            }

            return false;
        }

        /// <summary>
        /// Tenta realizar o parse da string para data, caso não consiga retornará null.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTime? TryParseToDateTime(this string str) => DateTime.TryParse(str, out DateTime date) ? (DateTime?)date : null;

        /// <summary>
        /// Tenta realizar o parse da string para inteiro, caso não consiga retornará null.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int? TryParseToInt(this string str) => int.TryParse(str, out int number) ? (int?)number : null;

        /// <summary>
        /// Tenta realizar o parse da string para short, caso não consiga retornará null.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int? TryParseToShort(this string str) => short.TryParse(str, out short number) ? (short?)number : null;

        /// <summary>
        /// Tenta realizar o parse da string para long, caso não consiga retornará null.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static long? TryParseToLong(this string str) => long.TryParse(str, out long number) ? (long?)number : null;

        /// <summary>
        /// Tenta realizar o parse da string para byte, caso não consiga retornará null.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte? TryParseToByte(this string str) => byte.TryParse(str, out byte number) ? (byte?)number : null;

        /// <summary>
        /// Tenta realizar o parse da string para decimal, caso não consiga retornará null.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static decimal? TryParseToDecimal(this string str) => decimal.TryParse(str, out decimal number) ? (decimal?)number : null;

        /// <summary>
        /// Tenta realizar o parse da string para float, caso não consiga retornará null.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static float? TryParseToFloat(this string str) => float.TryParse(str, out float number) ? (float?)number : null;

        /// <summary>
        /// Tenta realizar o parse da string para double, caso não consiga retornará null.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static double? TryParseToDouble(this string str) => double.TryParse(str, out double number) ? (double?)number : null;

        /// <summary>
        /// Retorna a quantidade de letras presentes na string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int CountLetters(this string str) => string.IsNullOrWhiteSpace(str) ? 0 : str.Count(c => char.IsLetter(c));

        /// <summary>
        /// Retorna a quantidade de letras maiúsculas presentes na string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int CountUpperCaseChars(this string str) => string.IsNullOrWhiteSpace(str) ? 0 : str.Count(c => char.IsUpper(c));

        /// <summary>
        /// Retorna a quantidade de letras minúsculas presentes na string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int CountLowerCaseChars(this string str) => string.IsNullOrWhiteSpace(str) ? 0 : str.Count(c => char.IsLower(c));

        /// <summary>
        /// Retorna a quantidade de números presentes na string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int CountNumbers(this string str) => string.IsNullOrWhiteSpace(str) ? 0 : str.Count(c => char.IsNumber(c));

        /// <summary>
        /// Retorna a quantidade de carecteres especificados presentes na string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        public static int CountChars(this string str, char character) => string.IsNullOrWhiteSpace(str) ? 0 : str.Count(c => c == character);

        /// <summary>
        /// Retorna a quantidade de carecteres especificados presentes na string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static int CountChars(this string str, params char[] characters) => string.IsNullOrWhiteSpace(str) ? 0 : str.Count(c => characters.Contains(c));

        /// <summary>
        /// Retorna a quantidade de carecteres especificados presentes na string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static int CountChars(this string str, List<char> characters) => string.IsNullOrWhiteSpace(str) ? 0 : str.Count(c => characters.Contains(c));

        /// <summary>
        /// Count repeated chars.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int CountRepeatedChars(this string str) => string.IsNullOrWhiteSpace(str) ? 0 : str.GetRepeatedChars().Sum(it => it.Value);

        /// <summary>
        /// Get repeated chars.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static Dictionary<char, int> GetRepeatedChars(this string str) => string.IsNullOrWhiteSpace(str) ? new Dictionary<char, int>() : str.GroupBy(c => c).Where(c => c.Count() > 1).Select(c => new { c.Key, Value = c.Count() }).ToDictionary(it => it.Key, it => it.Value);

        /// <summary>
        /// Retorna caracteres consecutivos na string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<KeyValuePair<char, int>> GetConsecutiveChars(this string str)
        {
            var repeatedChars = new List<KeyValuePair<char, int>>();

            if (string.IsNullOrWhiteSpace(str))
                return repeatedChars;

            char currentChar;
            char lastChar = '.';
            int repeatCount = 0;

            for (int i = 0; i < str.Length; i++)
            {
                currentChar = str[i];

                if (i == 0)
                {
                    lastChar = currentChar;
                    continue;
                }

                if (currentChar == lastChar)
                    repeatCount = repeatCount == 0 ? 2 : repeatCount + 1;
                else
                {
                    if (repeatCount > 0)
                        repeatedChars.Add(new KeyValuePair<char, int>(lastChar, repeatCount));

                    repeatCount = 0;
                }

                lastChar = currentChar;
            }

            if (repeatCount > 0)
                repeatedChars.Add(new KeyValuePair<char, int>(lastChar, repeatCount));

            return repeatedChars;
        }

        /// <summary>
        /// Retorna caracteres maiúsculos consecutivos na string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> GetConsecutiveUpperCaseChars(this string str) => GetConsecutiveCharsWithCustomRule(str, (currentChar) => char.IsUpper(currentChar));

        /// <summary>
        /// Retorna caracteres minúsculos consecutivos na string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> GetConsecutiveLowerCaseChars(this string str) => GetConsecutiveCharsWithCustomRule(str, (currentChar) => char.IsLower(currentChar));

        /// <summary>
        /// Retorna caracteres, do tipo número, consecutivos na string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> GetConsecutiveNumbersChars(this string str) => GetConsecutiveCharsWithCustomRule(str, (currentChar) => char.IsNumber(currentChar));

        /// <summary>
        /// Retorna caracteres consecutivos usando a função indicada para determinar se um char é consecutivo do outro ou não.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="consecutiveRuleFunc"></param>
        /// <returns></returns>
        public static List<string> GetConsecutiveCharsWithCustomRule(string str, Func<char, bool> consecutiveRuleFunc)
        {
            var repeatedChars = new List<string>();

            if (string.IsNullOrWhiteSpace(str))
                return repeatedChars;

            string consecutiveChars = "";
            char currentChar;
            char lastChar = '.';
            bool currentCharMatchConsecutiveRule = false;
            bool lastCharMatchConsecutiveRule = false;
            int repeatCount = 0;

            for (int i = 0; i < str.Length; i++)
            {
                currentChar = str[i];
                currentCharMatchConsecutiveRule = consecutiveRuleFunc(currentChar);

                if (i == 0)
                {
                    lastChar = currentChar;
                    lastCharMatchConsecutiveRule = currentCharMatchConsecutiveRule;
                    continue;
                }

                if (currentCharMatchConsecutiveRule && lastCharMatchConsecutiveRule)
                {
                    repeatCount = repeatCount == 0 ? 2 : repeatCount + 1;
                    consecutiveChars += string.IsNullOrWhiteSpace(consecutiveChars) ? string.Concat(lastChar, currentChar) : currentChar.ToString();
                }
                else
                {
                    if (repeatCount > 0)
                        repeatedChars.Add(consecutiveChars);

                    repeatCount = 0;
                    consecutiveChars = "";
                    lastCharMatchConsecutiveRule = currentCharMatchConsecutiveRule;
                }

                lastChar = currentChar;
            }

            if (repeatCount > 0)
                repeatedChars.Add(consecutiveChars);

            return repeatedChars;
        }

        /// <summary>
        /// Retorna caracteres, do tipo letra, que são sequência na string. Ex: abcSAASDA => sequencial a-b-c.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="caseInsensitive">Indica se deve levar em consideraçõa letras maiúsculas e minúsculas (false) ou não (true). Padrão: não levar em conta.</param>
        /// <returns></returns>
        public static List<string> GetSequentialLettersChars(this string str, bool caseInsensitive = true) => str.GetSequentialCharsWithCustomRule((currentChar, lastChar) => currentChar.IsSequentialLetterOfChar(lastChar, caseInsensitive));

        /// <summary>
        /// Retorna caracteres, do tipo número, que são sequência na string. Ex: abcSAASDA => sequencial a-b-c.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<string> GetSequentialNumbersChars(this string str) => str.GetSequentialCharsWithCustomRule((currentChar, lastChar) => currentChar.IsSequentialNumberOfChar(lastChar));

        /// <summary>
        /// Retorna caracteres sequenciais usando a função indicada para determinar se um char é sequência do outro ou não.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isSequentialFunc"></param>
        /// <returns></returns>
        public static List<string> GetSequentialCharsWithCustomRule(this string str, Func<char, char, bool> isSequentialFunc)
        {
            var repeatedChars = new List<string>();

            if (string.IsNullOrWhiteSpace(str))
                return repeatedChars;

            string consecutiveChars = "";
            char currentChar;
            char lastChar = '.';
            bool currentCharIsSequenceOfLast = false;
            int repeatCount = 0;

            for (int i = 0; i < str.Length; i++)
            {
                currentChar = str[i];

                if (i == 0)
                {
                    lastChar = currentChar;
                    continue;
                }

                currentCharIsSequenceOfLast = isSequentialFunc(currentChar, lastChar);

                if (currentCharIsSequenceOfLast)
                {
                    repeatCount = repeatCount == 0 ? 2 : repeatCount + 1;
                    consecutiveChars += string.IsNullOrWhiteSpace(consecutiveChars) ? string.Concat(lastChar, currentChar) : currentChar.ToString();
                }
                else
                {
                    if (repeatCount > 0)
                        repeatedChars.Add(consecutiveChars);

                    repeatCount = 0;
                    consecutiveChars = "";
                    currentCharIsSequenceOfLast = false;
                }

                lastChar = currentChar;
            }

            if (repeatCount > 0)
                repeatedChars.Add(consecutiveChars);

            return repeatedChars;
        }

        /// <summary>
        /// Retorna quantidade de caracteres consecutivos na string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int CountConsecutiveChars(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;

            List<KeyValuePair<char, int>> consecutives = str.GetConsecutiveChars();
            return consecutives.Sum(it => it.Value);
        }

        /// <summary>
        /// Retorna quantidade do caracter consecutivos na string.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="character"></param>
        /// <returns></returns>
        public static int CountConsecutiveChar(this string str, char character)
        {
            if (string.IsNullOrWhiteSpace(str))
                return 0;

            List<KeyValuePair<char, int>> consecutives = str.GetConsecutiveChars();
            return consecutives.Where(it => it.Key == character).Sum(it => it.Value);
        }

        /// <summary>
        /// Retorna caracteres maiúsculos consecutivos na string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int CountConsecutiveUpperCaseChars(this string str) => string.IsNullOrWhiteSpace(str) ? 0 : str.GetConsecutiveUpperCaseChars().Sum(it => it.Length);

        /// <summary>
        /// Retorna quantidade de caracteres minúsculos consecutivos na string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int CountConsecutiveLowerCaseChars(this string str) => string.IsNullOrWhiteSpace(str) ? 0 : str.GetConsecutiveLowerCaseChars().Sum(it => it.Length);

        /// <summary>
        /// Retorna a quantidade de caracteres, do tipo número, consecutivos na string.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int CountConsecutiveNumbersChars(this string str) => string.IsNullOrWhiteSpace(str) ? 0 : str.GetConsecutiveNumbersChars().Sum(it => it.Length);

        /// <summary>
        /// Retorna a quantidade de caracteres, do tipo letra, que são sequência na string. Ex: abcSAASDA => sequencial a-b-c.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="caseInsensitive">Indica se deve levar em consideraçõa letras maiúsculas e minúsculas (false) ou não (true). Padrão: não levar em conta.</param>
        /// <returns></returns>
        public static int CountSequentialLettersChars(this string str, bool caseInsensitive = true) => string.IsNullOrWhiteSpace(str) ? 0 : str.GetSequentialLettersChars(caseInsensitive).Sum(it => it.Length);

        /// <summary>
        /// Retorna a quantidade de caracteres, do tipo número, que são sequência na string. Ex: abcSAASDA => sequencial a-b-c.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int CountSequentialNumbersChars(this string str) => string.IsNullOrWhiteSpace(str) ? 0 : str.GetSequentialNumbersChars().Sum(it => it.Length);

        /// <summary>
        /// Indica se o caractere, do tipo letra, é sequência do caractere anterior, também do tipo letra.
        /// </summary>
        /// <param name="currentChar">Caracterer que deveria ser sequencia do outro caracterer (compareChar).</param>
        /// <param name="compareChar"></param>
        /// <param name="caseInsensitive">Indica se deve levar em consideraçõa letras maiúsculas e minúsculas (false) ou não (true). Padrão: não levar em conta.</param>
        /// <returns></returns>
        public static bool IsSequentialLetterOfChar(this char currentChar, char compareChar, bool caseInsensitive = true)
        {
            if (!char.IsLetter(compareChar) || !char.IsLetter(currentChar))
                return false;

            if (caseInsensitive)
                return char.ToUpper(currentChar) == (char.ToUpper(compareChar) + 1);
            else
                return currentChar == (compareChar + 1);
        }

        /// <summary>
        /// Indica se o caractere, do tipo número, é sequência do caractere anterior, também do tipo número.
        /// </summary>
        /// <param name="currentChar">Caracterer que deveria ser sequencia do outro caracterer (compareChar).</param>
        /// <param name="compareChar"></param>
        /// <returns></returns>
        public static bool IsSequentialNumberOfChar(this char currentChar, char compareChar)
        {
            if (!char.IsNumber(compareChar) || !char.IsNumber(currentChar))
                return false;

            return currentChar == (compareChar + 1);
        }
    }
}