using System;
using System.Globalization;

namespace Myframework.Libraries.Common.UnitsOfMeasurement
{
    /// <summary>
    /// Represents a byte size value.
    /// </summary>
    public struct ByteMeasurement : IComparable<ByteMeasurement>, IEquatable<ByteMeasurement>
    {
        public static readonly ByteMeasurement MinValue = FromBits(0);
        public static readonly ByteMeasurement MaxValue = FromBits(long.MaxValue);

        //https://pt.wikipedia.org/wiki/Gibibyte
        public const long BitsInByte = 8;
        public const long BytesInKiloByte = 1024;
        public const long BytesInMegaByte = 1048576;
        public const long BytesInGigaByte = 1073741824;
        public const long BytesInTeraByte = 1099511627776;
        public const long BytesInPetaByte = 1125899906842624;

        public const string BitSymbol = "b";
        public const string ByteSymbol = "B";
        public const string KiloByteSymbol = "KB";
        public const string MegaByteSymbol = "MB";
        public const string GigaByteSymbol = "GB";
        public const string TeraByteSymbol = "TB";
        public const string PetaByteSymbol = "PB";

        public long Bits { get; private set; }
        public double Bytes { get; private set; }
        public double KiloBytes => Bytes / BytesInKiloByte;
        public double MegaBytes => Bytes / BytesInMegaByte;
        public double GigaBytes => Bytes / BytesInGigaByte;
        public double TeraBytes => Bytes / BytesInTeraByte;
        public double PetaBytes => Bytes / BytesInPetaByte;

        public string LargestWholeNumberSymbol
        {
            get
            {
                // Absolute value is used to deal with negative values
                if (Math.Abs(PetaBytes) >= 1)
                    return PetaByteSymbol;

                if (Math.Abs(TeraBytes) >= 1)
                    return TeraByteSymbol;

                if (Math.Abs(GigaBytes) >= 1)
                    return GigaByteSymbol;

                if (Math.Abs(MegaBytes) >= 1)
                    return MegaByteSymbol;

                if (Math.Abs(KiloBytes) >= 1)
                    return KiloByteSymbol;

                if (Math.Abs(Bytes) >= 1)
                    return ByteSymbol;

                return BitSymbol;
            }
        }

        public double LargestWholeNumberValue
        {
            get
            {
                // Absolute value is used to deal with negative values
                if (Math.Abs(PetaBytes) >= 1)
                    return PetaBytes;

                if (Math.Abs(TeraBytes) >= 1)
                    return TeraBytes;

                if (Math.Abs(GigaBytes) >= 1)
                    return GigaBytes;

                if (Math.Abs(MegaBytes) >= 1)
                    return MegaBytes;

                if (Math.Abs(KiloBytes) >= 1)
                    return KiloBytes;

                if (Math.Abs(Bytes) >= 1)
                    return Bytes;

                return Bits;
            }
        }

        public ByteMeasurement(double ByteMeasurement)
            : this()
        {
            // Get ceiling because bits are whole units
            Bits = (long)Math.Ceiling(ByteMeasurement * BitsInByte);

            Bytes = ByteMeasurement;
        }

        public static ByteMeasurement FromBits(long value) => new ByteMeasurement(value / (double)BitsInByte);

        public static ByteMeasurement FromBytes(double value) => new ByteMeasurement(value);

        public static ByteMeasurement FromKiloBytes(double value) => new ByteMeasurement(value * BytesInKiloByte);

        public static ByteMeasurement FromMegaBytes(double value) => new ByteMeasurement(value * BytesInMegaByte);

        public static ByteMeasurement FromGigaBytes(double value) => new ByteMeasurement(value * BytesInGigaByte);

        public static ByteMeasurement FromTeraBytes(double value) => new ByteMeasurement(value * BytesInTeraByte);

        public static ByteMeasurement FromPetaBytes(double value) => new ByteMeasurement(value * BytesInPetaByte);

        /// <summary>
        /// Converts the value of the current ByteMeasurement object to a string.
        /// The metric prefix symbol (bit, byte, kilo, mega, giga, tera) used is
        /// the largest metric prefix such that the corresponding value is greater
        //  than or equal to one.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => ToString("0.##", CultureInfo.CurrentCulture);

        public string ToString(string format) => ToString(format, CultureInfo.CurrentCulture);

        public string ToString(string format, IFormatProvider provider)
        {
            if (!format.Contains("#") && !format.Contains("0"))
                format = "0.## " + format;

            if (provider == null) provider = CultureInfo.CurrentCulture;

            Func<string, bool> has = s => format.IndexOf(s, StringComparison.CurrentCultureIgnoreCase) != -1;
            Func<double, string> output = n => n.ToString(format, provider);

            if (has("PB"))
                return output(PetaBytes);
            if (has("TB"))
                return output(TeraBytes);
            if (has("GB"))
                return output(GigaBytes);
            if (has("MB"))
                return output(MegaBytes);
            if (has("KB"))
                return output(KiloBytes);

            // Byte and Bit symbol must be case-sensitive
            if (format.IndexOf(ByteMeasurement.ByteSymbol) != -1)
                return output(Bytes);

            if (format.IndexOf(ByteMeasurement.BitSymbol) != -1)
                return output(Bits);

            return string.Format("{0} {1}", LargestWholeNumberValue.ToString(format, provider), LargestWholeNumberSymbol);
        }

        public override bool Equals(object value)
        {
            if (value == null)
                return false;

            ByteMeasurement other;
            if (value is ByteMeasurement)
                other = (ByteMeasurement)value;
            else
                return false;

            return Equals(other);
        }

