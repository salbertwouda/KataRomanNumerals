using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumeralKata
{
    public class RomanNumeralConverter : IConvertInt32ToRomanNumeral, IConvertRomanNumeralToInt32
    {
        private readonly Dictionary<char, RomanChar> _charToRomanCharMap
            = RomanChar.AllCharacters.ToDictionary(x => x.Character, x => x);

        public string ConvertInt32ToRomanNumeral(int input)
        {
            if (input > 3000) throw new ArgumentException("Cannot be > 3000", "input");
            if (input < 0) throw new ArgumentException("Cannot be < 0", "input");

            var result = new StringBuilder();
            var leftOver = input;
            while (leftOver > 0)
            {
                var combination = RomanChar.AllCombinationsOrderedByNumberDescending.First(x => leftOver >= x.Number);
                leftOver -= combination.Number;
                result.Append(combination.Label);
            }
            return result.ToString();
        }

        public int ConvertRomanNumeralToInt32(string input)
        {
            var romanCharacters = input.Select(SelectRomanChar);
            return ConvertRomanCharsToIn32(romanCharacters);
        }
        
        private RomanChar SelectRomanChar(char c)
        {
            RomanChar result;
            if (!_charToRomanCharMap.TryGetValue(c, out result))
            {
                throw new NotARomanNumeralException(c);
            }
            return result;
        }

        private int ConvertRomanCharsToIn32(IEnumerable<RomanChar> romanCharacters)
        {
            var decimalValues = romanCharacters.Select(x => x.DecimalValue);

            int? previous = null;
            var currentSum = 0;
            var total = 0;

            foreach (var decimalValue in decimalValues)
            {
                if (!previous.HasValue || previous == decimalValue)
                {
                    currentSum += decimalValue;
                }
                else if (previous < decimalValue)
                {
                    total += decimalValue - currentSum;
                    currentSum = 0;
                }
                else
                {
                    total += currentSum;
                    currentSum = decimalValue;
                }
                previous = decimalValue;
            }
            return total + currentSum;
        }
    }
}