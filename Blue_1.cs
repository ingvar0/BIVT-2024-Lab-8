using System;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;
        public string[] Output => _output;

        public Blue_1(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        { 
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }

            string[] words = Input.Split(' ');
            string[] tempResult = new string[0];
            int currentIndex = 0;

            while (currentIndex < words.Length)
            {
                string currentLine = words[currentIndex];
                int lineLength = currentLine.Length;
                int nextIndex = currentIndex + 1;

                // Собираем строку, пока не превысим 50 символов
                while (nextIndex < words.Length && lineLength + 1 + words[nextIndex].Length <= 50)
                {
                    currentLine += " " + words[nextIndex];
                    lineLength += 1 + words[nextIndex].Length;
                    nextIndex++;
                }

                // Добавляем строку в результат 
                string[] newTemp = new string[tempResult.Length + 1];
                for (int i = 0; i < tempResult.Length; i++)
                {
                    newTemp[i] = tempResult[i];
                }
                newTemp[tempResult.Length] = currentLine;
                tempResult = newTemp;

                currentIndex = nextIndex;
            }

            _output = tempResult; 
        }
        

        public override string ToString()
        {
            if (string.Join(Environment.NewLine, _output) == "" || string.Join(Environment.NewLine, _output) == " ")
            {
                return null;
            }
            return string.Join(Environment.NewLine, _output); 
        }
    }
}