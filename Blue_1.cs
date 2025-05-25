using System;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;
        
        // Возвращаем копию массива вместо оригинала
        public string[] Output => _output != null ? (string[])_output.Clone() : null;

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

            var tempOutput = Input.Split(' ');
            string[] words = new string[0];

            for (int i = 0; i < tempOutput.Length;)
            {
                string cur = "";
                int c = tempOutput[i].Length;
                while (c <= 50)
                {
                    cur += tempOutput[i++] + " ";
                    if (i != tempOutput.Length)
                    {
                        c += tempOutput[i].Length + 1;
                    }
                    else
                    {
                        break;
                    }
                }

                string[] myStrings = new string[words.Length + 1]; 
                Array.Copy(words, myStrings, words.Length);
                myStrings[words.Length] = cur.Substring(0, cur.Length - 1);
                words = myStrings;
            }
            _output = words;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
            {
                return string.Empty;
            }
            return string.Join(Environment.NewLine, _output);  
        }
    }
}
