using Myframework.Libraries.Common.UnitsOfMeasurement;
using System;
using System.Globalization;
using Xunit;

namespace Common.UnitsOfMeasurement
{
    public class ByteMeasurementTests
    {
        #region ByteMeasurementArithmeticMethods

        [Theory(DisplayName = "Add ByteMeasurement (bytes)")]
        [InlineData(1, 1, 2, 16)]
        public void AddMethod(int startBytes, int addBytes, int expectedBytes, int expectedBits)
        {
            var original = ByteMeasurement.FromBytes(startBytes);
            ByteMeasurement result = original.Add(ByteMeasurement.FromBytes(addBytes));

            Assert.Equal(expectedBytes, result.Bytes);
            Assert.Equal(expectedBits, result.Bits);
        }

        //[Theory(DisplayName = "Add ByteMeasurement (megabytes)")]
        //[InlineData(1, 1, 8, 16)]
        //public void AddMethod(int startBytes, int addBytes, int expectedBytes, int expectedBits)
        //{
        //    var original = ByteMeasurement.FromBytes(startBytes);
        //    ByteMeasurement result = original.Add(ByteMeasurement.FromBytes(addBytes));

        //    Assert.Equal(expectedBytes, result.Bytes);
        //    Assert.Equal(expectedBits, result.Bits);
        //}

        //TODO: testar esse metodo de add para as demais unidades

        [Theory(DisplayName = "Add bits to bits")]
        [InlineData(1, 8, 9)]
        [InlineData(5, 4, 9)]
        [InlineData(5, -4, 1)]
        [InlineData(5, -6, -1)]
        [InlineData(5, -5, 0)]
        [InlineData(500000, 500001, 1000001)]
        public void AddBitsToBitsMethod(int startBits, int addBits, int expectedBits) => Assert.Equal(expectedBits, ByteMeasurement.FromBits(startBits).AddBits(addBits).Bits);

        [Theory(DisplayName = "Add bytes to bytes")]
        [InlineData(1, 8, 9)]
        [InlineData(5, 4, 9)]
        [InlineData(5, -4, 1)]
        [InlineData(5, -6, -1)]
        [InlineData(5, -5, 0)]
        [InlineData(500000, 500001, 1000001)]
        public void AddBytesToBytesMethod(int startBytes, int addbytes, int expectedBytes) => Assert.Equal(expectedBytes, ByteMeasurement.FromBytes(startBytes).AddBytes(addbytes).Bytes);

        [Theory(DisplayName = "Add kilobytes to kilobytes")]
        [InlineData(1, 8, 9)]
        [InlineData(5, 4, 9)]
        [InlineData(5, -4, 1)]
        [InlineData(5, -6, -1)]
        [InlineData(5, -5, 0)]
        [InlineData(500000, 500001, 1000001)]
        public void AddKilobytesToKilobytesMethod(int startKilobytes, int addKilobytes, int expectedKilobytes) => Assert.Equal(expectedKilobytes, ByteMeasurement.FromKiloBytes(startKilobytes).AddKiloBytes(addKilobytes).KiloBytes);

        [Theory(DisplayName = "Add megabytes to megabytes")]
        [InlineData(1, 8, 9)]
        [InlineData(5, 4, 9)]
        [InlineData(5, -4, 1)]
        [InlineData(5, -6, -1)]
        [InlineData(5, -5, 0)]
        [InlineData(500000, 500001, 1000001)]
        public void AddMegabytesToMegabytesMethod(int startMegabytes, int addMegabytes, int expectedMegabytes) => Assert.Equal(expectedMegabytes, ByteMeasurement.FromMegaBytes(startMegabytes).AddMegaBytes(addMegabytes).MegaBytes);

