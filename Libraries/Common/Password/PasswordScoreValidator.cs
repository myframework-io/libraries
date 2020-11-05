using Myframework.Libraries.Common.Enums;
using Myframework.Libraries.Common.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Myframework.Libraries.Common.Password
{
    /*******************************************************************************************
     Links úteis: 
     - https://password.kaspersky.com/
     - http://www.passwordmeter.com/
     - http://davidstutz.github.io/password-score/     
     *******************************************************************************************/

    /// <summary>
    /// Classe para gerar um score de senha.
    /// </summary>
    public class PasswordScoreValidator
    {
        /// <summary>
        /// 
        /// </summary>
        public PasswordScoreValidator() => SpecialChars = new List<char> { '!', '@', '#', '$', '%', '^', '&', '*', '?', '_', '~', '-', '£', '(', ')' };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="specialCharChecked"></param>
        public PasswordScoreValidator(List<char> specialCharChecked)
            : this() => SpecialChars = specialCharChecked;

        public int? CalculatedScorePoints { get; private set; }
        public PasswordScore? CalculatedScore { get; private set; }

        /// <summary>
        /// Caracteres especiais que são checados para compor o score da senha.
        /// </summary>
        public List<char> SpecialChars { get; set; }

        public PasswordScores Scores { get; private set; } = new PasswordScores();
        public PasswordUnitAdictionsAndDeductions UnitAdictionsAndDeductions { get; private set; } = new PasswordUnitAdictionsAndDeductions();

        public int MinimumRequirementToScore { get; set; } = 4;
        public int SufficientNumberOfChars { get; set; } = 6;
        public int SufficientLowerCaseChars { get; set; } = 1;
        public int SufficientUpperCaseChars { get; set; } = 1;
        public int SufficientNumbers { get; set; } = 1;
        public int SufficientSpecialChars { get; set; } = 1;


        /// <summary>
        /// Retorna a pontuação de acordo com a senha passada. 
        /// </summary>
        /// <param name="password">Senha para ser pontuada</param>
        /// <returns>Enumerador com a pontuação</returns>
        public PasswordScore CalculateScore(string password)
        {
            if (string.IsNullOrWhiteSpace(password) || password.Length < 1)
                return PasswordScore.Blank;

            CalculateScoreNumberOfChars(password);
            CalculateScoreUpperCaseChars(password);
            CalculateScoreLowerCaseChars(password);
            CalculateScoreNumbers(password);
            CalculateScoreSpecialChars(password);
            CalculateScoreMiddleNumbersOrSpecialChars(password);
            CalculateScoreRequirements(password);
            CalculateScoreLettersOnly(password);
            CalculateScoreNumbersOnly(password);
            CalculateScoreRepeatCharacteres(password);
            CalculateScoreConsecutiveUpperCaseChars(password);
            CalculateScoreConsecutiveLowerCaseChars(password);
            CalculateScoreConsecutiveConsecutiveNumbers(password);
            CalculateScoreSequentialLetters(password);
            CalculateScoreSequentialNumbers(password);

            int score =
              Scores.ScoreNumberOfChars
              + Scores.ScoreUpperCaseChars
              + Scores.ScoreLowerCaseChars
              + Scores.ScoreNumbers
              + Scores.ScoreSpecialChars
              + Scores.ScoreMiddleNumbersOrSpecialChars
              + Scores.ScoreRequirements
              + Scores.ScoreLettersOnly
              + Scores.ScoreNumbersOnly
              + Scores.ScoreRepeatCharacteres
              + Scores.ScoreConsecutiveUpperCaseChars
              + Scores.ScoreConsecutiveLowerCaseChars
              + Scores.ScoreConsecutiveNumbers
              + Scores.ScoreSequentialLetters
              + Scores.ScoreSequentialNumbers;

            CalculatedScorePoints = score;

            if (score < 20)
                CalculatedScore = PasswordScore.VeryWeak;
            else if (score < 40)
                CalculatedScore = PasswordScore.Weak;
            else if (score < 60)
                CalculatedScore = PasswordScore.Good;
            else if (score < 80)
                CalculatedScore = PasswordScore.Strong;
            else
                CalculatedScore = PasswordScore.VeryStrong;

            return CalculatedScore.Value;
        }

        private void CalculateScoreNumberOfChars(string password)
        {
            Scores.CountNumberOfChars = password.Length;
            Scores.ScoreNumberOfChars = Scores.CountNumberOfChars * UnitAdictionsAndDeductions.AdictionNumberOfChars;
        }

        private void CalculateScoreUpperCaseChars(string password)
        {
            Scores.CountUpperCaseChars = password.CountUpperCaseChars();

            if (Scores.CountUpperCaseChars <= 0)
                Scores.ScoreUpperCaseChars = 0;
            else
                Scores.ScoreUpperCaseChars = (password.Length - Scores.CountUpperCaseChars) * UnitAdictionsAndDeductions.AdictionUpperCaseChar;
        }

        private void CalculateScoreLowerCaseChars(string password)
        {
            Scores.CountLowerCaseChars = password.CountLowerCaseChars();

            if (Scores.CountLowerCaseChars <= 0)
                Scores.ScoreLowerCaseChars = 0;
            else
                Scores.ScoreLowerCaseChars = (password.Length - Scores.CountLowerCaseChars) * UnitAdictionsAndDeductions.AdictionLowerCaseChar;
        }

        private void CalculateScoreNumbers(string password)
        {
            Scores.CountNumbers = password.CountNumbers();

            if (password.HasOnlyNumbers())
                Scores.ScoreNumbers = 0;
            else
                Scores.ScoreNumbers = Scores.CountNumbers * UnitAdictionsAndDeductions.AdictionNumbers;
        }

        private void CalculateScoreSpecialChars(string password)
        {
            Scores.CountSpecialChars = password.Count(c => SpecialChars.Contains(c));
            Scores.ScoreSpecialChars = Scores.CountSpecialChars * UnitAdictionsAndDeductions.AdictionSpecialChars;
        }

        private void CalculateScoreMiddleNumbersOrSpecialChars(string password)
        {
            if (password == null || password.Length <= 2)
            {
                Scores.CountMiddleNumbersOrSpecialChars = 0;
                Scores.ScoreMiddleNumbersOrSpecialChars = 0;
                return;
            }

            string middleChars = password.Substring(1, password.Length - 2);

            int specialChars = middleChars.Count(c => SpecialChars.Contains(c));
            int numbersChars = middleChars.Count(c => char.IsNumber(c));

            Scores.CountMiddleNumbersOrSpecialChars = specialChars + numbersChars;
            Scores.ScoreMiddleNumbersOrSpecialChars = Scores.CountMiddleNumbersOrSpecialChars * UnitAdictionsAndDeductions.AdictionMiddleNumbersOrSpecialChars;
        }

        private void CalculateScoreRequirements(string password)
        {
            int requirementsCount = 0;

            if (password.Length >= SufficientNumberOfChars)
                requirementsCount++;

            if (password.Count(c => char.IsLower(c)) >= SufficientLowerCaseChars)
                requirementsCount++;

            if (password.Count(c => char.IsUpper(c)) >= SufficientUpperCaseChars)
                requirementsCount++;

            if (password.Count(c => char.IsNumber(c)) >= SufficientNumbers)
                requirementsCount++;

            if (password.Count(c => SpecialChars.Contains(c)) >= SufficientSpecialChars)
                requirementsCount++;

            Scores.CountRequirements = requirementsCount;

            if (requirementsCount >= MinimumRequirementToScore)
                Scores.ScoreRequirements = Scores.CountRequirements * UnitAdictionsAndDeductions.AdictionRequirements;
            else
                Scores.ScoreRequirements = 0;
        }

        private void CalculateScoreLettersOnly(string password)
        {
            int lettersCount = password.CountLetters();

            if (password.Length != lettersCount)
                lettersCount = 0;

            Scores.CountLettersOnly = lettersCount;
            Scores.ScoreLettersOnly = Scores.CountLettersOnly * (-1);
        }

        private void CalculateScoreNumbersOnly(string password)
        {
            int numbersCount = password.CountNumbers();

            if (password.Length != numbersCount)
                numbersCount = 0;

            Scores.CountNumbersOnly = numbersCount;
            Scores.ScoreNumbersOnly = Scores.CountNumbersOnly * (-1);
        }

        private void CalculateScoreRepeatCharacteres(string password)
        {
            Dictionary<char, int> repeatedChars = password.GetRepeatedChars();

            int scoreSum = repeatedChars.Where(it => it.Value < 3).Sum(it => it.Value);
            scoreSum += repeatedChars.Where(it => it.Value >= 3 && it.Value < 5).Sum(it => it.Value * UnitAdictionsAndDeductions.DeductionRepeatThreeTimesChar);
            scoreSum += repeatedChars.Where(it => it.Value >= 5).Sum(it => it.Value * UnitAdictionsAndDeductions.DeductionRepeatFiveTimesOrMoreChar);

            Scores.CountRepeatCharacteres = repeatedChars.Sum(it => it.Value);
            Scores.ScoreRepeatCharacteres = scoreSum * (-1);
        }

        private void CalculateScoreConsecutiveUpperCaseChars(string password)
        {
            //Contar combinacoes consecutivas das letras. EX: AA = 1, AAA = 2, AAAA =3...
            List<string> upperCases = password.GetConsecutiveUpperCaseChars();
            int count = 0;

            upperCases.ForEach(it => count += it.Length - 1);

            Scores.CountConsecutiveUpperCaseChars = count;
            Scores.ScoreConsecutiveUpperCaseChars = Scores.CountConsecutiveUpperCaseChars * UnitAdictionsAndDeductions.DeductionConsecutiveUpperCaseChars * (-1);
        }

        private void CalculateScoreConsecutiveLowerCaseChars(string password)
        {
            List<string> cases = password.GetConsecutiveLowerCaseChars();
            int count = 0;

            cases.ForEach(it => count += it.Length - 1);

            Scores.CountConsecutiveLowerCaseChars = count;
            Scores.ScoreConsecutiveLowerCaseChars = Scores.CountConsecutiveLowerCaseChars * UnitAdictionsAndDeductions.DeductionConsecutiveLowerCaseChars * (-1);
        }

        private void CalculateScoreConsecutiveConsecutiveNumbers(string password)
        {
            List<string> cases = password.GetConsecutiveNumbersChars();
            int count = 0;

            cases.ForEach(it => count += it.Length - 1);

            Scores.CountConsecutiveNumbers = count;
            Scores.ScoreConsecutiveNumbers = Scores.CountConsecutiveNumbers * UnitAdictionsAndDeductions.DeductionConsecutiveNumberChars * (-1);
        }

        private void CalculateScoreSequentialLetters(string password)
        {
            Scores.CountSequentialLetters = password.CountSequentialLettersChars();
            Scores.ScoreSequentialLetters = Scores.CountSequentialLetters * UnitAdictionsAndDeductions.DeductionSequentialLettersChars * (-1);
        }

        private void CalculateScoreSequentialNumbers(string password)
        {
            Scores.CountSequentialNumbers = password.CountSequentialNumbersChars();
            Scores.ScoreSequentialNumbers = Scores.CountSequentialNumbers * UnitAdictionsAndDeductions.DeductionSequentialNumbersChars * (-1);
        }

        public class PasswordScores
        {
            public int ScoreNumberOfChars { get; set; }
            public int ScoreUpperCaseChars { get; set; }
            public int ScoreLowerCaseChars { get; set; }
            public int ScoreNumbers { get; set; }
            public int ScoreSpecialChars { get; set; }
            public int ScoreMiddleNumbersOrSpecialChars { get; set; }
            public int ScoreRequirements { get; set; }
            public int ScoreLettersOnly { get; set; }
            public int ScoreNumbersOnly { get; set; }
            public int ScoreRepeatCharacteres { get; set; }
            public int ScoreConsecutiveUpperCaseChars { get; set; }
            public int ScoreConsecutiveLowerCaseChars { get; set; }
            public int ScoreConsecutiveNumbers { get; set; }
            public int ScoreSequentialLetters { get; set; }
            public int ScoreSequentialNumbers { get; set; }

            public int CountNumberOfChars { get; set; }
            public int CountUpperCaseChars { get; set; }
            public int CountLowerCaseChars { get; set; }
            public int CountNumbers { get; set; }
            public int CountSpecialChars { get; set; }
            public int CountMiddleNumbersOrSpecialChars { get; set; }
            public int CountRequirements { get; set; }
            public int CountLettersOnly { get; set; }
            public int CountNumbersOnly { get; set; }
            public int CountRepeatCharacteres { get; set; }
            public int CountConsecutiveUpperCaseChars { get; set; }
            public int CountConsecutiveLowerCaseChars { get; set; }
            public int CountConsecutiveNumbers { get; set; }
            public int CountSequentialLetters { get; set; }
            public int CountSequentialNumbers { get; set; }
        }

        public class PasswordUnitAdictionsAndDeductions
        {
            public int AdictionNumberOfChars { get; set; } = 4;
            public int AdictionUpperCaseChar { get; set; } = 2;
            public int AdictionLowerCaseChar { get; set; } = 2;
            public int AdictionNumbers { get; set; } = 4;
            public int AdictionSpecialChars { get; set; } = 6;
            public int AdictionMiddleNumbersOrSpecialChars { get; set; } = 2;
            public int AdictionRequirements { get; set; } = 2;
            public int DeductionConsecutiveUpperCaseChars { get; set; } = 2;
            public int DeductionConsecutiveLowerCaseChars { get; set; } = 2;
            public int DeductionConsecutiveNumberChars { get; set; } = 2;
            public int DeductionSequentialLettersChars { get; set; } = 1;
            public int DeductionSequentialNumbersChars { get; set; } = 1;
            public int DeductionRepeatThreeTimesChar { get; set; } = 1;
            public int DeductionRepeatFiveTimesOrMoreChar { get; set; } = 3;
        }
    }
}