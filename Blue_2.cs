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
            _output = "";
            _sequence = sequence;
        }

        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input) || string.IsNullOrEmpty(_sequence)) return;

            string[] words = Input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string[] tempResult = new string[words.Length];
            int resultCount = 0;

            foreach (string word in words)
            {
                if (word.IndexOf(_sequence, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    tempResult[resultCount++] = word;
                }
            }

            _output = string.Join(" ", tempResult, 0, resultCount).Trim();
        }

        public override string ToString()
        {
            return _output;
        }
    }
}