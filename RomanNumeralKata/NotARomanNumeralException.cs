using System;

namespace RomanNumeralKata
{
    public class NotARomanNumeralException:Exception
    {
        internal NotARomanNumeralException(char c)
            : base(string.Format("{0} is not a valid roman numeral", c))
        {
            
        }
    }
}