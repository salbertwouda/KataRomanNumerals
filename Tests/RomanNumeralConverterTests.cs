using System;
using NUnit.Framework;
using RomanNumeralKata;

namespace Tests
{
    [TestFixture]
    public class RomanNumeralConverterTests
    {
        private RomanNumeralConverter _subject;

        [SetUp]
        public void Setup()
        {
            _subject = new RomanNumeralConverter();
        }

        [TestCase(1, "I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(50, "L")]
        [TestCase(100, "C")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]
        [TestCase(4, "IV")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(80, "LXXX")]
        [TestCase(2751, "MMDCCLI")]
        [TestCase(1990, "MCMXC")]
        [TestCase(2008, "MMVIII")]
        [TestCase(1748, "MDCCXLVIII")]
        public void ConvertInt32ToRomanNumeral_ValidInput(int input, string expected)
        {
            var result = _subject.ConvertInt32ToRomanNumeral(input);

            Assert.AreEqual(expected, result);
        }

        [TestCase(3001)]
        [TestCase(-1)]
        public void ConvertInt32ToRomanNumeral_InvalidInput(int input)
        {
            Assert.Throws<ArgumentException>(() => _subject.ConvertInt32ToRomanNumeral(input));
        }

        [TestCase("I", 1)]
        [TestCase("V", 5)]
        [TestCase("X", 10)]
        [TestCase("L", 50)]
        [TestCase("C", 100)]
        [TestCase("D", 500)]
        [TestCase("M", 1000)]
        [TestCase("IV", 4)]
        [TestCase("VII", 7)]
        [TestCase("VIII", 8)]
        [TestCase("LXXX", 80)]
        [TestCase("MMDCCLI", 2751)]
        [TestCase("MCMXC", 1990)]
        [TestCase("MMVIII", 2008)]
        public void ConvertRomanNumeralToInt32_ValidInput(string input, int expected)
        {
            var result = _subject.ConvertRomanNumeralToInt32(input);

            Assert.AreEqual(expected, result);
        }

        [TestCase("i")]
        [TestCase("a")]
        public void ConvertRomanNumeralToInt32_InvalidInput(string input)
        {
            Assert.Throws<NotARomanNumeralException>(() => _subject.ConvertRomanNumeralToInt32(input));
        }
    }
}