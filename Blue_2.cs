using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2: Blue
    {
        private string _sequence;
        private string _output;

        public string Output => _output;

        public Blue_2 (string input, string sequence) : base(input)
        {
            _output = "";
            _sequence = sequence;
        }

        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input) || string.IsNullOrEmpty(_sequence)) return;

            // Создаём массив слов, разделенные минимум 1 пробелом
            string[] textSplit = Regex.Split(Input, @"\s+");
            List<string> text = new List<string>(textSplit);

            for (int i = 0; i < text.Count; i++)
            {
                // если последовательность есть в слове, то удаляем его из текста
                if (text[i].IndexOf(_sequence, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    text.RemoveAt(i);
                    i--;
                }
            }
            _output = Regex.Replace(string.Join(" ", text), @"\s+", " ").Trim();
        }

        public override string ToString()
        {
            return _output;
        }
    }
}
