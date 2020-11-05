using System;

namespace Myframework.Libraries.Common.Helpers
{
    /// <summary>
    /// Métodos úteis para unidades de medidas.
    /// </summary>
    public static class UnitOfMeasureHelper
    {
        /// <summary>
        /// Converter minuto para millesegundos
        /// </summary>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static long ConvertMinuteToMillisecond(long minute) => minute * 60000;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mmoL"></param>
        /// <returns></returns>
        public static double ConvertMmoLToMgDL(double mmoL) => Math.Round(mmoL / 0.1109, 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mgDL"></param>
        /// <returns></returns>
        public static double ConvertMgDLToMmoL(double mgDL) => Math.Round(mgDL * 0.1109, 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfMeasureSource"></param>
        /// <param name="variableForCalculation"></param>
        /// <returns></returns>
        public static double DivideUnitOfMeasurePerVariable(double unitOfMeasureSource, double variableForCalculation) => Math.Round(unitOfMeasureSource / variableForCalculation, 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfMeasureSource"></param>
        /// <param name="variableForCalculation"></param>
        /// <returns></returns>
        public static double MultiplyUnitOfMeasurePerVariable(double unitOfMeasureSource, double variableForCalculation) => Math.Round(unitOfMeasureSource * variableForCalculation, 1);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="microliter"></param>
        /// <returns></returns>
        public static double ConvertMicroliterToBase10(double microliter) => Math.Round((microliter / 1000), 2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="base10"></param>
        /// <returns></returns>
        public static double ConvertBase10Microliter(double base10) => Math.Round((base10 * 1000), 2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gramPerLiter"></param>
        /// <returns></returns>
        public static double ConvertGramPerLiterToGramPerDeciliter(double gramPerLiter) => Math.Round((gramPerLiter / 10), 2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gramPerLiter"></param>
        /// <returns></returns>
        public static double ConvertGramPerLiterToMilligramsPerDeciliter(double gramPerLiter) => Math.Round(gramPerLiter * 100, 2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="milligramPerLiter"></param>
        /// <returns></returns>
        public static double ConvertMilligramPerLiterToMiliGramPerDeciliter(double milligramPerLiter) => Math.Round(milligramPerLiter / 10, 2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="literPerLiter"></param>
        /// <returns></returns>
        public static double ConvertLiterPerLiterToPercentage(double literPerLiter) => Math.Round(literPerLiter * 100, 2);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="minute"></param>
        /// <returns></returns>
        public static int ConvertMinuteToMillisecond(int minute) => minute * 60000;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="centimeters"></param>
        /// <returns></returns>
        public static double ConvertCentimetersToMeters(double centimeters) => centimeters / 100;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="meters"></param>
        /// <returns></returns>
        public static double ConvertMetersToCentimeters(double meters) => meters * 100;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grams"></param>
        /// <returns>kilograms</returns>
        public static double ConvertGramsToKilograms(double grams) => grams / 1000;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kilograms"></param>
        /// <returns>grams</returns>
        public static double ConvertKilogramsToGrams(double kilograms) => kilograms * 1000;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mmoL"></param>
        /// <returns></returns>
        public static double ConvertLactateMmoLToMgDL(double mmoL) => Math.Round(mmoL / 0.1109, 1);

        /// <summary>
        /// Calcula o indice de massa corporal (IMC)
        /// </summary>
        /// <param name="heigth">Altura em metros</param>
        /// <param name="weight">Peso em kg</param>
        /// <returns></returns>
        public static double? CalculateBMI(double? heigth, double? weight)
        {
            if (!heigth.HasValue || heigth <= 0 || !weight.HasValue || weight <= 0) return null;
            return Math.Round(weight.Value / Math.Pow(heigth.Value, 2), 1);
        }
    }
}