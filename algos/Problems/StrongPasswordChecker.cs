using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.Problems
{
    public class StrongPasswordCheckerAlgo
    {
        private const int MIN_LENGTH = 6;
        private const int MAX_LENGTH = 20;
        private const int MAX_REPEAT_LENGTH = 3;
        private const int digit = 0;
        private const int lowercase = 1;
        private const int uppercase = 2;
        public class RepeatCount
        {
            public int Value;
        }

        //https://leetcode.com/problems/strong-password-checker/
        public int StrongPasswordChecker(string password)
        {
            int[] bit = new[] { 1, 1, 1 };
            char prev = '\0';
            int repeatCount = 1;
            var repeatCharCounts = new List<int>();
            foreach (char c in password)
            {
                if (char.IsDigit(c))
                    bit[digit] = 0;
                else if (char.IsLetter(c) && char.IsLower(c))
                    bit[lowercase] = 0;
                else if (char.IsLetter(c) && char.IsUpper(c))
                    bit[uppercase] = 0;
                if (c == prev)
                {
                    repeatCount++;
                    continue;
                }
                if (repeatCount >= MAX_REPEAT_LENGTH)
                    repeatCharCounts.Add(repeatCount);
                repeatCount = 1;
                prev = c;
            }

            if (repeatCount >= MAX_REPEAT_LENGTH)
                repeatCharCounts.Add(repeatCount);

            var q = new Queue<RepeatCount>(repeatCharCounts
                                           .OrderBy(x => x % MAX_REPEAT_LENGTH)
                                           .Select(x => new RepeatCount { Value = x }));
            int passwordCount = password.Length;
            if (passwordCount > MAX_LENGTH)
            {
                while (passwordCount-- > MAX_LENGTH && q.Count > 0)
                {
                    var sequence = q.Peek();
                    if (sequence.Value == MAX_REPEAT_LENGTH)
                        q.Dequeue();
                    else if (sequence.Value % MAX_REPEAT_LENGTH == 0)
                        q.Enqueue(new RepeatCount { Value = q.Dequeue().Value - 1 });
                    else
                        sequence.Value--;
                }
            }

            int deletions = Math.Max(password.Length - MAX_LENGTH, 0);
            int repeatInsertsAndReplaces = q.Sum(x => x.Value / MAX_REPEAT_LENGTH);
            int requiredInsertsOrReplace = Math.Max(MIN_LENGTH - password.Length, bit.Sum());

            return Math.Max(requiredInsertsOrReplace, repeatInsertsAndReplaces) + deletions;
        }

        public int StrongPasswordChecker2(string s)
        {
            int charSum = GetRequiredChar(s);
            if (s.Length < 6) return Math.Max(charSum, 6 - s.Length);

            int replace = 0, ones = 0, twos = 0;
            for (int i = 0; i < s.Length;)
            {
                int len = 1;
                while (i + len < s.Length && s[i + len] == s[i + len - 1]) len++;
                if (len >= 3)
                {
                    replace += len / 3;
                    if (len % 3 == 0) ones += 1;
                    if (len % 3 == 1) twos += 2;
                }
                i += len;
            }

            if (s.Length <= 20) return Math.Max(charSum, replace);
            int deleteCount = s.Length - 20;
            replace -= Math.Min(deleteCount, ones);
            replace -= Math.Min(Math.Max(deleteCount - ones, 0), twos) / 2;
            replace -= Math.Max(deleteCount - ones - twos, 0) / 3;

            return deleteCount + Math.Max(charSum, replace);
        }

        int GetRequiredChar(string s)
        {
            int lowerCase = 1, upperCase = 1, digit = 1;
            foreach (var c in s)
            {
                if (char.IsLower(c)) lowerCase = 0;
                else if (char.IsUpper(c)) upperCase = 0;
                else if (char.IsDigit(c)) digit = 0;
            }
            return lowerCase + upperCase + digit;
        }
    }
}
