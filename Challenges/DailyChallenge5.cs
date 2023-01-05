using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Challenge
{
    public static class DailyChallenge5
    {
        public static string ConvertToRoman(int value)
        {
            string result = "";
            int _value = value;

            result += BuildStringSection(_value, "M", 1000, out _value);
            result += BuildStringSection(_value, "CM", 900, out _value);
            result += BuildStringSection(_value, "D", 500, out _value);
            result += BuildStringSection(_value, "CD", 400, out _value);
            result += BuildStringSection(_value, "C", 100, out _value);
            result += BuildStringSection(_value, "XC", 90, out _value);
            result += BuildStringSection(_value, "L", 50, out _value);
            result += BuildStringSection(_value, "XL", 40, out _value);
            result += BuildStringSection(_value, "X", 10, out _value);
            result += BuildStringSection(_value, "IX", 9, out _value);
            result += BuildStringSection(_value, "V", 5, out _value);
            result += BuildStringSection(_value, "IV", 4, out _value);
            result += BuildStringSection(_value, "I", 1, out _value);
            
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