        public bool Equals(ByteMeasurement value) => Bits == value.Bits;

        public override int GetHashCode() => Bits.GetHashCode();

        public int CompareTo(ByteMeasurement other) => Bits.CompareTo(other.Bits);

        public ByteMeasurement Add(ByteMeasurement bs) => new ByteMeasurement(Bytes + bs.Bytes);

        public ByteMeasurement AddBits(long value) => this + FromBits(value);

        public ByteMeasurement AddBytes(double value) => this + ByteMeasurement.FromBytes(value);

        public ByteMeasurement AddKiloBytes(double value) => this + ByteMeasurement.FromKiloBytes(value);

        public ByteMeasurement AddMegaBytes(double value) => this + ByteMeasurement.FromMegaBytes(value);

        public ByteMeasurement AddGigaBytes(double value) => this + ByteMeasurement.FromGigaBytes(value);

        public ByteMeasurement AddTeraBytes(double value) => this + ByteMeasurement.FromTeraBytes(value);

        public ByteMeasurement AddPetaBytes(double value) => this + ByteMeasurement.FromPetaBytes(value);

        public ByteMeasurement Subtract(ByteMeasurement bs) => new ByteMeasurement(Bytes - bs.Bytes);

        public static ByteMeasurement operator +(ByteMeasurement b1, ByteMeasurement b2) => new ByteMeasurement(b1.Bytes + b2.Bytes);

        /// <summary>
        /// Incrementa os bytes em 1. 
        /// Atenção, mesmo que essa classe tenha sido iniciada com outra medida, como megabyte por exemplo, a operação é feita sobre os bytes.
        /// </summary>
        /// <param name="measure"></param>
        /// <returns></returns>
        public static ByteMeasurement operator ++(ByteMeasurement measure) => new ByteMeasurement(measure.Bytes + 1);

        public static ByteMeasurement operator -(ByteMeasurement measure) => new ByteMeasurement(-measure.Bytes);

        public static ByteMeasurement operator -(ByteMeasurement measure1, ByteMeasurement measure2) => new ByteMeasurement(measure1.Bytes - measure2.Bytes);

        public static ByteMeasurement operator --(ByteMeasurement measure) => new ByteMeasurement(measure.Bytes - 1);

        public static bool operator ==(ByteMeasurement measure1, ByteMeasurement measure2) => measure1.Bits == measure2.Bits;

        public static bool operator !=(ByteMeasurement measure1, ByteMeasurement measure2) => measure1.Bits != measure2.Bits;

        public static bool operator <(ByteMeasurement measure1, ByteMeasurement measure2) => measure1.Bits < measure2.Bits;

        public static bool operator <=(ByteMeasurement measure1, ByteMeasurement measure2) => measure1.Bits <= measure2.Bits;

        public static bool operator >(ByteMeasurement measure1, ByteMeasurement measure2) => measure1.Bits > measure2.Bits;

        public static bool operator >=(ByteMeasurement measure1, ByteMeasurement measure2) => measure1.Bits >= measure2.Bits;

        public static ByteMeasurement Parse(string s)
        {
            // Arg checking
#if NET35
            if (string.IsNullOrEmpty(s) || s.Trim() == "")
                throw new ArgumentNullException("s", "String is null or whitespace");
#else
            if (string.IsNullOrWhiteSpace(s))
                throw new ArgumentNullException("s", "String is null or whitespace");
#endif

            // Get the index of the first non-digit character
            s = s.TrimStart(); // Protect against leading spaces

            int num = 0;
            bool found = false;

            char decimalSeparator = Convert.ToChar(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
            char groupSeparator = Convert.ToChar(NumberFormatInfo.CurrentInfo.NumberGroupSeparator);

            // Pick first non-digit number
            for (num = 0; num < s.Length; num++)
                if (!(char.IsDigit(s[num]) || s[num] == decimalSeparator || s[num] == groupSeparator))
                {
                    found = true;
                    break;
                }

            if (found == false)
                throw new FormatException($"No byte indicator found in value '{ s }'.");

            int lastNumber = num;

            // Cut the input string in half
            string numberPart = s.Substring(0, lastNumber).Trim();
            string sizePart = s.Substring(lastNumber, s.Length - lastNumber).Trim();

            // Get the numeric part
            if (!double.TryParse(numberPart, NumberStyles.Float | NumberStyles.AllowThousands, NumberFormatInfo.CurrentInfo, out double number))
                throw new FormatException($"No number found in value '{ s }'.");

            // Get the magnitude part
            switch (sizePart)
            {
                case "b":
                    if (number % 1 != 0) // Can't have partial bits
                        throw new FormatException($"Can't have partial bits for value '{ s }'.");

                    return FromBits((long)number);

                case "B":
                    return FromBytes(number);

                case "KB":
                case "kB":
                case "kb":
                    return FromKiloBytes(number);

                case "MB":
                case "mB":
                case "mb":
                    return FromMegaBytes(number);

                case "GB":
                case "gB":
                case "gb":
                    return FromGigaBytes(number);

                case "TB":
                case "tB":
                case "tb":
                    return FromTeraBytes(number);

                case "PB":
                case "pB":
                case "pb":
                    return FromPetaBytes(number);

                default:
                    throw new FormatException($"Bytes of magnitude '{ sizePart }' is not supported.");
            }
        }

        public static bool TryParse(string s, out ByteMeasurement result)
        {
            try
            {
                result = Parse(s);
                return true;
            }
            catch
            {
                result = new ByteMeasurement();
                return false;
            }
        }
    }
}