using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_4: Blue
    {
        private int _output;

        public int Output => _output;

        public Blue_4 (string input): base (input)
        {
            _output = 0;
        }

        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input)) return;
            // делим строку по буквам и знакам препинания, кроме минуса (-)
            string[] textSplit = Regex.Split(Input, @"[^\d-]+");
            string textStr = string.Join(" ", textSplit);

            // заменяем d- на d -, чтобы оставить минус у числа
            textStr = Regex.Replace(textStr, @"(\d+)-", "$1 -");
            textSplit = textStr.Split(' ');
            textSplit = textSplit.Where(x => !string.IsNullOrEmpty(x)).ToArray();

            var numbers = new List<int>();
            foreach (string dig in textSplit)
            {
                int digit = StringToInt(dig);
                numbers.Add(digit);
            }

            int summa = 0;
            foreach (int s in numbers)
            {
                summa += s;
            }
            
            _output = summa;
        }

        public override string ToString()
        {
            return _output.ToString();
        }

        // функция, которая конвертирует из строки в число 
        public static int StringToInt(string s)
        {
            int result = 0;
            int sign = 1;
            int i = 0;

            if (s.Length > 0 && s[0] == '-')
            {
                sign = -1;
                i = 1;
            }

            for (; i < s.Length; i++)
            {
                char c = s[i];
                if (c >= '0' && c <= '9')
                {
                    result = result * 10 + (c - '0');
                }
            }

            return result * sign;
        }
    }
}
