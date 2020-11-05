using Myframework.Libraries.Common.Helpers;
using Xunit;

namespace Common.Helpers
{

    public class UnitOfMeasureHelperTest
    {
        [Theory]
        [InlineData(100, 1)]
        [InlineData(0, 0)]
        [InlineData(-100, -1)]
        [InlineData(25, 0.25)]
        public void ConvertCentimetersToMetersTest(double centimeters, double expectedMeters) =>
            Assert.Equal(expectedMeters, UnitOfMeasureHelper.ConvertCentimetersToMeters(centimeters));

        [Theory]
        [InlineData(1, 100)]
        [InlineData(0, 0)]
        [InlineData(-1, -100)]
        [InlineData(0.25, 25)]
        public void ConvertMetersToCentimetersTest(double centimeters, double expectedMeters) =>
            Assert.Equal(expectedMeters, UnitOfMeasureHelper.ConvertMetersToCentimeters(centimeters));

        [Theory]
        [InlineData(1000, 1)]
        [InlineData(0, 0)]
        [InlineData(-1000, -1)]
        [InlineData(25, 0.025)]
        public void ConvertGramsToKilograms(double grams, double expectedKilograms) =>
            Assert.Equal(expectedKilograms, UnitOfMeasureHelper.ConvertGramsToKilograms(grams));

        [Theory]
        [InlineData(1, 1000)]
        [InlineData(0, 0)]
        [InlineData(-1, -1000)]
        [InlineData(0.025, 25)]
        public void ConvertKilogramsToGrams(double kilograms, double expectedGrams) =>
            Assert.Equal(expectedGrams, UnitOfMeasureHelper.ConvertKilogramsToGrams(kilograms));
    }
}
