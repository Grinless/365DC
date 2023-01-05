using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _365Challenge
{
    //DAY 1  •  Longest Palindromic Substring
    //Given a string s, return the longest palindromic substring in s.
    //---Example 1:---
    //Input: s = "babad"
    //Output: "bab"
    //Explanation: "aba" is also a valid answer.
    //---Example 2:---
    //Input: s = "cbbd"
    //Output: "bb"
    //---Constraints:---
    //•  1 <= s.length <= 1000
    //•  s consist of only digits and English letters.
    //NOTE:
    //Palindromic: A string is palindromic if it reads the same forward and backward.

    public static class WeeklyChallenge1
    {
        public static string GetLargestPlaindrome(string value)
        {
            char[] _charValue = value.ToCharArray();
            List<string> _palindromics = new List<string>();

            //Determine if odd or even. 
            bool odd = CheckIfOdd(_charValue);
#if DEBUG
            Console.WriteLine(String.Format("String is {0} characters long, and thus is {1}.", _charValue.Length, (odd) ? "odd" : "even"));
#endif

            //Build substring list. 
            char[] longestSubString = (0x00).ToString().ToCharArray();

            for (int i = 1; i < _charValue.Length - 1; i++)
            {
                _palindromics.Add(SubstringGet(_charValue, i, odd));
            }

            foreach (string item in _palindromics)
            {
#if DEBUG
                Console.WriteLine("\n" + item.ToString() + "\n");
#endif
                if (longestSubString.Length < item.Length)
                {
                    longestSubString = item.ToArray();
                }
            }

            return "";
        }

        private static bool CheckIfOdd(char[] chars) => (chars.Length % 2 != 0);

        private static string SubstringGet(char[] chars, int pivot, bool odd)
        {
            int n = chars.Length, p = pivot, index = 1;
            string substring = "";

            //Check inital pivot placement is correct/pivot is not extrema. 
            if (CheckLength(odd, n) || CheckPivotIsExtrema(p, n))
            {
#if DEBUG
                PrintPivot(pivot, false);
#endif
                return (0x00).ToString();
            }

#if DEBUG
            PrintPivot(pivot, true);
#endif

            while (index < n)
            {
                if (((pivot - index) == 0 || (pivot + index) == n)) break;
                if ((chars[pivot - index] != chars[pivot + index])) break;

                if (odd)
                    SubstringAlg_Odd(chars, pivot); 
                else
                {
                    if ((pivot + index) == 0)
                        break;
                }

                index++;
            }
            return substring;
        }

        private static char[] SubstringAlg_Odd(char[] chars, int pivot)
        {
            int n = chars.Length, p = pivot, index = 1;
            string substring = "";

            while (index < n)
            {
                if (((pivot - index) == 0 || (pivot + index) == n)) break;
                if ((chars[pivot - index] != chars[pivot + index])) break;

                if (index == 1)
                    substring = chars[pivot].ToString();

                substring = BuildCharArr(chars[pivot - index], chars[pivot + index], substring.ToCharArray()).ToString();
                index++;
            }

            return substring.ToCharArray(); 
        }

        private static char[] BuildCharArr(char value1, char value2, char[] inital) {
            List<char> list = new List<char>();
            list.Add(value1);
            list.AddRange(inital);
            list.Add(value2);
            return list.ToArray();
        }

        private static bool CheckLength(bool odd, int arrLength) => ((odd && arrLength < 3) || (!odd && arrLength <= 3));

        private static bool CheckPivotIsExtrema(int pivot, int arrLength) => (pivot == 0 || pivot == arrLength); //Check if pivot is set to inital index, or end index. 

        private static void PrintCharArray(string descriptor, char[] value)
        {
            Console.WriteLine(String.Format("MSG: {0}. Value: {1}", descriptor, value.ToString()));
        }

        const string MSG_CANCHECK = "Can check pivot point";
        const string MSG_CANNOTCHECK = "Cannot check pivot point";

        private static void PrintPivot(int value, bool checkable)
        {
            Console.WriteLine(String.Format("<MSG: {0} Index: {1}>", (checkable)? MSG_CANCHECK:MSG_CANNOTCHECK, value));
        }
    }
}