        [Theory(DisplayName = "Add gigabytes to gigabytes")]
        [InlineData(1, 8, 9)]
        [InlineData(5, 4, 9)]
        [InlineData(5, -4, 1)]
        [InlineData(5, -6, -1)]
        [InlineData(5, -5, 0)]
        [InlineData(500000, 500001, 1000001)]
        public void AddGigabytesToGigabytesMethod(int startGigabytes, int addGigabytes, int expectedGigabytes) => Assert.Equal(expectedGigabytes, ByteMeasurement.FromGigaBytes(startGigabytes).AddGigaBytes(addGigabytes).GigaBytes);

        [Theory(DisplayName = "Add terabytes to terabytes")]
        [InlineData(1, 8, 9)]
        [InlineData(5, 4, 9)]
        [InlineData(5, -4, 1)]
        [InlineData(5, -6, -1)]
        [InlineData(5, -5, 0)]
        [InlineData(500000, 500001, 1000001)]
        public void AddTerabytesToTerabytesMethod(int startTerabytes, int addTerabytes, int expectedTerabytes) => Assert.Equal(expectedTerabytes, ByteMeasurement.FromTeraBytes(startTerabytes).AddTeraBytes(addTerabytes).TeraBytes);

        [Theory(DisplayName = "Add petabytes to petabytes")]
        [InlineData(1, 8, 9)]
        [InlineData(5, 4, 9)]
        [InlineData(5, -4, 1)]
        [InlineData(5, -6, -1)]
        [InlineData(5, -5, 0)]
        [InlineData(500000, 500001, 1000001)]
        public void AddPetabytesToPetabytesMethod(int startPetabytes, int addPetabytes, int expectedPetabytes) => Assert.Equal(expectedPetabytes, ByteMeasurement.FromPetaBytes(startPetabytes).AddPetaBytes(addPetabytes).PetaBytes);

        //TODO: testar combinacoes de unidades...so esta testando adicao da msm unidade
        //TODO: os testes acima testavam tb conversao da unidade do calculo para outras unidades, esses testes devem estar separados

        //TODO: testar entre unidades
        [Theory(DisplayName = "Subtract ByteMeasurement")]
        [InlineData(4, 2, 2, 16)]
        public void SubtractMethod(int fromBytes, int subtractBytes, int expectedBytes, int expectedBits)
        {
            ByteMeasurement size = ByteMeasurement.FromBytes(fromBytes).Subtract(ByteMeasurement.FromBytes(subtractBytes));

            Assert.Equal(expectedBytes, size.Bytes);
            Assert.Equal(expectedBits, size.Bits);
        }

        [Theory(DisplayName = "Increment operator bytes")]
        [InlineData(2, 3)]
        [InlineData(-1, 0)]
        [InlineData(0, 1)]
        public void IncrementOperator(int fromBytes, int expectedBytes)
        {
            var size = ByteMeasurement.FromBytes(fromBytes);
            size++;
            Assert.Equal(expectedBytes, size.Bytes);
        }

        [Theory(DisplayName = "Increment operator from megabytes")]
        [InlineData(2, 2097153)]
        public void IncrementOperatorMegabytes(int fromMegaBytes, int expectedBytes)
        {
            var size = ByteMeasurement.FromMegaBytes(fromMegaBytes);
            size++;
            Assert.Equal(expectedBytes, size.Bytes);
        }

        [Theory(DisplayName = "Minus operator unary")]
        [InlineData(2, -2)]
        [InlineData(-2, 2)]
        public void MinusOperatorUnary(int fromBytes, int expectedBytes) => Assert.Equal(expectedBytes, (-ByteMeasurement.FromBytes(fromBytes)).Bytes);

        [Theory(DisplayName = "Minus operator binary")]
        [InlineData(4, 2, 2)]
        [InlineData(2, -2, 4)]
        [InlineData(-2, 2, -4)]
        [InlineData(2, 2, 0)]
        public void MinusOperatorBinary(int fromBytes1, int fromBytes2, int expectedBytes) => Assert.Equal(expectedBytes, (ByteMeasurement.FromBytes(fromBytes1) - ByteMeasurement.FromBytes(fromBytes2)).Bytes);

