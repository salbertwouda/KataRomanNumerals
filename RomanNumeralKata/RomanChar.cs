using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace RomanNumeralKata
{
    internal class RomanChar
    {
        public char Character { get; private set; }
        public int DecimalValue { get; private set; }
        public RomanChar SubtractableBy { get; private set; }

        private RomanChar(char character, int decimalValue)
        {
            Character = character;
            DecimalValue = decimalValue;
        }

        private RomanChar(char character, int decimalValue, RomanChar subtractableBy)
            :this(character, decimalValue)
        {
            SubtractableBy = subtractableBy;
        }

        public override string ToString()
        {
            return Character.ToString(CultureInfo.InvariantCulture);
        }

        private static readonly RomanChar I = new RomanChar('I', 1);
        private static readonly RomanChar V = new RomanChar('V', 5, I);
        private static readonly RomanChar X = new RomanChar('X', 10, I);
        private static readonly RomanChar L = new RomanChar('L', 50, X);
        private static readonly RomanChar C = new RomanChar('C', 100, X);
        private static readonly RomanChar D = new RomanChar('D', 500, C);
        private static readonly RomanChar M = new RomanChar('M', 1000, C);

        public static readonly RomanChar[] AllCharacters =
        {
            I, V, X, L, C, D, M
        };

        public static readonly IEnumerable<Combination> AllCombinationsOrderedByNumberDescending = ComputeAllCombinationsOrderedByNumber();
        private static IEnumerable<Combination> ComputeAllCombinationsOrderedByNumber()
        {
            return AllCharacters.Select(x =>
            {
                var subtractableBy = x.SubtractableBy;
                var result = new List<Combination>();

                if (subtractableBy != null)
                {
                    var label = string.Format("{0}{1}", subtractableBy.Character, x.Character);
                    var decimalValue = x.DecimalValue - subtractableBy.DecimalValue;
                    result.Add(new Combination(label, decimalValue));
                }

                result.Add(new Combination(x.Character.ToString(CultureInfo.InvariantCulture), x.DecimalValue));

                return result;
            }).SelectMany(x => x)
                .OrderByDescending(x => x.Number)
                .ToArray();
        }

        public class Combination
        {
            internal Combination(string label, int number)
            {
                Label = label;
                Number = number;
            }

            public int Number { get; private set; }
            public string Label { get; private set; }
        }
    }
}