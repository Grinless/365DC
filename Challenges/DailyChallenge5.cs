using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Challenge
{
    public static class DailyChallenge5
    {
        private const string ROMAN_1 =      "I";
        private const string ROMAN_4 =      "IV";
        private const string ROMAN_5 =      "V";
        private const string ROMAN_9 =      "IX";
        private const string ROMAN_10 =     "X";
        private const string ROMAN_40 =     "XL";
        private const string ROMAN_50 =     "L";
        private const string ROMAN_90 =     "XC";
        private const string ROMAN_100 =    "C";
        private const string ROMAN_400 =    "CD";
        private const string ROMAN_500 =    "D";
        private const string ROMAN_900 =    "CM";
        private const string ROMAN_1000 =   "M";

        public static string ConvertToRoman(int value)
        {
            string result = "";
            int _value = value;

            result += BuildStringSection(_value, ROMAN_1000, 1000, out _value);
            result += BuildStringSection(_value, ROMAN_900, 900, out _value);
            result += BuildStringSection(_value, ROMAN_500, 500, out _value);
            result += BuildStringSection(_value, ROMAN_400, 400, out _value);
            result += BuildStringSection(_value, ROMAN_100, 100, out _value);
            result += BuildStringSection(_value, ROMAN_90, 90, out _value);
            result += BuildStringSection(_value, ROMAN_50, 50, out _value);
            result += BuildStringSection(_value, ROMAN_40, 40, out _value);
            result += BuildStringSection(_value, ROMAN_10, 10, out _value);
            result += BuildStringSection(_value, ROMAN_9, 9, out _value);
            result += BuildStringSection(_value, ROMAN_5, 5, out _value);
            result += BuildStringSection(_value, ROMAN_4, 4, out _value);
            result += BuildStringSection(_value, ROMAN_1, 1, out _value);
            
            return result;
        }

        public static string BuildStringSection(int value, string valueSymb, int divOperator, out int total)
        {
            int multiple, remainder; 
            ModCheck(value, divOperator, out multiple, out remainder);
            total = remainder;
            string output = "";

            if (multiple > 0)
            {
                for (int i = 0; i < multiple; i++)
                {
                    output += valueSymb;
                }
            }

            return output;
        }

        public static void ModCheck(int value, int divOperator, out int multiple, out int remainder)
        {
            remainder = value % divOperator;
            multiple = (value - remainder) / divOperator;
        }
    }
}
