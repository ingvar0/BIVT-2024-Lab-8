using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using System;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;
        public int Output => _output;

        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }
        public override void Review()
        {
            int n = 0;

            foreach (char x in Input)
            {
                if (char.IsDigit(x))
                {
                    n = n * 10 + (x - '0');
                }
                else
                {
                    _output += n;
                    n = 0;
                }
            }
            _output += n;
        }
        public override string ToString()
        {
            return _output.ToString();
        }
    }
}