using Myframework.Libraries.Common.Extensions;
using System.Collections.Generic;
using Xunit;

namespace Common.Extension
{
    public class StringExtensionsTests
    {
        [Theory(DisplayName = "Is null or white space")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("       ")]
        public void IsNullOrWhiteSpace(string value) => Assert.True(value.IsNullOrWhiteSpace());

        [Theory(DisplayName = "Is not null or white space")]
        [InlineData("adfsasf")]
        [InlineData("   a    ")]
        public void IsNotNullOrWhiteSpace(string value) => Assert.False(value.IsNullOrWhiteSpace());

        [Theory(DisplayName = "Is empty")]
        [InlineData("")]
        public void IsEmpty(string value) => Assert.True(value.IsEmpty());

        [Theory(DisplayName = "Is not empty")]
        [InlineData("adfsasf")]
        [InlineData("   a    ")]
        [InlineData(null)]
        [InlineData("       ")]
        public void IsNotEmpty(string value) => Assert.False(value.IsEmpty());

        [Theory(DisplayName = "Substring max length")]
        [InlineData(null, 7, null)]
        [InlineData("", 7, "")]
        [InlineData("     ", 7, "     ")]
        [InlineData("Abcdefg", 7, "Abcdefg")]
        [InlineData("Abcdefghijklm", 7, "Abcdefg")]
        [InlineData("Abcde   fghij   klm", 7, "Abcde  ")]
        public void SubstringIfMaxLength(string value, int maxLength, string expectedValue) => Assert.Equal(expectedValue, value.SubstringIfMaxLength(maxLength));

        [Theory(DisplayName = "Upper case first char")]
        [InlineData(null, null)]
        [InlineData("uppercase fRAse", "Uppercase fRAse")]
        [InlineData("Uppercase fRAse", "Uppercase fRAse")]
        [InlineData(" Uppercase fRAse", " Uppercase fRAse")]
        [InlineData(" uppercase fRAse", " uppercase fRAse")]
        public void UpperCaseFirstChar(string value, string expectedValue) => Assert.Equal(expectedValue, value.UpperCaseFirstChar());

        [Theory(DisplayName = "Upper case first char of each word")]
        [InlineData(null, null)]
        [InlineData("uppercase fRAse xxxx", "Uppercase FRAse Xxxx")]
        [InlineData("Uppercase FRAse ZZz", "Uppercase FRAse ZZz")]
        [InlineData("uppercase FRAse zZz", "Uppercase FRAse ZZz")]
        [InlineData(" zppercase fRAse", " Zppercase FRAse")]
        public void UpperCaseFirstCharEachWord(string value, string expectedValue) => Assert.Equal(expectedValue, value.UpperCaseFirstCharEachWord());

        [Theory(DisplayName = "Lower case first char")]
        [InlineData(null, null)]
        [InlineData("Lowercase FRAse", "lowercase FRAse")]
        [InlineData("lowercase FRAse", "lowercase FRAse")]
        [InlineData(" lowercase FRAse", " lowercase FRAse")]
        [InlineData(" Lowercase FRAse", " Lowercase FRAse")]
        public void LowerCaseFirstChar(string value, string expectedValue) => Assert.Equal(expectedValue, value.LowerCaseFirstChar());

        [Theory(DisplayName = "Lower case first char of each word")]
        [InlineData(null, null)]
        [InlineData("Lowercase fRAse xxxx", "lowercase fRAse xxxx")]
        [InlineData("lowercase FRAse ZZz", "lowercase fRAse zZz")]
        [InlineData("Lowercase FRAse zZz", "lowercase fRAse zZz")]
        [InlineData(" Zppercase FRAse", " zppercase fRAse")]
        public void LowerCaseFirstCharEachWord(string value, string expectedValue) => Assert.Equal(expectedValue, value.LowerCaseFirstCharEachWord());

        [Theory(DisplayName = "Remove last char")]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("adfsasf", "adfsas")]
        [InlineData("adfsasf  AAADDVB2", "adfsasf  AAADDVB")]
        [InlineData("adfsasf ", "adfsasf")]
        public void RemoveLastChar(string value, string expectedValue) => Assert.Equal(expectedValue, value.RemoveLastChar());

