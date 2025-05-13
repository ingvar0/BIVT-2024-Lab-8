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
            if (string.IsNullOrEmpty(Input) || string.IsNullOrEmpty(_sequence)) return;

            string[] words = Input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] tempResult = new string[words.Length];
            int resultCount = 0;

            foreach (string word in words)
            {
                // Находим индекс первой буквы
                int firstLetterIndex = 0;
                while (firstLetterIndex < word.Length && !char.IsLetter(word[firstLetterIndex]))
                {
                    firstLetterIndex++;
                }

                // Находим индекс последней буквы
                int lastLetterIndex = word.Length - 1;
                while (lastLetterIndex >= 0 && !char.IsLetter(word[lastLetterIndex]))
                {
                    lastLetterIndex--;
                }

                // Если слово состоит только из пунктуации то оставляем как есть
                if (firstLetterIndex > lastLetterIndex)
                {
                    tempResult[resultCount++] = word;
                    continue;
                }

                // Выделяем слово (без пунктуации по краям)
                string cleanedWord = word.Substring(firstLetterIndex, lastLetterIndex - firstLetterIndex + 1);

                // Если слово не содержит _seq добавляем в результат
                if (cleanedWord.IndexOf(_sequence, StringComparison.OrdinalIgnoreCase) < 0)
                {
                    tempResult[resultCount++] = word;
                }
                // Если содержит _seq добавляем только пунктуацию (если она есть)
                else
                {
                    // Добавляем пунктуацию ДО слова (если была)
                    if (firstLetterIndex > 0)
                    {
                        string punctuationBefore = word.Substring(0, firstLetterIndex);
                        tempResult[resultCount++] = punctuationBefore;
                    }

                    // Добавляем пунктуацию ПОСЛЕ слова (если была)
                    if (lastLetterIndex < word.Length - 1)
                    {
                        string punctuationAfter = word.Substring(lastLetterIndex + 1);
                        tempResult[resultCount++] = punctuationAfter;
                    }
                }
            }


            _output = string.Join(" ", tempResult, 0, resultCount).Replace(" ,", ",").Replace(" .", ".").Replace(" !", "!").Replace(" ?", "?").Replace(" ;", ";").Replace(" :", ":").Replace("  ", " ").Trim();
        }

        public override string ToString()
        {
            return _output;
        }
    }
}