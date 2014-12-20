namespace RomanNumeralKata
{
    public interface IConvertRomanNumeralToInt32
    { 
        /// <summary>
        /// Takes a string of roman numeral characters and returns its integer representation
        /// 
        /// Throws a NotARomanNumeralException when an invalid character is found.
        /// Valid characters:
        /// I, V, X, L, C, D, M
        /// </summary>
        ///  <param name="input"></param>
        /// <returns></returns>
        int ConvertRomanNumeralToInt32(string input);
    }
}