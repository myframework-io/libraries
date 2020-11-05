using Myframework.Libraries.Common.Extensions;
using Myframework.Libraries.Common.Helpers;
using System;
using Xunit;

namespace Common.Helpers
{
    public class RandomHelperTest
    {
        [Theory(DisplayName = "Random string")]
        [InlineData(50, "ABC", "DEFGHIJKLMNOPQRSTUVWXYZ0123456789")]
        [InlineData(50, "123", "ABCDEFGHIJKLMNOPQRSTUVWXYZ0456789")]
        [InlineData(50, "0", "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789")]
        [InlineData(50, "AQP", "BCDEFGHIJKLMNORSTUVWXYZ0123456789")]
        [InlineData(50, "000", "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789")]
        public void RandomString(int length, string chars, string notAllowedChars)
        {
            string random = RandomHelper.RandomString(length, chars);

            Assert.Equal(length, random.Length);

            foreach (char character in notAllowedChars)
            {
                Assert.False(random.Contains(character));
            }
        }

        [Theory(DisplayName = "Random byte")]
        [InlineData(byte.MinValue, byte.MaxValue)]
        [InlineData(50, 100)]
        [InlineData(60, 50)]
        [InlineData(50, 50)]
        [InlineData(0, 0)]
        public void RandomByte(byte minValue, byte maxValue)
        {
            byte random = RandomHelper.RandomByte(minValue, maxValue);

            if (minValue > maxValue)
                Assert.Equal(maxValue, random);
            else
                Assert.True(random.ItsBetween(minValue, maxValue));

            Assert.True(random.ItsBetween(byte.MinValue, byte.MaxValue));
        }

        [Theory(DisplayName = "Random short")]
        [InlineData(short.MinValue, short.MaxValue)]
        [InlineData(50, 100)]
        [InlineData(60, 50)]
        [InlineData(-1, -2)]
        [InlineData(-53, 50)]
        [InlineData(-100, -50)]
        [InlineData(50, 50)]
        public void RandomShort(short minValue, short maxValue)
        {
            short random = RandomHelper.RandomShort(minValue, maxValue);

            if (minValue > maxValue)
                Assert.Equal(maxValue, random);
            else
                Assert.True(random.ItsBetween(minValue, maxValue));

            Assert.True(random.ItsBetween(short.MinValue, short.MaxValue));
        }

        [Theory(DisplayName = "Random int")]
        [InlineData(int.MinValue, int.MaxValue)]
        [InlineData(50, 100)]
        [InlineData(60, 50)]
        [InlineData(-1, -2)]
        [InlineData(-53, 50)]
        [InlineData(-100, -50)]
        [InlineData(50, 50)]
        public void RandomInt(int minValue, int maxValue)
        {
            int random = RandomHelper.RandomInt(minValue, maxValue);

            if (minValue > maxValue)
                Assert.Equal(maxValue, random);
            else
                Assert.True(random.ItsBetween(minValue, maxValue));

            Assert.True(random.ItsBetween(int.MinValue, int.MaxValue));
        }

        [Fact(DisplayName = "Random float")]
        public void RandomFloat()
        {
            float random = RandomHelper.RandomFloat();
            Assert.True(random.ItsBetween(float.MinValue, float.MaxValue));
        }

        [Theory(DisplayName = "Random DateTime")]
        [InlineData(1900)]
        [InlineData(1500)]
        [InlineData(2010)]
        [InlineData(2013)]
        [InlineData(2151)]
        public void RandomDateTime(int minYear)
        {
            DateTime random = RandomHelper.RandomDateTime(minYear);
            Assert.True(random.GreaterThanOrEqual(new DateTime(minYear, 1, 1)));
            Assert.True(random.ItsBetween(DateTime.MinValue, DateTime.MaxValue));
        }
    }
}