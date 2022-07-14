using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Backtracking;

public class PhoneNumberLetterCombinations
{

    public IList<string> LetterCombinations(string digits)
    {
        if (digits.Length == 0)
            return new List<string>();
        var letterMap = new Dictionary<char, string>()
            {
                { '2', "abc" }, {'3', "def" }, {'4', "ghi" }, {'5', "jkl" },
                { '6', "mno" }, {'7', "pqrs" }, {'8', "tuv" }, {'9', "wxyz" }
            };

        var combinations = new List<string>();
        void backtrack(int index, StringBuilder path)
        {
            if (path.Length == digits.Length)
            {
                combinations.Add(path.ToString());
                return;
            }

            foreach (char chr in letterMap[digits[index]])
            {
                path.Append(chr);
                backtrack(index + 1, path);
                path.Remove(path.Length - 1, 1);
            }
        }

        backtrack(0, new StringBuilder());

        return combinations;
    }

    public IList<string> LetterCombinationsWords(string digits)
    {
        var letterMap = new Dictionary<char, string>()
            {
                { '2', "abc" }, {'3', "def" }, {'4', "ghi" }, {'5', "jkl" },
                { '6', "mno" }, {'7', "pqrs" }, {'8', "tuv" }, {'9', "wxyz" }
            };

        var dict = new HashSet<string>()
        { "hat", "bat", "cat", "house", "was", "dol" };

        var combinations = new List<string>();
        void backtrack(int index, StringBuilder path)
        {
            if (path.Length == digits.Length)
            {
                var word = path.ToString();
                if ( dict.Contains(word))
                    combinations.Add(word);

                return;
            }

            foreach (char chr in letterMap[digits[index]])
            {
                path.Append(chr);
                backtrack(index + 1, path);
                path.Remove(path.Length - 1, 1);
            }
        }

        backtrack(0, new StringBuilder());

        return combinations;
    }
}
