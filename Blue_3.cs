using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char letter, double ratio)[] _output;
        private int[] _counter;

        public (char letter, double ratio)[] Output => _output;

        public Blue_3(string input) : base(input)
        {
            _output = null;
            _counter = Array.Empty<int>();
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
                return;

            // Знаки препинания для разделения слов
            char[] separators = { ' ', '.', '!', '?', ',', ':', '"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };

            // Собираем первые буквы всех слов
            string firstLetters = "";
            foreach (string word in Input.Split(separators, StringSplitOptions.RemoveEmptyEntries))
            {
                if (word.Length > 0 && char.IsLetter(word[0]))
                {
                    firstLetters += char.ToLower(word[0]);
                }
            }

            // Считаем сколько раз встречается каждая буква
            (char, int)[] counts = new (char, int)[firstLetters.Length];
            int uniqueCount = 0;

            foreach (char letter in firstLetters)
            {
                bool found = false;
                for (int i = 0; i < uniqueCount; i++)
                {
                    if (counts[i].Item1 == letter)
                    {
                        counts[i].Item2++;
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    counts[uniqueCount] = (letter, 1);
                    uniqueCount++;
                }
            }

            // Переводим в проценты
            _output = new (char, double)[uniqueCount];
            for (int i = 0; i < uniqueCount; i++)
            {
                double percent = (counts[i].Item2 * 100.0) / firstLetters.Length;
                _output[i] = (counts[i].Item1, percent);
            }

            // Сортируем результаты
            for (int i = 0; i < _output.Length - 1; i++)
            {
                for (int j = i + 1; j < _output.Length; j++)
                {
                    if (_output[i].Item2 < _output[j].Item2 || (_output[i].Item2 == _output[j].Item2 && _output[i].Item1 > _output[j].Item1))
                    {
                        var temp = _output[i];
                        _output[i] = _output[j];
                        _output[j] = temp;
                    }
                }
            }
        }


        public override string ToString()
        {
            if (_output == null)
                return null;

            string result = "";
            for (int i = 0; i < _output.Length; i++)
            {
                result += $"{_output[i].Item1} - {_output[i].Item2:F4}";
                if (i < _output.Length - 1)
                    result += Environment.NewLine;
            }
            return result;
        }
    }
}