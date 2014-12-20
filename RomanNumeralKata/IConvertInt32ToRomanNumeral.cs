namespace RomanNumeralKata
{
    public interface IConvertInt32ToRomanNumeral
    {   
        /// <summary>
        /// Returns a roman numeral in string form for given input
        /// 
        /// throws argumentException when 3000 &lt; input &lt; 0
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        string ConvertInt32ToRomanNumeral(int input);
    }
}