        [Theory(DisplayName = "Decrement operator bytes")]
        [InlineData(2, 1)]
        [InlineData(1, 0)]
        [InlineData(0, -1)]
        public void DecrementOperator(int fromBytes, int expectedBytes)
        {
            var size = ByteMeasurement.FromBytes(fromBytes);
            size--;
            Assert.Equal(expectedBytes, size.Bytes);
        }

        #endregion ByteMeasurementArithmeticMethods

        #region CreatingMethods

        [Fact]
        public void Constructor()
        {
            // Arrange
            double bytes = 1125899906842624;

            // Act
            var result = new ByteMeasurement(bytes);

            // Assert
            Assert.Equal(bytes * 8, result.Bits);
            Assert.Equal(bytes, result.Bytes);
            Assert.Equal(bytes / 1024, result.KiloBytes);
            Assert.Equal(bytes / 1024 / 1024, result.MegaBytes);
            Assert.Equal(bytes / 1024 / 1024 / 1024, result.GigaBytes);
            Assert.Equal(bytes / 1024 / 1024 / 1024 / 1024, result.TeraBytes);
            Assert.Equal(1, result.PetaBytes);
        }

        [Fact]
        public void FromBitsMethod()
        {
            // Arrange
            long value = 8;

            // Act
            var result = ByteMeasurement.FromBits(value);

            // Assert
            Assert.Equal(8, result.Bits);
            Assert.Equal(1, result.Bytes);
        }

        [Fact]
        public void FromBytesMethod()
        {
            // Arrange
            double value = 1.5;

            // Act
            var result = ByteMeasurement.FromBytes(value);

            // Assert
            Assert.Equal(12, result.Bits);
            Assert.Equal(1.5, result.Bytes);
        }

        [Fact]
        public void FromKiloBytesMethod()
        {
            // Arrange
            double value = 1.5;

            // Act
            var result = ByteMeasurement.FromKiloBytes(value);

            // Assert
            Assert.Equal(1536, result.Bytes);
            Assert.Equal(1.5, result.KiloBytes);
        }

        [Fact]
        public void FromMegaBytesMethod()
        {
            // Arrange
            double value = 1.5;

            // Act
            var result = ByteMeasurement.FromMegaBytes(value);

            // Assert
            Assert.Equal(1572864, result.Bytes);
            Assert.Equal(1.5, result.MegaBytes);
        }

        [Fact]
        public void FromGigaBytesMethod()
        {
            // Arrange
            double value = 1.5;

            // Act
            var result = ByteMeasurement.FromGigaBytes(value);

            // Assert
            Assert.Equal(1610612736, result.Bytes);
            Assert.Equal(1.5, result.GigaBytes);
        }

        [Fact]
        public void FromTeraBytesMethod()
        {
            // Arrange
            double value = 1.5;

            // Act
            var result = ByteMeasurement.FromTeraBytes(value);

            // Assert
            Assert.Equal(1649267441664, result.Bytes);
            Assert.Equal(1.5, result.TeraBytes);
        }

        [Fact]
        public void FromPetaBytesMethod()
        {
            // Arrange
            double value = 1.5;

            // Act
            var result = ByteMeasurement.FromPetaBytes(value);

            // Assert
            Assert.Equal(1688849860263936, result.Bytes);
            Assert.Equal(1.5, result.PetaBytes);
        }

        #endregion CreatingMethods

        #region ParsingMethods

