using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_1: Blue
    {
        private List<string> _output;
        public List<string> Output => _output;
        public Blue_1(string input) : base(input)
        {
            _output = new List<string>();
        }

        public override void Review()
        {
            if (string.IsNullOrWhiteSpace(Input)) return;
            string[] text = Regex.Split(Input, @"\s+");
            List<string> wordsList = new List<string>(text);

            // пока текст не кончится, добавляем line в output 
            while (wordsList.Count != 0)
            {
                // создаем строку (<= 50 символов)
                int countOfLength = 0;
                List<string> line = new List<string>();
                if (wordsList[0].Length > 50) return;

                // считаем количество символов в слове и добавляем в строку, если подходит
                while ((countOfLength + wordsList[0].Length) <= 50)
                {
                    // +1 - это пробел (рассматриваем два случая)
                    if ((countOfLength + wordsList[0].Length + 1) <= 50)
                    {
                        countOfLength += wordsList[0].Length + 1;

                        // добавляем слово в строку
                        line.Add(wordsList[0]);

                        // удаляем слово из главного текста
                        wordsList.RemoveAt(0);
                    }
                    else
                    {
                        line.Add(wordsList[0]);
                        wordsList.RemoveAt(0);
                        break;
                    }

                    if (wordsList.Count == 0) break;
                    if (wordsList[0].Length > 50) return;
                }

                string readyLine = string.Join(" ", line);
                readyLine = readyLine.Trim();   
                _output.Add(readyLine);
            }
        }

        public override string ToString()
        {
            return string.Join("\n", _output);
        }
    }
}