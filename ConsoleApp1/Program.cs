using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ToRoman(1990);
            FromRoman("MDCLXVI");
        }

        public static string ToRoman(int n)
        {
            string result = null;

            switch (Digits(n))
            {
                case 1:
                    result = four(GetANumber(n, 1));
                    break;
                case 2:
                    result = three(GetANumber(n, 1)) + four(GetANumber(n, 2));
                    break;
                case 3:
                    result = two(GetANumber(n, 1)) + three(GetANumber(n, 2)) + four(GetANumber(n, 3));
                    break;
                case 4:
                    result = Repeat(Dictionary(1000), n / 1000) + two(GetANumber(n, 2)) + three(GetANumber(n, 3)) + four(GetANumber(n, 4));
                    break;
            }

            Console.WriteLine(result);
            return "";
        }

        public static int FromRoman(string romanNumeral)
        {
            int result = 0;

            for (int i = 0; i < romanNumeral.Length; i++)
            {
                result += int.Parse(DictionaryReverse(romanNumeral[i]).ToString());
            }
            Console.WriteLine(result);

            return 0;
        }

        public static string two(int n)
        {
            string result = "";

            if (n > 4)
            {
                result = Dictionary(500) + Repeat(Dictionary(100), n - 5);
            }
            else
            {
                result = Repeat(Dictionary(100), n);
            }
            return result;
        }

        public static string three(int n)
        {
            string result = "";

            if (n > 4)
            {
                result = Dictionary(50) + Repeat(Dictionary(10), n - 5);
            }
            else
            {
                result = Repeat(Dictionary(10), n);
            }
            return result;
        }
        public static string four(int n)
        {
            string result;

            if (n == 4)
            {
                return "IV";
            }
            else
            {
                if (n > 4)
                {
                    result = Dictionary(5) + Repeat(Dictionary(1), n - 5);
                }
                else
                {
                    result = Repeat(Dictionary(1), n);
                }
                return result;
            }
        }

        static int GetANumber(int n, int variant)
        {
            string str;
            str = Convert.ToString(n);
            switch (variant)
            {
                case 1:
                    return int.Parse(str[0].ToString());
                case 2:
                    return int.Parse(str[1].ToString());
                case 3:
                    return int.Parse(str[2].ToString());
                case 4:
                    return int.Parse(str[3].ToString());
                default:
                    return 0;
            }
        }

        public static int Digits(int number)
        {
            var result = 0;
            while (number > 0)
            {
                number = number / 10;
                result++;
            }
            return result;
        }

        public static string Repeat(string value, int count)
        {
            return string.Concat(Enumerable.Repeat(value, count));
        }

        public static string Dictionary(int n)
        {
            Dictionary<int, string> roman = new Dictionary<int, string>();
            roman.Add(1, "I");
            roman.Add(4, "IV");
            roman.Add(5, "V");
            roman.Add(10, "X");
            roman.Add(50, "L");
            roman.Add(100, "C");
            roman.Add(500, "D");
            roman.Add(1000, "M");

            return roman[n];
        }
        public static int DictionaryReverse(char n)
        {
            Dictionary<char, int> roman = new Dictionary<char, int>();
            roman.Add('I', 1);
            roman.Add('V', 5);
            roman.Add('X', 10);
            roman.Add('L', 50);
            roman.Add('C', 100);
            roman.Add('D', 500);
            roman.Add('M', 1000);

            return roman[n];
        }
    }
}