        // Base parsing functionality
        [Fact]
        public void Parse()
        {
            string val = "1020KB";
            var expected = ByteMeasurement.FromKiloBytes(1020);

            var result = ByteMeasurement.Parse(val);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void TryParse()
        {
            string val = "1020KB";
            var expected = ByteMeasurement.FromKiloBytes(1020);

            bool resultBool = ByteMeasurement.TryParse(val, out ByteMeasurement resultByteMeasurement);

            Assert.True(resultBool);
            Assert.Equal(expected, resultByteMeasurement);
        }

        [Fact]
        public void ParseDecimalMB()
        {
            string val = "100,5MB";
            var expected = ByteMeasurement.FromMegaBytes(100.5);

            var result = ByteMeasurement.Parse(val);

            Assert.Equal(expected, result);
        }

        // Failure modes
        [Fact]
        public void TryParseReturnsFalseOnBadValue()
        {
            string val = "Unexpected Value";

            bool resultBool = ByteMeasurement.TryParse(val, out ByteMeasurement resultByteMeasurement);

            Assert.False(resultBool);
            Assert.Equal(new ByteMeasurement(), resultByteMeasurement);
        }

        [Fact]
        public void TryParseReturnsFalseOnMissingMagnitude()
        {
            string val = "1000";

            bool resultBool = ByteMeasurement.TryParse(val, out ByteMeasurement resultByteMeasurement);

            Assert.False(resultBool);
            Assert.Equal(new ByteMeasurement(), resultByteMeasurement);
        }

        [Fact]
        public void TryParseReturnsFalseOnMissingValue()
        {
            string val = "KB";

            bool resultBool = ByteMeasurement.TryParse(val, out ByteMeasurement resultByteMeasurement);

            Assert.False(resultBool);
            Assert.Equal(new ByteMeasurement(), resultByteMeasurement);
        }

        [Fact]
        public void TryParseWorksWithLotsOfSpaces()
        {
            string val = " 100 KB ";
            var expected = ByteMeasurement.FromKiloBytes(100);

            var result = ByteMeasurement.Parse(val);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ParsePartialBits()
        {
            string val = "10,5b";

            Assert.Throws<FormatException>(() =>
            {
                ByteMeasurement.Parse(val);
            });
        }


        // Parse method throws exceptions
        [Fact]
        public void ParseThrowsOnInvalid()
        {
            string badValue = "Unexpected Value";

            Assert.Throws<FormatException>(() =>
            {
                ByteMeasurement.Parse(badValue);
            });
        }

        [Fact]
        public void ParseThrowsOnNull()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                ByteMeasurement.Parse(null);
            });
        }