        [Theory(DisplayName = "Remove last specifc char")]
        [InlineData(null, 'a', null)]
        [InlineData("adaaafsasf", 'a', "adaaafssf")]
        [InlineData("adfsaVsf  AAADDvB2", 'v', "adfsaVsf  AAADDB2")]
        [InlineData("adfsaVsf  AAADDvB2", 'V', "adfsasf  AAADDvB2")]
        [InlineData("adfsaVsf  AAADDvB2", 'j', "adfsaVsf  AAADDvB2")]
        [InlineData(null, 'a', null, true)]
        [InlineData("adaaafsasf", 'a', "adaaafssf", true)]
        [InlineData("adfsaVsf  AAADDvB2", 'v', "adfsaVsf  AAADDB2", true)]
        [InlineData("adfsaVsf  AAADDvB2", 'V', "adfsaVsf  AAADDB2", true)]
        [InlineData("adfsaVsf  AAADDvB2", 'J', "adfsaVsf  AAADDvB2", true)]
        public void RemoveLastSpecifcChar(string value, char charToRemove, string expectedValue, bool caseInsensitive = false) => Assert.Equal(expectedValue, value.RemoveLastChar(charToRemove, caseInsensitive));

        [Theory(DisplayName = "Normalize spaces")]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("adfs     as   f   123213213 4466", "adfs as f 123213213 4466")]
        public void NormalizeSpaces(string value, string expectedValue) => Assert.Equal(expectedValue, value.NormalizeSpaces());

        [Theory(DisplayName = "Remove last word")]
        [InlineData(null, null)]
        [InlineData("", "")]
        [InlineData("Afsdfsdabc", "")]
        [InlineData("Afsdfsd abc", "Afsdfsd")]
        [InlineData("Afsdfsd aBC", "Afsdfsd")]
        public void RemoveLastWord(string value, string expectedValue) => Assert.Equal(expectedValue, value.RemoveLastWord());

        [Theory(DisplayName = "Word count")]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("Afsdfsdabc", 1)]
        [InlineData("Afsdfsd abc", 2)]
        [InlineData("Afsdfsd aBC a | rrrr@asf", 5)]
        public void WordCount(string value, int count) => Assert.Equal(count, value.WordCount());

        [Theory(DisplayName = "Remove last occurrence of word")]
        [InlineData(null, "abc", null)]
        [InlineData("", "abc", "")]
        [InlineData("Afsdfsdabc", "abc", "Afsdfsdabc")]
        [InlineData("Afsdfsd abc abC", "abC", "Afsdfsd abc")]
        [InlineData("Afsdfsd aBC aBc", "aBc", "Afsdfsd aBC")]
        [InlineData("Afsdfsd aBC ABC", "ABC", "Afsdfsd aBC")]
        [InlineData("Afsdfsd aBC ABC ", "ABC", "Afsdfsd aBC ")]
        [InlineData("Afsdfsd ABC aBC", "aBC", "Afsdfsd ABC")]
        [InlineData("Afsdfsd aBC aBc", null, "Afsdfsd aBC aBc")]
        public void RemoveLastOccurrenceOfWord(string value, string wordToRemove, string expectedValue) => Assert.Equal(expectedValue, value.RemoveLastOccurrenceOfWord(wordToRemove));

        [Theory(DisplayName = "Join list in single string")]
        [InlineData(null, "abc def ghi")]
        [InlineData(" ", "abc def ghi")]
        [InlineData("", "abcdefghi")]
        [InlineData(",", "abc,def,ghi")]
        [InlineData(", ", "abc, def, ghi")]
        public void JoinListInSingleString(string delimiter, string expectedValue)
        {
            var list = new List<string> { "abc", "def", "ghi" };
            Assert.Equal(expectedValue, list.JoinListInSingleString(delimiter));
        }

        [Theory(DisplayName = "Join list (empty) in single string")]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData(",")]
        [InlineData(", ")]
        public void JoinEmptyListInSingleString(string delimiter) => Assert.Null(new List<string>().JoinListInSingleString(delimiter));

        [Theory(DisplayName = "Join list (null) in single string")]
        [InlineData(null)]
        [InlineData(" ")]
        [InlineData("")]
        [InlineData(",")]
        [InlineData(", ")]
        public void JoinNullListInSingleString(string delimiter) => Assert.Null(((List<string>)null).JoinListInSingleString(delimiter));

        [Theory(DisplayName = "Is number")]
        [InlineData("5")]
        [InlineData("5.1")]
        [InlineData("5,6")]
        [InlineData("500.000")]
        public void IsNumber(string value) => Assert.True(value.IsNumber());

        [Theory(DisplayName = "Is not number")]
        [InlineData("5a")]
        [InlineData("asad")]
        public void IsNotNumber(string value) => Assert.False(value.IsNumber());

        [Theory(DisplayName = "Is decimal")]
        [InlineData("5")]
        [InlineData("5.1")]
        [InlineData("5,6")]
        [InlineData("500.000")]
        public void IsDecimal(string value) => Assert.True(value.IsNumber());

        [Theory(DisplayName = "Is not decimal")]
        [InlineData("5a")]
        [InlineData("asad")]
        public void IsNotDecimal(string value) => Assert.False(value.IsNumber());

        [Theory(DisplayName = "Is DateTime")]
        [InlineData("2018/08/16")]
        [InlineData("16/08/1987")]
        [InlineData("16/08/87")]
        public void IsDatetime(string value) => Assert.True(value.IsDatetime());

        [Theory(DisplayName = "Is not DateTime")]
        [InlineData("00/08/87")]
        [InlineData("00/08")]
        [InlineData("asdd")]
        public void IsNotDatetime(string value) => Assert.False(value.IsDatetime());

        [Theory(DisplayName = "Has number char")]
        [InlineData("5")]
        [InlineData("a5")]
        [InlineData("5.abc1")]
        [InlineData("asdsad5,dgf6d")]
        [InlineData("a500a.000")]
        public void HasNumberChars(string value) => Assert.True(value.HasNumberChars());

        [Theory(DisplayName = "Has no number char")]
        [InlineData("a")]
        [InlineData("A ADXSDA")]
        public void HasNoNumberChars(string value) => Assert.False(value.HasNumberChars());

        [Theory(DisplayName = "Has uppercase char")]
        [InlineData("A5")]
        [InlineData("5A")]
        [InlineData("5.aBc1")]
        [InlineData("asdsCd5,dgf6d")]
        [InlineData("a500D.000")]
        public void HasUppercaseChar(string value) => Assert.True(value.HasUppercaseChar());

        [Theory(DisplayName = "Has no uppercase char")]
        [InlineData("a")]
        [InlineData("a adxsda")]
        public void HasNoUppercaseChar(string value) => Assert.False(value.HasUppercaseChar());

        [Theory(DisplayName = "Has lower char")]
        [InlineData("a5")]
        [InlineData("5a")]
        [InlineData("5.aBc1")]
        [InlineData("asdsCd5,dgf6d")]
        [InlineData("A500d.000")]
        public void HasLowercaseChar(string value) => Assert.True(value.HasLowercaseChar());

        [Theory(DisplayName = "Has no lower char")]
        [InlineData("A")]
        [InlineData("A ADXSDA")]
        public void HasNoLowercaseChar(string value) => Assert.False(value.HasLowercaseChar());

        [Theory(DisplayName = "Remove non numeric")]
        [InlineData("a5", "5")]
        [InlineData("5A", "5")]
        [InlineData("5.aBc1", "51")]
        [InlineData("asdsCd5,dgf6d", "56")]
        [InlineData("A500d.000", "500000")]
        [InlineData("A", "")]
        [InlineData("A ADXSDA", "")]
        public void RemoveNonNumeric(string value, string expectedValue) => Assert.Equal(expectedValue, value.RemoveNonNumeric());

        [Theory(DisplayName = "Compare case insensitive")]
        [InlineData("á5", "A5")]
        [InlineData("5Ó", "5o")]
        [InlineData("5.ãBù1", "5.abu1")]
        [InlineData("asdsÇd5,dgf6d", "asdsCd5,dgf6d")]
        public void CompareCaseInsensitive(string value, string compareValue) => Assert.True(value.CompareCaseInsensitive(compareValue));

        [Theory(DisplayName = "Count letters")]
        [InlineData("A5546546FfvxCzG", 8)]
        [InlineData(" @ a   F  ", 2)]
        [InlineData(" @ 123 44 ", 0)]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("     ", 0)]
        public void CountLetters(string value, int expectedValue) => Assert.Equal(expectedValue, value.CountLetters());

        [Theory(DisplayName = "Count lower case chars")]
        [InlineData("A5546546FfvxCzG", 4)]
        [InlineData(" @ a   F  ", 1)]
        [InlineData(" @ 123 44 ", 0)]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("     ", 0)]
        public void CountLowerCaseChars(string value, int expectedValue) => Assert.Equal(expectedValue, value.CountLowerCaseChars());

        [Theory(DisplayName = "Count upper case chars")]
        [InlineData("A5H546546FfvxCzG", 5)]
        [InlineData("  @   F  ", 1)]
        [InlineData("  123 44 ", 0)]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("     ", 0)]
        public void CountUpperCaseChars(string value, int expectedValue) => Assert.Equal(expectedValue, value.CountUpperCaseChars());

        [Theory(DisplayName = "Count numbers")]
        [InlineData("A5H546546FfvxCzG0", 8)]
        [InlineData("     F  ", 0)]
        [InlineData("  123 44 ", 5)]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("     ", 0)]
        public void CountNumbers(string value, int expectedValue) => Assert.Equal(expectedValue, value.CountNumbers());

        [Theory(DisplayName = "Count chars")]
        [InlineData(null, 'a', 0)]
        [InlineData("", 'a', 0)]
        [InlineData("    ", 'a', 0)]
        [InlineData("A1BaDJKVYaKL123a    ", 'a', 3)]
        [InlineData("A1BaDJKVY@aKL123a    ", '@', 1)]
        [InlineData("A1BaDJKVY@aKL123a    ", '1', 2)]
        public void CountChars(string value, char chartToCount, int expectedValue) => Assert.Equal(expectedValue, value.CountChars(chartToCount));

        [Theory(DisplayName = "Count chars params")]
        [InlineData(null, 'a', 'b', 0)]
        [InlineData("", 'a', 'b', 0)]
        [InlineData("    ", 'a', 'b', 0)]
        [InlineData("A1BaDJKVYaKL123a    ", 'a', 'B', 4)]
        [InlineData("A1BaDJKVY@aKL123a    ", '@', 'K', 3)]
        [InlineData("A1BaDJKVY@aKL123a    ", '1', 'K', 4)]
        public void CountCharsParams(string value, char firstCharToCount, char secondCharToCount, int expectedValue) => Assert.Equal(expectedValue, value.CountChars(firstCharToCount, secondCharToCount));

        [Theory(DisplayName = "Count chars list")]
        [InlineData(null, 'a', 'b', 0)]
        [InlineData("", 'a', 'b', 0)]
        [InlineData("    ", 'a', 'b', 0)]
        [InlineData("A1BaDJKVYaKL123a    ", 'a', 'B', 4)]
        [InlineData("A1BaDJKVY@aKL123a    ", '@', 'K', 3)]
        [InlineData("A1BaDJKVY@aKL123a    ", '1', 'K', 4)]
        public void CountCharsList(string value, char firstCharToCount, char secondCharToCount, int expectedValue) => Assert.Equal(expectedValue, value.CountChars(new List<char> { firstCharToCount, secondCharToCount }));

        [Theory(DisplayName = "Count repeated chars")]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("   ", 0)]
        [InlineData("abc", 0)]
        [InlineData(" abc ", 2)]
        [InlineData("1134456", 4)]
        public void CountRepeatedChars(string value, int expectedValue) => Assert.Equal(expectedValue, value.CountRepeatedChars());

        [Theory(DisplayName = "Has only numbers")]
        [InlineData("23131")]
        [InlineData("888")]
        [InlineData("0")]
        public void HasOnlyNumbers(string value) => Assert.True(value.HasOnlyNumbers());

        [Theory(DisplayName = "Has not only numbers")]
        [InlineData(" 1 ")]
        [InlineData("231a31")]
        [InlineData("a888")]
        [InlineData("a")]
        [InlineData("-1")]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(null)]
        public void HasNotOnlyNumbers(string value) => Assert.False(value.HasOnlyNumbers());

        [Theory(DisplayName = "Has only letters")]
        [InlineData("asdsadsad")]
        [InlineData("dadsad")]
        [InlineData("a")]
        public void HasOnlyLetters(string value) => Assert.True(value.HasOnlyLetters());

        [Theory(DisplayName = "Has not only letters")]
        [InlineData(" a ")]
        [InlineData("a888")]
        [InlineData("1")]
        [InlineData("@a")]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(null)]
        public void HasNotOnlyLetters(string value) => Assert.False(value.HasOnlyLetters());

        [Theory(DisplayName = "Consecutive chars")]
        [MemberData(nameof(ConsecutiveCharsCases.Cases), MemberType = typeof(ConsecutiveCharsCases))]
        public void ConsecutiveChars(string value, params KeyValuePair<char, int>[] expectedConsecutiveChars)
        {
            List<KeyValuePair<char, int>> consecutiveChars = value.GetConsecutiveChars();

            Assert.Equal(consecutiveChars.Count, expectedConsecutiveChars.Length);

            for (int i = 0; i < consecutiveChars.Count; i++)
            {
                Assert.Equal(consecutiveChars[i].Key, expectedConsecutiveChars[i].Key);
                Assert.Equal(consecutiveChars[i].Value, expectedConsecutiveChars[i].Value);
            }
        }

        [Theory(DisplayName = "Count consecutive chars")]
        [InlineData("aaaabbbbccccc", 13)]
        [InlineData("abc", 0)]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("    ", 0)]
        [InlineData("abacaababababc@cc@cc", 6)]
        [InlineData("abaca ababababc@c c@c c", 0)]
        public void CountConsecutiveChars(string value, int expected) => Assert.Equal(expected, value.CountConsecutiveChars());

        [Theory(DisplayName = "Count consecutive char")]
        [InlineData("aaaabbbbccccc", 'a', 4)]
        [InlineData("abc", 'a', 0)]
        [InlineData(null, 'a', 0)]
        [InlineData("", 'a', 0)]
        [InlineData("    ", 'a', 0)]
        [InlineData("abacaababababc@cc@cc", 'c', 4)]
        public void CountConsecutiveChar(string value, char character, int expected) => Assert.Equal(expected, value.CountConsecutiveChar(character));

        [Theory(DisplayName = "Consecutive upper chars")]
        [MemberData(nameof(ConsecutiveUpperCharsCases.Cases), MemberType = typeof(ConsecutiveUpperCharsCases))]
        public void ConsecutiveUpperChars(string value, params string[] expectedConsecutiveChars)
        {
            List<string> consecutiveChars = value.GetConsecutiveUpperCaseChars();

            Assert.Equal(consecutiveChars.Count, expectedConsecutiveChars.Length);

            for (int i = 0; i < consecutiveChars.Count; i++)
            {
                Assert.Equal(consecutiveChars[i], expectedConsecutiveChars[i]);
                Assert.Equal(consecutiveChars[i], expectedConsecutiveChars[i]);
            }
        }

        [Theory(DisplayName = "Count consecutive upper case chars")]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("    ", 0)]
        [InlineData("aaABCDAAbbbbccCCc", 8)]
        [InlineData("abacABbabababc@C C@OE", 4)]
        public void CountConsecutiveUpperCaseChars(string value, int expected) => Assert.Equal(expected, value.CountConsecutiveUpperCaseChars());

        [Theory(DisplayName = "Consecutive lower chars")]
        [MemberData(nameof(ConsecutiveLowerCharsCases.Cases), MemberType = typeof(ConsecutiveLowerCharsCases))]
        public void ConsecutiveLowerChars(string value, params string[] expectedConsecutiveChars)
        {
            List<string> consecutiveChars = value.GetConsecutiveLowerCaseChars();

            Assert.Equal(consecutiveChars.Count, expectedConsecutiveChars.Length);

            for (int i = 0; i < consecutiveChars.Count; i++)
            {
                Assert.Equal(consecutiveChars[i], expectedConsecutiveChars[i]);
                Assert.Equal(consecutiveChars[i], expectedConsecutiveChars[i]);
            }
        }

        [Theory(DisplayName = "Get consecutive lower case chars")]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("    ", 0)]
        [InlineData("AAabcdaaBBBBCCccC", 8)]
        [InlineData("ABACabBABABABC@c c@oe", 4)]
        public void CountConsecutiveLowerCaseChars(string value, int expected) => Assert.Equal(expected, value.CountConsecutiveLowerCaseChars());

        [Theory(DisplayName = "Get consecutive numbers chars")]
        [MemberData(nameof(ConsecutiveNumberCases.Cases), MemberType = typeof(ConsecutiveNumberCases))]
        public void GetConsecutiveNumbersChars(string value, params string[] expectedConsecutiveChars)
        {
            List<string> consecutiveChars = value.GetConsecutiveNumbersChars();

            Assert.Equal(consecutiveChars.Count, expectedConsecutiveChars.Length);

            for (int i = 0; i < consecutiveChars.Count; i++)
            {
                Assert.Equal(consecutiveChars[i], expectedConsecutiveChars[i]);
                Assert.Equal(consecutiveChars[i], expectedConsecutiveChars[i]);
            }
        }

        [Theory(DisplayName = "Count consecutive numbers chars")]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("    ", 0)]
        [InlineData("123abcdaa11467CC98C", 10)]
        [InlineData("ABAC34BABABABC@c c@88", 4)]
        public void CountConsecutiveNumberChars(string value, int expected) => Assert.Equal(expected, value.CountConsecutiveNumbersChars());

        [Theory(DisplayName = "Is sequential letter case insensitive")]
        [InlineData('b', 'a')]
        [InlineData('c', 'b')]
        [InlineData('d', 'c')]
        [InlineData('e', 'd')]
        [InlineData('f', 'e')]
        [InlineData('g', 'f')]
        [InlineData('h', 'g')]
        [InlineData('i', 'h')]
        [InlineData('j', 'i')]
        [InlineData('k', 'j')]
        [InlineData('l', 'k')]
        [InlineData('m', 'l')]
        [InlineData('n', 'm')]
        [InlineData('o', 'n')]
        [InlineData('p', 'o')]
        [InlineData('q', 'p')]
        [InlineData('r', 'q')]
        [InlineData('s', 'r')]
        [InlineData('t', 's')]
        [InlineData('u', 't')]
        [InlineData('v', 'u')]
        [InlineData('w', 'v')]
        [InlineData('x', 'w')]
        [InlineData('y', 'x')]
        [InlineData('z', 'y')]
        [InlineData('B', 'a')]
        [InlineData('b', 'A')]
        [InlineData('B', 'A')]
        public void IsSequentialLetterOfCharCaseInsensitive(char value, char compareChar) => Assert.True(value.IsSequentialLetterOfChar(compareChar));

        [Theory(DisplayName = "Is not sequential letter case insensitive")]
        [InlineData('a', 'a')]
        [InlineData('a', 'z')]
        [InlineData('a', 'b')]
        [InlineData('b', 'c')]
        [InlineData('c', 'd')]
        [InlineData('d', 'e')]
        [InlineData('e', 'f')]
        [InlineData('E', 'f')]
        [InlineData('E', 'F')]
        [InlineData('e', 'F')]
        public void IsNotSequentialLetterOfCharCaseInsensitive(char value, char compareChar) => Assert.False(value.IsSequentialLetterOfChar(compareChar));

        [Theory(DisplayName = "Is sequential letter case sensitive")]
        [InlineData('b', 'a')]
        [InlineData('B', 'A')]
        [InlineData('c', 'b')]
        [InlineData('d', 'c')]
        [InlineData('e', 'd')]
        [InlineData('f', 'e')]
        [InlineData('g', 'f')]
        [InlineData('h', 'g')]
        [InlineData('i', 'h')]
        [InlineData('j', 'i')]
        [InlineData('k', 'j')]
        [InlineData('l', 'k')]
        [InlineData('m', 'l')]
        [InlineData('n', 'm')]
        [InlineData('o', 'n')]
        [InlineData('p', 'o')]
        [InlineData('q', 'p')]
        [InlineData('r', 'q')]
        [InlineData('s', 'r')]
        [InlineData('t', 's')]
        [InlineData('u', 't')]
        [InlineData('v', 'u')]
        [InlineData('w', 'v')]
        [InlineData('x', 'w')]
        [InlineData('y', 'x')]
        [InlineData('z', 'y')]
        [InlineData('Z', 'Y')]
        public void IsSequentialLetterOfCharCaseSensitive(char value, char compareChar) => Assert.True(value.IsSequentialLetterOfChar(compareChar, false));

        [Theory(DisplayName = "Is not sequential letter case sensitive")]
        [InlineData('a', 'z')]
        [InlineData('a', 'a')]
        [InlineData('a', 'b')]
        [InlineData('b', 'c')]
        [InlineData('c', 'd')]
        [InlineData('d', 'e')]
        [InlineData('e', 'f')]
        [InlineData('E', 'f')]
        [InlineData('E', 'F')]
        [InlineData('e', 'F')]
        [InlineData('B', 'a')]
        [InlineData('b', 'A')]
        public void IsNotSequentialLetterOfCharCaseSensitive(char value, char compareChar) => Assert.False(value.IsSequentialLetterOfChar(compareChar, false));

        [Theory(DisplayName = "Is sequential number char")]
        [InlineData('1', '0')]
        [InlineData('2', '1')]
        [InlineData('3', '2')]
        [InlineData('4', '3')]
        [InlineData('5', '4')]
        [InlineData('6', '5')]
        [InlineData('7', '6')]
        [InlineData('8', '7')]
        [InlineData('9', '8')]

        public void IsSequentialNumberOfChar(char value, char compareChar) => Assert.True(value.IsSequentialNumberOfChar(compareChar));

        [Theory(DisplayName = "Is not sequential number char")]
        [InlineData('0', '9')]
        [InlineData('1', '2')]
        [InlineData('4', '4')]
        public void IsNotSequentialNumberOfChar(char value, char compareChar) => Assert.False(value.IsSequentialNumberOfChar(compareChar));

        [Theory(DisplayName = "Get sequential letters chars case insensitive")]
        [MemberData(nameof(SequentialLettersCases.CasesInsensitives), MemberType = typeof(SequentialLettersCases))]
        public void GetSequentialLettersCharsCaseInsensitive(string value, params string[] expectedConsecutiveChars)
        {
            List<string> consecutiveChars = value.GetSequentialLettersChars();

            Assert.Equal(consecutiveChars.Count, expectedConsecutiveChars.Length);

            for (int i = 0; i < consecutiveChars.Count; i++)
            {
                Assert.Equal(consecutiveChars[i], expectedConsecutiveChars[i]);
                Assert.Equal(consecutiveChars[i], expectedConsecutiveChars[i]);
            }
        }

        [Theory(DisplayName = "Get sequential letters chars case sensitive")]
        [MemberData(nameof(SequentialLettersCases.CasesSensitives), MemberType = typeof(SequentialLettersCases))]
        public void GetSequentialLettersCharsCaseSensitive(string value, params string[] expectedConsecutiveChars)
        {
            List<string> consecutiveChars = value.GetSequentialLettersChars(false);

            Assert.Equal(consecutiveChars.Count, expectedConsecutiveChars.Length);

            for (int i = 0; i < consecutiveChars.Count; i++)
            {
                Assert.Equal(consecutiveChars[i], expectedConsecutiveChars[i]);
                Assert.Equal(consecutiveChars[i], expectedConsecutiveChars[i]);
            }
        }

        [Theory(DisplayName = "Count sequential letters chars case insensitive")]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("    ", 0)]
        [InlineData("IGAÇLJODA", 0)]
        [InlineData("123abcdakl11467CEFGC98C", 9)]
        [InlineData("AbCd34BABABABC@c c@88", 11)]
        [InlineData("AbCABcd34BABABABC@c c@Mn", 16)]
        public void CountSequentialLettersCharsCaseInsensitive(string value, int expected) => Assert.Equal(expected, value.CountSequentialLettersChars());

        [Theory(DisplayName = "Count sequential letters chars case sensitive")]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("    ", 0)]
        [InlineData("IGAÇLJODA", 0)]
        [InlineData("123abcdakl11467CEFGC98C", 9)]
        [InlineData("AbCd34BABABABC@c c@88", 7)]
        [InlineData("AbCABcd34BABABABC@c c@Mn", 11)]
        public void CountSequentialLettersCharsCaseSensitive(string value, int expected) => Assert.Equal(expected, value.CountSequentialLettersChars(false));

        [Theory(DisplayName = "Get sequential numbers chars")]
        [MemberData(nameof(SequentialNumbersCases.Cases), MemberType = typeof(SequentialNumbersCases))]
        public void GetSequentialNumbersCharsCaseInsensitive(string value, params string[] expectedConsecutiveChars)
        {
            List<string> consecutiveChars = value.GetSequentialNumbersChars();

            Assert.Equal(consecutiveChars.Count, expectedConsecutiveChars.Length);

            for (int i = 0; i < consecutiveChars.Count; i++)
            {
                Assert.Equal(consecutiveChars[i], expectedConsecutiveChars[i]);
                Assert.Equal(consecutiveChars[i], expectedConsecutiveChars[i]);
            }
        }

        [Theory(DisplayName = "Count sequential numbers chars")]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("    ", 0)]
        [InlineData("IGAÇLJODA", 0)]
        [InlineData("123abcdakl11467CEFGC98C", 5)]
        [InlineData("AbCd34BAB46A8B9A01BC@c c@88", 4)]
        [InlineData("123456AbC78ABcd34BAB0011223344ABABC@c c@Mn", 18)]
        public void CountSequentialNumbersCharsCaseInsensitive(string value, int expected) => Assert.Equal(expected, value.CountSequentialNumbersChars());
    }

    public class ConsecutiveCharsCases
    {
        public static IEnumerable<object[]> Cases =>
            new List<object[]>
            {
                new object[]{ "aaaabbbbccccc", new KeyValuePair<char, int>('a', 4), new KeyValuePair<char, int>('b', 4), new KeyValuePair<char, int>('c', 5), },
                new object[]{ "abc" },
                new object[]{ null },
                new object[]{ "" },
                new object[]{ "    " },
                new object[]{ "abacaababababc@cc@cc", new KeyValuePair<char, int>('a', 2), new KeyValuePair<char, int>('c', 2), new KeyValuePair<char, int>('c', 2), },
            };
    }

    public class ConsecutiveUpperCharsCases
    {
        public static IEnumerable<object[]> Cases =>
            new List<object[]>
            {
                new object[]{ "aaABCDAAbbbbccCCc", "ABCDAA", "CC" },
                new object[]{ "aaaabbbbccccc" },
                new object[]{ "abc" },
                new object[]{ null },
                new object[]{ "" },
                new object[]{ "    " },
                new object[]{ "abacABbabababc@C C@OE", "AB", "OE" },
            };
    }

    public class ConsecutiveLowerCharsCases
    {
        public static IEnumerable<object[]> Cases =>
            new List<object[]>
            {
                new object[]{ "AAabcdaaBBBBCCccC", "abcdaa", "cc" },
                new object[]{ "AAAABBBBCCCCC" },
                new object[]{ "ABC" },
                new object[]{ null },
                new object[]{ "" },
                new object[]{ "    " },
                new object[]{ "ABACabBABABABC@c c@oe", "ab", "oe" },
            };
    }

    public class ConsecutiveNumberCases
    {
        public static IEnumerable<object[]> Cases =>
            new List<object[]>
            {
                new object[]{ "123abcdaa11467CC98C", "123", "11467", "98" },
                new object[]{ "AA2AB3BBCCCCC" },
                new object[]{ "A2C" },
                new object[]{ null },
                new object[]{ "" },
                new object[]{ "    " },
                new object[]{ "ABAC34BABABABC@c c@88", "34", "88" },
            };
    }

    public class SequentialLettersCases
    {
        public static IEnumerable<object[]> CasesInsensitives =>
            new List<object[]>
            {
                new object[]{ "123abcdakl11467CEFGC98C", "abcd", "kl", "EFG" },
                new object[]{ "IGAÇLJODA" },
                new object[]{ "A2C" },
                new object[]{ null },
                new object[]{ "" },
                new object[]{ "    " },
                new object[]{ "AbCd34BABABABC@c c@88", "AbCd", "AB", "AB", "ABC" },
                new object[]{ "AbCABcd34BABABABC@c c@Mn", "AbC", "ABcd", "AB", "AB", "ABC", "Mn" },
            };

        public static IEnumerable<object[]> CasesSensitives =>
          new List<object[]>
          {
                new object[]{ "123abcdakl11467CEFGC98C", "abcd", "kl", "EFG" },
                new object[]{ "IGAÇLJODA" },
                new object[]{ "A2C" },
                new object[]{ null },
                new object[]{ "" },
                new object[]{ "    " },
                new object[]{ "AbCd34BABABABC@c c@88", "AB", "AB", "ABC" },
                new object[]{ "AbCABcd34BABABABC@c c@Mn", "AB", "cd", "AB", "AB", "ABC" },
          };
    }

    public class SequentialNumbersCases
    {
        public static IEnumerable<object[]> Cases =>
            new List<object[]>
            {
                new object[]{ "123abcdakl11467CEFGC98C", "123", "67" },
                new object[]{ "IGAÇLJODA" },
                new object[]{ "A2C" },
                new object[]{ null },
                new object[]{ "" },
                new object[]{ "    " },
                new object[]{ "AbCd34BAB46A8B9A01BC@c c@88", "34", "01" },
                new object[]{ "123456AbC78ABcd34BAB0011223344ABABC@c c@Mn", "123456", "78", "34", "01", "12", "23", "34"  },
            };
    }
}