using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output;

        // Возвращаем копию массива вместо оригинала
        public (char, double)[] Output => _output != null ? ((char, double)[])_output.Clone() : null;

        public Blue_3(string input) : base(input)
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
            int k = 0;
            string temp = "";
            char[] punct = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };

            foreach (string word in Input.Split(punct, StringSplitOptions.RemoveEmptyEntries))
            {
                if (word.Length > 0 && char.IsLetter(word[0]))
                {
                    temp += char.ToLower(word[0]);
                }
            }
            (char, double)[] l = new (char, double)[temp.Length];
            for (int i = 0; i < l.Length; i++)
            {
                l[i] = ('\0', 0);
            }
            foreach (char symb in temp)
            {
                bool fl = false;
                for (int i = 0; i < l.Length; i++)
                {
                    if (l[i].Item1 == symb)
                    {
                        l[i] = (symb, l[i].Item2 + 1);
                        fl = true;
                        break;
                    }
                }
                if (!fl)
                {
                    for (int j = 0; j < l.Length; j++)
                    {
                        if (l[j].Item1 == '\0')
                        {
                            l[j] = (symb, 1);
                            k++;
                            break;
                        }
                    }
                }
            }
            int ind = 0;
            var ans = new (char, double)[k];
            foreach (var x in l)
            {
                if (!(x.Item1 == '\0')) 
                {
                    double percent = x.Item2 / temp.Length * 100;
                    ans[ind] = (x.Item1, percent);
                    ind++;
                }
            }

            for (int i = 0; i < ans.Length - 1; i++)
            {
                for (int j = 0; j < ans.Length - i - 1; j++)
                {
                    bool flag = false;

                    if (ans[j].Item2 < ans[j + 1].Item2)
                    {
                        flag = true;
                    }

                    else if (ans[j].Item2 == ans[j + 1].Item2 &&
                             ans[j].Item1 > ans[j + 1].Item1)
                    {
                        flag = true;
                    }

                    if (flag)
                    {
                        var newTemp = ans[j];
                        ans[j] = ans[j + 1];
                        ans[j + 1] = newTemp;
                    }
                }
            }

            _output = ans;
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0)
            {
                return string.Empty;
            }
            return string.Join(Environment.NewLine, Array.ConvertAll(_output, cortege => $"{cortege.Item1} - {cortege.Item2:F4}")); 
        }
    }
}
