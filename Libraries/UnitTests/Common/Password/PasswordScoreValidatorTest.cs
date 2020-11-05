using Myframework.Libraries.Common.Enums;
using Myframework.Libraries.Common.Password;
using System.Diagnostics;
using Xunit;

namespace Common.Password
{
    public class PasswordScoreValidatorTest
    {
        [Theory(DisplayName = "Validate score")]
        [InlineData(null, PasswordScore.Blank)]
        [InlineData("", PasswordScore.Blank)]
        [InlineData("a", PasswordScore.VeryWeak)]
        [InlineData("A", PasswordScore.VeryWeak)]
        [InlineData("ab", PasswordScore.VeryWeak)]
        [InlineData("abc", PasswordScore.VeryWeak)]
        [InlineData("aaaa", PasswordScore.VeryWeak)]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaa", PasswordScore.VeryWeak)]
        [InlineData("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa", PasswordScore.VeryWeak)]
        [InlineData("aaaAAAAAAaaAaAaAa", PasswordScore.VeryWeak)]
        [InlineData("1234567890123456789", PasswordScore.VeryWeak)]
        [InlineData("aa1aaAa", PasswordScore.Weak)]
        [InlineData("alex123", PasswordScore.Weak)]
        [InlineData("aaa1572bbb", PasswordScore.Good)]
        [InlineData("nome@123", PasswordScore.Good)]
        [InlineData("ake1580", PasswordScore.Good)]
        [InlineData("aaaAAAAAA1aaAaAaAa", PasswordScore.Good)]
        [InlineData("no2me@123", PasswordScore.Strong)]
        [InlineData("aaaAAAAAA@1aaAaAaAa", PasswordScore.Strong)]
        [InlineData("aaa1572Bbb", PasswordScore.VeryStrong)]
        [InlineData("n-o2me@123", PasswordScore.VeryStrong)]
        [InlineData("abcABCDEF@1abAbAbAb", PasswordScore.VeryStrong)]
        [InlineData("efkw@i350@I5780", PasswordScore.VeryStrong)]
        public void ValidatePassword(string password, PasswordScore expectedScore)
        {
            var validator = new PasswordScoreValidator();
            PasswordScore score = validator.CalculateScore(password);

            WriteToDebugConsoleWhenDebugging(password, validator);

            Assert.Equal(expectedScore, score);
        }

        private void WriteToDebugConsoleWhenDebugging(string password, PasswordScoreValidator validator)
        {
#if DEBUG
            Debug.WriteLine($"#####################################################################################");
            Debug.WriteLine($"Password: {password} , Score: {validator.CalculatedScore}, ScorePoints: {validator.CalculatedScorePoints}");
            Debug.WriteLine($"#####################################################################################");
            Debug.WriteLine($"Description | Count | Score");
            Debug.WriteLine($"Number of Characteres | {validator.Scores.CountNumberOfChars} | {validator.Scores.ScoreNumberOfChars}");
            Debug.WriteLine($"Uppercase Letters | {validator.Scores.CountUpperCaseChars} | {validator.Scores.ScoreUpperCaseChars}");
            Debug.WriteLine($"Lowercase Letters | {validator.Scores.CountLowerCaseChars} | {validator.Scores.ScoreLowerCaseChars}");
            Debug.WriteLine($"Numbers | {validator.Scores.CountNumbers} | {validator.Scores.ScoreNumbers}");
            Debug.WriteLine($"Special Chars | {validator.Scores.CountSpecialChars} | {validator.Scores.ScoreSpecialChars}");
            Debug.WriteLine($"Middle Numbers or Special Chars | {validator.Scores.CountMiddleNumbersOrSpecialChars} | {validator.Scores.ScoreMiddleNumbersOrSpecialChars}");
            Debug.WriteLine($"Requirements | {validator.Scores.CountRequirements} | {validator.Scores.ScoreRequirements}");
            Debug.WriteLine($"Letters Only | {validator.Scores.CountLettersOnly} | {validator.Scores.ScoreLettersOnly}");
            Debug.WriteLine($"Numbers Only | {validator.Scores.CountNumbersOnly} | {validator.Scores.ScoreNumbersOnly}");
            Debug.WriteLine($"Repeat Characters | {validator.Scores.CountRepeatCharacteres} | {validator.Scores.ScoreRepeatCharacteres}");
            Debug.WriteLine($"Consecutive Uppercase Letters | {validator.Scores.CountConsecutiveUpperCaseChars} | {validator.Scores.ScoreConsecutiveUpperCaseChars}");
            Debug.WriteLine($"Consecutive Lowercase Letters | {validator.Scores.CountConsecutiveLowerCaseChars} | {validator.Scores.ScoreConsecutiveLowerCaseChars}");
            Debug.WriteLine($"Consecutive Numbers | {validator.Scores.CountConsecutiveNumbers} | {validator.Scores.ScoreConsecutiveNumbers}");
            Debug.WriteLine($"Sequential Letters | {validator.Scores.CountSequentialLetters} | {validator.Scores.ScoreSequentialLetters}");
            Debug.WriteLine($"Sequential Numbers | {validator.Scores.CountSequentialNumbers} | {validator.Scores.ScoreSequentialNumbers}");
            Debug.WriteLine($"#####################################################################################");
#endif
        }
    }
}