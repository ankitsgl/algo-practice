using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems
{
    public class RotationalCipher
    {
        public  static string rotationalCipher(String input, int rotationFactor)
        {
            // Write your code here'
            var sb = new StringBuilder();
            foreach (var chr in input)
            {
                var ofset = 0;
                if (chr >= 'a' && chr <= 'z')
                {
                    ofset = ((chr + rotationFactor) - 97)%26+97;
                    sb.Append((char)ofset);
                }
                else if (char.IsLetter(chr) && char.IsUpper(chr))
                {
                    ofset = ((chr + rotationFactor) - 65) % 26 + 65;                    
                    sb.Append((char)ofset);
                }
                else if (Char.IsDigit(chr))
                {
                    ofset = chr + rotationFactor - 48;
                    ofset = ofset <= 10 ? ofset + 48 : ofset - 10 + 48;
                    sb.Append((char)ofset);
                }
                else sb.Append(chr);
            }
            return sb.ToString();
        }
    }
}
