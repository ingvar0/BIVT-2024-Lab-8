using System;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;
        public string[] Output => _output;

        public Blue_1(string input) : base(input)
        {
            _output = new string[0];
        }

        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input)) return;

            string normalizedInput = Input.Replace("\n", " ").Replace("\r", "");
            while (normalizedInput.Contains("  "))
                normalizedInput = normalizedInput.Replace("  ", " ");

            string[] words = normalizedInput.Split(' ');
            string[] result = new string[words.Length];
            int resultIndex = 0;
            string currentLine = "";

            foreach (string word in words)
            {
                if (word.Length > 50) return;

                if (currentLine.Length == 0)
                {
                    currentLine = word;
                }
                else if (currentLine.Length + 1 + word.Length <= 50)
                {
                    currentLine += " " + word;
                }
                else
                {
                    result[resultIndex++] = currentLine;
                    currentLine = word;
                }
            }

            if (!string.IsNullOrEmpty(currentLine))
                result[resultIndex++] = currentLine;

            _output = new string[resultIndex];
            Array.Copy(result, _output, resultIndex);
        }

        public override string ToString()
        {
            return string.Join("\n", _output);
        }
    }
}