using System;

namespace Lab_8
{
    public class Blue_2 : Blue
    {
        private string _sequence;
        private string _output;

        public string Output => _output;

        public Blue_2(string input, string sequence) : base(input)
        {
            _output = null;
            _sequence = sequence;
        }

        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input))
            {
                _output = null;
                return;
            }

            char[] separators = { ' ', '.', '!', '?', ',', ':', '"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            string[] words = Input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            string result = Input;

            foreach (string word in words)
            {
                if (word.IndexOf(_sequence, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    result = result.Replace(word, "");
                }
            }

            // Удаляем лишние пробелы
            while (result.Contains("  "))
                result = result.Replace("  ", " ");

            char[] punctuationMarks = { '.', '!', '?', ',', ':', ';', ')', ']', '}' };

            // Удаляем пробелы перед знаками препинания
            foreach (char mark in punctuationMarks)
            {
                string spaceBeforeMark = " " + mark;
                while (result.Contains(spaceBeforeMark))
                {
                    result = result.Replace(spaceBeforeMark, mark.ToString());
                }
            }

            result = result.Trim();

            _output = result;
        }

        public override string ToString()
        {
            return _output;
        }
    }
}