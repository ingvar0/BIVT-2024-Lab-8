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
            _output = Array.Empty<(char, double)>();
            _counter = Array.Empty<int>();
        }

        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input)) return;

            _output = Array.Empty<(char, double)>();
            _counter = Array.Empty<int>();
            double sum = 0;

            string[] words = Input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string word in words)
            {
                if (string.IsNullOrEmpty(word)) continue;

                for (int k = 0; k < word.Length; k++)
                {
                    if (!char.IsLetter(word[k])) continue;

                    char firstLetter = char.ToLower(word[k]);
                    sum++;

                    bool found = false;
                    for (int j = 0; j < _output.Length; j++)
                    {
                        if (_output[j].letter == firstLetter)
                        {
                            _counter[j]++;
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        Array.Resize(ref _output, _output.Length + 1);
                        Array.Resize(ref _counter, _counter.Length + 1);
                        _output[_output.Length - 1] = (firstLetter, 0);
                        _counter[_counter.Length - 1] = 1;
                    }
                    break; 
                }
            }

            for (int i = 0; i < _output.Length; i++)
            {
                _output[i].ratio = Math.Round((_counter[i] * 100.0) / sum, 4);
            }

            Sort();
        }

        private void Sort()
        {
            for (int i = 0; i < _output.Length; i++)
            {
                for (int j = 0; j < _output.Length - i - 1; j++)
                {
                    if ((_output[j].ratio < _output[j + 1].ratio)
                        || ((_output[j].ratio == _output[j + 1].ratio)
                        && (_output[j].letter > _output[j + 1].letter)))
                    {
                        (_output[j], _output[j + 1]) = (_output[j + 1], _output[j]);
                        (_counter[j], _counter[j + 1]) = (_counter[j + 1], _counter[j]);
                    }
                }
            }
        }

        public override string ToString()
        {
            if (_output.Length == 0) return string.Empty;

            var result = new System.Text.StringBuilder();
            for (int i = 0; i < _output.Length; i++)
            {
                if (i > 0) result.Append('\n');
                result.Append($"{_output[i].letter}-{_output[i].ratio:F4}");
            }
            return result.ToString();
        }
    }
}