        // Various magnitudes
        [Fact]
        public void ParseBits()
        {
            string val = "1b";
            var expected = ByteMeasurement.FromBits(1);

            var result = ByteMeasurement.Parse(val);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ParseBytes()
        {
            string val = "1B";
            var expected = ByteMeasurement.FromBytes(1);

            var result = ByteMeasurement.Parse(val);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ParseKB()
        {
            string val = "1020KB";
            var expected = ByteMeasurement.FromKiloBytes(1020);

            var result = ByteMeasurement.Parse(val);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ParseMB()
        {
            string val = "1000MB";
            var expected = ByteMeasurement.FromMegaBytes(1000);

            var result = ByteMeasurement.Parse(val);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ParseGB()
        {
            string val = "805GB";
            var expected = ByteMeasurement.FromGigaBytes(805);

            var result = ByteMeasurement.Parse(val);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ParseTB()
        {
            string val = "100TB";
            var expected = ByteMeasurement.FromTeraBytes(100);

            var result = ByteMeasurement.Parse(val);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ParsePB()
        {
            string val = "100PB";
            var expected = ByteMeasurement.FromPetaBytes(100);

            var result = ByteMeasurement.Parse(val);

            Assert.Equal(expected, result);
        }

        [Fact]
        public void ParseCultureNumberSeparator()
        {
            CultureInfo.CurrentCulture = new CultureInfo("de-DE");
            string val = "1.500,5 MB";
            var expected = ByteMeasurement.FromMegaBytes(1500.5);

            var result = ByteMeasurement.Parse(val);

            Assert.Equal(expected, result);

            CultureInfo.CurrentCulture = new CultureInfo("en-US");
        }

        #endregion ToStringMethod

        #region ToStringMethod

        [Fact]
        public void ReturnsLargestMetricSuffix()
        {
            // Arrange
            var b = ByteMeasurement.FromKiloBytes(10.5);

            // Act
            string result = b.ToString();

            // Assert
            Assert.Equal(10.5.ToString("0.0 KB"), result);
        }

        [Fact]
        public void ReturnsDefaultNumberFormat()
        {
            // Arrange
            var b = ByteMeasurement.FromKiloBytes(10.5);

            // Act
            string result = b.ToString("KB");

            // Assert
            Assert.Equal(10.5.ToString("0.0 KB"), result);
        }

        [Fact]
        public void ReturnsProvidedNumberFormat()
        {
            // Arrange
            var b = ByteMeasurement.FromKiloBytes(10.1234);

            // Act
            string result = b.ToString("#.#### KB");

            // Assert
            Assert.Equal(10.1234.ToString("0.0000 KB"), result);
        }

        [Fact]
        public void ReturnsBits()
        {
            // Arrange
            var b = ByteMeasurement.FromBits(10);

            // Act
            string result = b.ToString("##.#### b");

            // Assert
            Assert.Equal("10 b", result);
        }

        [Fact]
        public void ReturnsBytes()
        {
            // Arrange
            var b = ByteMeasurement.FromBytes(10);

            // Act
            string result = b.ToString("##.#### B");

            // Assert
            Assert.Equal("10 B", result);
        }

        [Fact]
        public void ReturnsKiloBytes()
        {
            // Arrange
            var b = ByteMeasurement.FromKiloBytes(10);

            // Act
            string result = b.ToString("##.#### KB");

            // Assert
            Assert.Equal("10 KB", result);
        }

        [Fact]
        public void ReturnsMegaBytes()
        {
            // Arrange
            var b = ByteMeasurement.FromMegaBytes(10);

            // Act
            string result = b.ToString("##.#### MB");

            // Assert
            Assert.Equal("10 MB", result);
        }

        [Fact]
        public void ReturnsGigaBytes()
        {
            // Arrange
            var b = ByteMeasurement.FromGigaBytes(10);

            // Act
            string result = b.ToString("##.#### GB");

            // Assert
            Assert.Equal("10 GB", result);
        }

        [Fact]
        public void ReturnsTeraBytes()
        {
            // Arrange
            var b = ByteMeasurement.FromTeraBytes(10);

            // Act
            string result = b.ToString("##.#### TB");

            // Assert
            Assert.Equal("10 TB", result);
        }

        [Fact]
        public void ReturnsPetaBytes()
        {
            // Arrange
            var b = ByteMeasurement.FromPetaBytes(10);

            // Act
            string result = b.ToString("##.#### PB");

            // Assert
            Assert.Equal("10 PB", result);
        }

        [Fact]
        public void ReturnsSelectedFormat()
        {
            // Arrange
            var b = ByteMeasurement.FromTeraBytes(10);

            // Act
            string result = b.ToString("0.0 TB");

            // Assert
            Assert.Equal(10.ToString("0.0 TB"), result);
        }

        [Fact]
        public void ReturnsLargestMetricPrefixLargerThanZero()
        {
            // Arrange
            var b = ByteMeasurement.FromMegaBytes(.5);

            // Act
            string result = b.ToString("#.#");

            // Assert
            Assert.Equal("512 KB", result);
        }

        [Fact]
        public void ReturnsLargestMetricPrefixLargerThanZeroForNegativeValues()
        {
            // Arrange
            var b = ByteMeasurement.FromMegaBytes(-.5);

            // Act
            string result = b.ToString("#.#");

            // Assert
            Assert.Equal("-512 KB", result);
        }

        [Fact]
        public void ReturnsLargestMetricSuffixUsingCurrentCulture()
        {
            CultureInfo originalCulture = CultureInfo.CurrentCulture;
            CultureInfo.CurrentCulture = new CultureInfo("fr-FR");

            // Arrange
            var b = ByteMeasurement.FromKiloBytes(10000);

            // Act
            string result = b.ToString();

            // Assert
            Assert.Equal("9,77 MB", result);

            CultureInfo.CurrentCulture = originalCulture;
        }

        [Fact]
        public void ReturnsLargestMetricSuffixUsingSpecifiedCulture()
        {
            // Arrange
            var b = ByteMeasurement.FromKiloBytes(10000);

            // Act
            string result = b.ToString("#.#", new CultureInfo("fr-FR"));

            // Assert
            Assert.Equal("9,8 MB", result);
        }

        [Fact]
        public void ReturnsCultureSpecificFormat()
        {
            // Arrange
            var b = ByteMeasurement.FromKiloBytes(10.5);

            // Act
            var deCulture = new CultureInfo("de-DE");
            string result = b.ToString("0.0 KB", deCulture);

            // Assert
            Assert.Equal(10.5.ToString("0.0 KB", deCulture), result);
        }

        [Fact]
        public void ReturnsZeroBits()
        {
            // Arrange
            var b = ByteMeasurement.FromBits(0);

            // Act
            string result = b.ToString();

            // Assert
            Assert.Equal("0 b", result);
        }

        #endregion ToStringMethod

        #region Convertions

        [Theory(DisplayName = "Convert from byte with calculation assert")]
        [InlineData(1125899906842624)]
        public void ConvertFromBytesCalculationAssert(double fromBytes)
        {
            var result = new ByteMeasurement(fromBytes);
            double bytes = result.Bytes;

            Assert.Equal(result.Bytes * 8, result.Bits);
            Assert.Equal(fromBytes, result.Bytes);
            Assert.Equal(result.Bytes / 1024, result.KiloBytes);
            Assert.Equal(result.Bytes / 1024 / 1024, result.MegaBytes);
            Assert.Equal(result.Bytes / 1024 / 1024 / 1024, result.GigaBytes);
            Assert.Equal(result.Bytes / 1024 / 1024 / 1024 / 1024, result.TeraBytes);
            Assert.Equal(result.Bytes / 1024 / 1024 / 1024 / 1024 / 1024, result.PetaBytes);
        }

        //[Theory(DisplayName = "Convert from megabyte manual assert")]
        //[InlineData(25.8, 216426087, 27053260.8, 26419.2, 25.8, 0.0251953125, 0.00002, 0.000000024)]
        //public void ConvertFromBytesManualAssert(double fromMegabtes, long expectedBits, double expectedBytes, double expectedKiloBytes, double expectedMegaBytes, double expectedGigaBytes, double expectedTeraBytes, double expectedPetaBytes) => AssertConverssion(ByteMeasurement.FromMegaBytes(fromMegabtes), expectedBits, expectedBytes, expectedKiloBytes, expectedMegaBytes, expectedGigaBytes, expectedTeraBytes, expectedPetaBytes);

        private void AssertConverssion(ByteMeasurement result, long expectedBits, double expectedBytes, double expectedKiloBytes, double expectedMegaBytes, double expectedGigaBytes, double expectedTeraBytes, double expectedPetaBytes)
        {
            Assert.Equal(expectedBits, result.Bits);
            Assert.Equal(expectedBytes, result.Bytes);
            Assert.Equal(expectedKiloBytes, result.KiloBytes);
            Assert.Equal(expectedMegaBytes, result.MegaBytes);
            Assert.Equal(expectedGigaBytes, result.GigaBytes);
            Assert.Equal(expectedTeraBytes, result.TeraBytes);
            Assert.Equal(expectedPetaBytes, result.PetaBytes);
        }

        #endregion Covnertions
    }
}