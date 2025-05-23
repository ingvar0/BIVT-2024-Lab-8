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

            _output = Input.Split(' ');
            string[] words = new string[0];
            
            for (int i = 0; i < _output.Length;)
            {
                string cur = "";
                int c = _output[i].Length;
                while (c <= 50)
                {
                    cur += _output[i++] + " ";
                    if (i != _output.Length)
                    {
                        c += _output[i].Length + 1;
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
            if (_output.Length == 0 || _output == null)
            {
                return string.Empty;
            }
            return string.Join(Environment.NewLine, _output);  

        }
    }
}