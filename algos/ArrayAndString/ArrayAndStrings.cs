using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algos.ArrayAndString;

public class ArrayAndStrings
{

    #region TwoSum
    /// <summary>
    /// Given an array of integers nums and an integer target, 
    /// return indices of the two numbers such that they add up to target.
    /// You may assume that each input would have exactly one solution,
    /// and you may not use the same element twice. You can return the answer in any order.
    /// Example 1:
    ///     Input: nums = [2, 7, 11, 15], target = 9
    ///     Output: [0,1]
    ///     Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
    /// Example 2:
    ///     Input: nums = [3, 2, 4], target = 6
    ///     Output: [1,2]
    /// Example 3:
    ///     Input: nums = [3, 3], target = 6
    ///     Output: [0,1]
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int[] TwoSum(int[] nums, int target)
    {
        var dictionary = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (dictionary.ContainsKey(target - nums[i]))
            {
                return new int[] { dictionary[target - nums[i]], i };
            }
            if (!dictionary.ContainsKey(nums[i]))
                dictionary.Add(nums[i], i);
        }
        return null;
    }
    public int[] TwoSum2(int[] nums, int target)
    {
        // Key considerations:
        // Less lookup

        var dictionary = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            var targetDifference = target - nums[i];

            if (dictionary.TryGetValue(targetDifference, out var index))
            {
                return new int[] { index, i };
            }
            dictionary[nums[i]] = i;
        }
        return null;
    }
    #endregion

    #region Longest Substring Without Repeating Char


    /// <summary>
    /// Given a string s, find the length of the longest substring without repeating characters.
    /// Example 1:
    ///	    Input: s = "abcabcbb"
    ///	    Output: 3
    ///	    Explanation: The answer is "abc", with the length of 3.
    /// Example 2:
    ///	    Input: s = "bbbbb"
    ///	    Output: 1
    ///	    Explanation: The answer is "b", with the length of 1.
    ///Example 3:
    ///	    Input: s = "pwwkew"
    ///	    Output: 3
    ///	    Explanation: The answer is "wke", with the length of 3.
    ///Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public int LengthOfLongestSubstring_Bruteforce(string s)
    {
        var longestLength = 0;


        for (int i = 0; i < s.Length; i++)
        {
            var currentLength = 1;
            var hash = new Dictionary<char, int>();
            hash.Add(s[i], 0);
            for (int j = i + 1; j < s.Length; j++)
            {
                if (hash.ContainsKey(s[j]))
                {
                    break;
                }
                hash.Add(s[j], 0);
                currentLength++;
            }
            longestLength = Math.Max(currentLength, longestLength);
        }
        return longestLength;
    }

    public int LengthOfLongestSubstring_Optimized(string s)
    {
        var longestLength = 0;

        int left = 0, right = 0;
        int[] chars = new int[128];

        while (right < s.Length)
        {
            char r = s[right];
            chars[r]++;
            while (chars[r] > 1)
            {
                char l = s[left];
                chars[l]--;
                left++;
            }

            longestLength = Math.Max(right - left + 1, longestLength);
            right++;
        }
        return longestLength;
    }

    public int LengthOfLongestSubstring_Optimized2(string s)
    {
        var longestLength = 0;


        IDictionary<char, int> hash = new Dictionary<char, int>();
        for (int j = 0, i = 0; j < s.Length; j++)
        {
            if (hash.ContainsKey(s[j]))
            {
                i = Math.Max(hash[s[j]], i);
                hash.Remove(s[j]);
            }
            longestLength = Math.Max(longestLength, j - i + 1);
            hash.Add(s[j], j + 1);
        }
        return longestLength;
    }


    #endregion

    #region String To Integer

    public long StringToInt_bf(string s)
    {
        long result = 0;
        long carry = 1;
        for (int i = s.Length - 1; i >= 0; i--)
        {
            if (s[i] == '-')
            {
                // Negative Number 
                result = result - (result * 2);
                break;
            }
            if (result > 0 && !Char.IsDigit(s[i])) return 0;
            if (!Char.IsDigit(s[i])) continue;
            var number = s[i] - 48;
            result = result + (number * carry);
            carry = carry * 10;
        }
        return result;
    }

    public long StringToInt_bf2(string s)
    {
        long result = 0;
        var isNegative = false;
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '-')
            {
                isNegative = true;
                continue;
            }
            if (!Char.IsDigit(s[i])) continue;

            var number = s[i] - 48;

            result = result * 10 + number;
        }
        if (isNegative) result = result - (result * 2);

        return result;
    }

    #endregion

    #region Container with Most Water https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2963/

    public int MaxWaterArea_bf(int[] height)
    {
        var maxWater = 0;

        for (int left = 0; left < height.Length; left++)
        {
            var currentWater = 0;
            for (int right = left + 1; right < height.Length; right++)
            {
                // Find Max water hold in current edges
                currentWater = Math.Min(height[left], height[right]) * (right - left);

                // Assign max water
                maxWater = Math.Max(maxWater, currentWater);
            }
        }

        return maxWater;
    }

    public int MaxWaterArea_Op(int[] height)
    {
        var maxWater = 0;

        var left = 0;
        var right = height.Length - 1;

        while (left < right)
        {
            var leftValue = height[left];
            var rightValue = height[right];
            // Find Max water hold in current edges
            //var currentWater = Math.Min(leftValue, rightValue) * (right - left)
            // Assign max water
            maxWater = Math.Max(maxWater, Math.Min(leftValue, rightValue) * (right - left));

            // Move index with lower height to maximize width
            if (leftValue > rightValue) right--; else left++;
        }

        return maxWater;
    }

    #endregion

    #region Integer to Roman https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2964/

    public string IntToRoman(int num)
    {
        var sb = new StringBuilder();


        int[] values = { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        string[] symbols = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        // Loop through each symbol, stopping if num becomes 0.
        for (int i = 0; i < values.Length && num > 0; i++)
        {
            // Repeat while the current symbol still fits into num.
            var val = values[i];
            while (val <= num)
            {
                num -= val;
                sb.Append(symbols[i]);
            }
        }

        return sb.ToString();
    }

    //https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2965/
    public int RomanToInt(string s)
    {
        var result = 0;

        var map = new Dictionary<char, int>();
        map['I'] = 1;
        map['V'] = 5;
        map['X'] = 10;
        map['L'] = 50;
        map['C'] = 100;
        map['D'] = 500;
        map['M'] = 1000;

        var length = s.Length;
        for (var i = 0; i < length - 1; i++)
        {
            var chr = s[i];
            var value = map[chr];
            if (value < map[s[i + 1]])
                result = result - value;
            else
                result = result + value;
        }
        result = result + map[s[length - 1]];
        return result;
    }
    #endregion

    #region 2 / 3Sum https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2966/

    public IList<IList<int>> FindTwoSums(int[] nums)
    {
        //-1, 0, 1, 2, -1, -4 
        //-4,-1,-1, 0,  1,  2
        var result = new List<IList<int>>();

        var left = 0;
        var right = nums.Length - 1;
        var targetSum = 0;
        Array.Sort(nums);
        while (left < right)
        {

            if (nums[left] + nums[right] == targetSum)
                result.Add(new List<int> { nums[left], nums[right] });

            if (nums[left] + nums[right] > targetSum)
                right--;
            if (nums[left] + nums[right] <= targetSum)
                left++;
        }

        return result;
    }
    public IList<IList<int>> ThreeSum_bf(int[] nums)
    {
        var result = new List<IList<int>>();
        var taggetSum = 0;
        Array.Sort(nums);

        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            for (int j = i + 1; j < nums.Length - 1; j++)
            {
                //remove duplicate    
                for (int k = j + 1; k < nums.Length; k++)
                {
                    if (nums[i] + nums[j] + nums[k] == taggetSum)
                    {
                        result.Add(new List<int>() { nums[i], nums[j], nums[k] });

                    }
                }
            }

        }

        return result;

    }

    public IList<IList<int>> ThreeSum_Op(int[] nums)
    {
        //-1, 0, 1, 2, -1, -4 
        //-4,-1,-1, 0,  1,  2

        var result = new List<IList<int>>();
        var targetSum = 0;
        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            // Dont want to use same valie two time in same place. 
            var firstVal = nums[i];

            if (i > 0 && firstVal == nums[i - 1]) continue;

            var left = i + 1;
            var right = nums.Length - 1;


            while (left < right)
            {
                var leftValue = nums[left];
                var rightValue = nums[right];

                var threeSum = firstVal + leftValue + rightValue;
                if (threeSum > targetSum)
                    right--;
                else if (threeSum < targetSum)
                    left++;
                else
                {
                    var key = $"{firstVal},{leftValue},{rightValue}";

                    result.Add(new List<int> { firstVal, leftValue, rightValue });

                    while (left < right && leftValue == nums[left + 1])
                        left++;
                    while (right > left && rightValue == nums[right - 1])
                        right--;

                    left++;
                    right--;
                }
            }

        }

        return result;

    }


    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);
        var distance = Int32.MaxValue;

        for (int i = 0; i < nums.Length - 2; i++)
        {
            var left = i + 1;
            var right = nums.Length - 1;

            var newTarget = target - nums[i];

            while (left < right)
            {

                var sum = nums[left] + nums[right];

                if (Math.Abs(distance) > Math.Abs(newTarget - sum))
                    distance = newTarget - sum;

                if (sum == newTarget)
                    return target;
                else if (sum > newTarget)
                    right--;
                else
                {
                    left++; ;
                }
            }
        }
        return target - distance;
    }
    #endregion

    #region Implement strStr() https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2968/

    public int StrStr_bf(string haystack, string needle)
    {
        var result = -1;

        if (needle.Length > haystack.Length) return result;

        var matchIndex = 0;

        for (int i = 0; i < haystack.Length; i++)
        {

            if (haystack[i] == needle[matchIndex])
            {
                if (matchIndex == 0)
                    result = i;

                if (matchIndex == needle.Length - 1)
                    break;
                matchIndex++;
            }
            else
            {
                //Move pointer back
                if (matchIndex > 0)
                    i = i - matchIndex;
                matchIndex = 0;
            }

            if (i == haystack.Length - 1 && matchIndex < needle.Length)
            {
                return -1;
            }
        }


        return matchIndex != needle.Length - 1 ? -1 : result;
    }

    public int StrStr_op(string haystack, string needle)
    {
        if (needle.Length > haystack.Length) return -1;

        var index = 0;
        string st = "";
        while (index < haystack.Length)
        {
            st = st + haystack[index];
            if (index < needle.Length - 1) index++;
            else
            {
                if (st == needle) return index - st.Length + 1;
                st = st.Remove(0, 1);
                index++;
            }
        }

        return -1;
    }

    #endregion

    #region Rotate Image https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2969/

    public void RotateImage(int[][] matrix)
    {
        /*
         * | 5  | 1  | 9  | 11 | 
         * | 2  | 4  | 8  | 10 | 
         * | 13 | 3  | 6  | 7  | 
         * | 15 | 14 | 12 | 16 | 
         * Expected ---------------
         * | 15 | 13 | 2  | 5  | 
         * | 14 | 3  | 4  | 1  | 
         * | 12 | 6  | 8  | 9  | 
         * | 16 | 7  | 10 | 11 | 
         */
        var left = 0;
        var right = matrix[0].Length - 1;

        while (left < right)
        {
            for (var i = 0; i < right - left; i++)
            {
                var top = left;
                var bottom = right;
                var temp = matrix[top][left + i];

                matrix[top][left + i] = matrix[bottom - i][left];

                matrix[bottom - i][left] = matrix[bottom][right - i];

                matrix[bottom][right - i] = matrix[top + i][right];

                matrix[top + i][right] = temp;
            }
            left++;
            right--;
        }
    }

    #endregion

    #region Group Anagrams

    public IList<IList<string>> GroupAnagrams_bf(string[] strs)
    {
        var result = new List<IList<string>>();

        var dictionary = new Dictionary<string, IList<string>>();

        foreach (var str in strs)
        {
            var sortedStr = new string(str.OrderBy(c => c).ToArray());
            if (!dictionary.ContainsKey(sortedStr))
                dictionary[sortedStr] = new List<string>();
            dictionary[sortedStr].Add(str);
        };

        return dictionary.Values.ToList();
    }

    public IList<IList<string>> GroupAnagrams_op(string[] strs)
    {
        var result = new List<IList<string>>();

        var dictionary = new Dictionary<string, IList<string>>();

        foreach (var str in strs)
        {
            char[] hash = new char[26];
            foreach (var chr in str)
                hash[chr - 'a']++;
            //Make a key for each chr count
            String key = new String(hash);
            if (!dictionary.ContainsKey(key))
                dictionary[key] = new List<string>();
            dictionary[key].Add(str);
        };

        return dictionary.Values.ToList();
    }

    #endregion

    #region Minimum Window Substring https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/902/
    public string MinWindowSubstring_bf(string s, string t)
    {
        var res = string.Empty;

        var s_arr = s.ToCharArray();
        var t_arr = t.ToCharArray();

        //Build Target Hash;
        var arr = new int[128];
        foreach (var chr in t)
        {
            arr[chr]++;
        }

        var left = 0;
        var right = 0;

        int minLength = int.MaxValue;

        var counter = 0;

        // Solved using Sliding windos

        while (right < s_arr.Length)
        {
            var currentChar = s_arr[right];
            if (--arr[currentChar] >= 0)
                counter++;

            // shrink window
            while (counter == t_arr.Length)
            {
                int currWindows = right - left + 1;
                if (currWindows < minLength)
                {
                    minLength = currWindows;
                    res = s.Substring(left, right - left + 1);
                }
                char leftChar = s_arr[left];
                if (++arr[leftChar] > 0)
                {
                    counter--;
                }
                left++;
            }
            right++;
        }

        return res;
    }
    #endregion

    #region Compare Version Numbers

    public int CompareVersion(string version1, string version2)
    {
        //"1.01", "1.001")

        var v1Parts = version1.Split('.');
        var v2Parts = version2.Split('.');

        var maxLength = Math.Max(v1Parts.Length, v2Parts.Length);

        for (int i = 0; i < maxLength; i++)
        {
            var v1 = i < v1Parts.Length ? int.Parse(v1Parts[i]) : 0;
            var v2 = i < v2Parts.Length ? int.Parse(v2Parts[i]) : 0;

            if (v1 == v2)
                continue;
            else if (v1 < v2)
                return -1;
            else
                return 1;

        }
        return 0;

    }

    #endregion

    #region Product of Array Except Self https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/499/
    public int[] ProductExceptSelf_bf(int[] nums)
    {
        var array = new int[nums.Length];
        Array.Fill(array, 1);
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < nums.Length; j++)
            {
                if (i == j) continue;
                array[i] = array[i] * nums[j];
            }
        }

        return array;
    }

    public int[] ProductExceptSelf_op(int[] nums)
    {
        var array = new int[nums.Length];
        var prefix = 1;
        for (int i = 0; i < nums.Length; i++)
        {
            array[i] = prefix;
            prefix = prefix * nums[i];
        }
        var postfix = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            array[i] = array[i] * postfix;
            postfix = postfix * nums[i];
        }

        return array;
    }
    #endregion

    #region Missing Number https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2971/
    public int MissingNumber(int[] nums)
    {
        var sum = 0;
        foreach (var num in nums)
            sum += num;


        var n = nums.Length + 1;
        return (n * (n - 1) / 2) - sum;
    }
    #endregion

    #region Int to English Words

    static string[] THOUSANDS = new string[] { "", "Thousand", "Million", "Billion" };

    static string[] LESS_THAN_TWENTY = new string[]{"", "One", "Two", "Three", "Four", "Five",
            "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen",
            "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"};

    static string[] TENS = new string[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

    public string NumberToWords(int num)
    {
        var sb = new StringBuilder();

        if (num == 0) return "Zero";

        var index = 0;
        while (num > 0)
        {
            if (num % 1000 > 0)
            {
                StringBuilder tmp = new StringBuilder();
                HundredToWords(tmp, num % 1000);
                tmp.Append(THOUSANDS[index]).Append(" ");
                sb.Insert(0, tmp);
            }
            index++;
            num = num / 1000;
        }

        return sb.ToString().Trim();
    }

    private static void HundredToWords(StringBuilder tmp, int num)
    {
        if (num == 0)
        {
            return;
        }
        else if (num < 20)
        {
            tmp.Append(LESS_THAN_TWENTY[num]).Append(" ");
            return;
        }
        else if (num < 100)
        {
            tmp.Append(TENS[num / 10]).Append(" ");
            HundredToWords(tmp, num % 10);
        }
        else
        {
            tmp.Append(LESS_THAN_TWENTY[num / 100]).Append(" Hundred ");
            HundredToWords(tmp, num % 100);
        }
    }

    static string[] belowTen = new String[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };
    static string[] belowTwenty = new String[] { "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen" };
    static string[] belowHundred = new String[] { "", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

    public string NumberToWords_Op2(int num)
    {
        if (num == 0)
            return "Zero";
        return NumberToWordHelper(num);
    }

    private static string NumberToWordHelper(int num)
    {
        string result;
        if (num < 10)
            result = belowTen[num];
        else if (num < 20)
            result = belowTwenty[num - 10];
        else if (num < 100)
            result = belowHundred[num / 10] + " " + NumberToWordHelper(num % 10);
        else if (num < 1000)
            result = NumberToWordHelper(num / 100) + " Hundred " + NumberToWordHelper(num % 100);
        else if (num < 1000000)
            result = NumberToWordHelper(num / 1000) + " Thousand " + NumberToWordHelper(num % 1000);
        else if (num < 1000000000)
            result = NumberToWordHelper(num / 1000000) + " Million " + NumberToWordHelper(num % 1000000);
        else
            result = NumberToWordHelper(num / 1000000000) + " Billion " + NumberToWordHelper(num % 1000000000);

        return result.Trim();
    }
    #endregion

    #region First Unique Character in a String
    public int FirstUniqChar(string s)
    {
        var chars = new int[128];
        foreach (var chr in s)
        {
            chars[chr]++;
        }
        for (var i = 0; i < s.Length; i++)
        {
            if ( chars[s[i]] == 1 )
                    return i;
        }
        return -1;
    }
    #endregion

    #region Most Common Word
    public string MostCommonWord(string paragraph, string[] banned)
    {
        var bannedHash = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var word in banned)
        {
            if (!bannedHash.Contains(word))
                bannedHash.Add(word);
        }
        
        var punctuations = new char[] { '!', '?', '\'', ',', ';', '.', };
        foreach (var punctuation in punctuations)
            paragraph = paragraph.Replace(punctuation, ' ');

        var words = paragraph.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var maxOccuranceCount = 0;
        var dictionary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        var result = "";
        foreach (var word in words)
        {   
            if (word == "" || bannedHash.Contains(word)) continue;

            if (!dictionary.ContainsKey(word))
                dictionary.Add(word, 1);
            else
                dictionary[word] = dictionary[word] + 1;

            if (maxOccuranceCount == 0 || result.Length == 0 || dictionary[word] > maxOccuranceCount)
            {
                maxOccuranceCount = dictionary[word];
                result = word;
            }
        }

        return result.ToLower();

    }

    public string MostCommonWord_Imp2(string paragraph, string[] banned)
    {
        var bannedWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        foreach (var bannedWord in banned)
        {
            if (!bannedWords.Contains(bannedWord))
                bannedWords.Add(bannedWord);
        }

        paragraph = paragraph.ToLower() + " ";
        var maxOccuranceCount = 0;
        var dictionary = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
        var result = "";
        string word = "";
        
        foreach (var chr in paragraph)
        {
            if (chr >= 'a' && chr <= 'z')
                word += chr;
            else if (word != "")
            {
                if (!bannedWords.Contains(word))
                {
                    if (!dictionary.ContainsKey(word))
                        dictionary.Add(word, 1);
                    else
                        dictionary[word] = dictionary[word] + 1;

                    if (maxOccuranceCount == 0 || dictionary[word] > maxOccuranceCount)
                    {
                        maxOccuranceCount = dictionary[word];
                        result = word;
                    }
                }

                //Reset word
                word = "";
            }
        }

        return result.ToLower();

    }

    #endregion

    #region Reorder Log Files
    public string[] ReorderLogFiles(string[] logs)
    {
        var letterLog = new List<string[]>();
        var digitLog = new List<string>();

        foreach (var log in logs)
        {
            if (char.IsDigit(log.Split()[1][0]))
                digitLog.Add(log);
            else
                letterLog.Add(log.Split());
        }

        letterLog.Sort((part1, part2) => {
            var log1 = string.Join(' ', part1, 1, part1.Length -1);
            var log2 = string.Join(' ', part2, 1, part2.Length - 1);
            bool isSame = log1.Equals(log2);

            if (isSame) return part1[0].CompareTo(part2[0]);
            return log1.CompareTo(log2);
        });

        var arr1 = letterLog.Select(s => string.Join(' ', s)).ToList();
        arr1.AddRange(digitLog);
        return arr1.ToArray();
    }

    public string[] ReorderLogFiles_Op(string[] logs)
    { 
        // Note: This solution is not maintaining digit order and its sorting digits elements also.
        Array.Sort(logs, (part1, part2) => {

            var split1 = part1.Split();
            var split2 = part2.Split();

            var isNum1 = char.IsDigit(split1[1][0]);
            var isNum2 = char.IsDigit(split2[1][0]);
            
            if (isNum1 && isNum2) return 0;
            else if (isNum1) return 1;
            else if (isNum2) return -1;

            var log1 = string.Join(' ', split1, 1, split1.Length - 1);
            var log2 = string.Join(' ', split2, 1, split2.Length - 1);
            bool isSame = log1.Equals(log2);

            if (isSame) return split1[0].CompareTo(split2[0]);
            return log1.CompareTo(log2);
        });

        return logs;

    }
    #endregion

    #region Trapping Rain Water
    public int TotalWaterTraped_Bf(int[] height)
    {
        var totalWater = 0;
        // Devide and concur
        var mid = 1; 
        

        for(; mid < height.Length - 1; mid++)
        {
            var leftHighest = height[mid];
            var rightHighest  = height[mid];
            
            // Find Highest of Left
            for (var i = 0; i < mid; i++)
            {
                leftHighest = Math.Max(leftHighest, height[i]);
            }

            // Find Highest of Right
            for (var i = mid+1; i < height.Length; i++)
            {
                rightHighest = Math.Max(rightHighest, height[i]);                 
            }


            var maxWaterHeight = Math.Min(leftHighest, rightHighest);
            var totalWaterInCurrentWindow = maxWaterHeight - height[mid];

            totalWater += totalWaterInCurrentWindow;
        }

        return totalWater;
    }

    public int TotalWaterTraped_Op(int[] height)
    {
        var totalWater = 0;
        // Devide and concur
        
        var left = new int[height.Length];
        var right = new int[height.Length];
        left[0] = 0;
        for (var i = 1; i < height.Length; i++)
        {
            left[i] = Math.Max(left[i-1], height[i-1]);
        }

        right[height.Length - 1] = 0;
        for (int i = height.Length - 2; i >= 0; i--)
        {
            right[i] = Math.Max(right[i+1], height[i+1]);
        }

        for (var i = 0; i < height.Length; i++)
        {
            var waterAtCurrentLevel = Math.Min(left[i], right[i]) - height[i];
            if (waterAtCurrentLevel > 0 ) totalWater += waterAtCurrentLevel;
        }

        return totalWater;
    }

    public int TotalWaterTraped_Op2(int[] height)
    {
        var totalWater = 0;
        // Devide and concur

        var left = new int[height.Length];
        
        left[0] = 0;
        for (var i = 1; i < height.Length; i++)
        {
            left[i] = Math.Max(left[i - 1], height[i - 1]);
        }

        var right = 0;
        for (int i = height.Length-2; i >= 0; i--)
        {
            right = Math.Max(right, height[i + 1]);
            var waterAtCurrentLevel = Math.Min(left[i], right) - height[i];
            if (waterAtCurrentLevel > 0) totalWater += waterAtCurrentLevel;
        }

        return totalWater;
    }

    public int TotalWaterTraped_Op3(int[] height)
    {
        var totalWater = 0;
        var left = 0;
        var right = height.Length-1;

        var maxLeft = height[left];
        var maxRight = height[right];

        while (left < right)
        {
            if (maxLeft < maxRight)
            {
                left++;
                maxLeft = Math.Max(maxLeft, height[left]);
                totalWater += maxLeft - height[left];
            }
            else
            {
                right--;
                maxRight = Math.Max(maxRight, height[right]);
                totalWater += maxRight - height[right];
            }
        }
        return totalWater;
    }
    #endregion

    #region Binary Search
    public int BinarySearch(int[] array, int itemToSearch)
    {
        var left = 0;
        var right = array.Length-1;

        while (left < right)
        {
            var medium = ((right - left) / 2) + left;
            if (array[medium] == itemToSearch)
            {
                return medium;
            }
            else if (array[medium] > itemToSearch)
            {
                // go left                
                right = medium - 1;
            }
            else
            {
                // go right
                left = medium + 1;
            }
        }

        return -1;
    }
    #endregion

    #region Subdomain Visit Count https://leetcode.com/problems/subdomain-visit-count/
    public IList<string> SubdomainVisits(string[] cpdomains)
    {
        var result = new List<string>();
        var map = new Dictionary<string, int>();
        foreach (var domain in cpdomains)
        {
            var parts = domain.Split(' ');
            var hitCount = int.Parse(parts[0]);
            var subDomains = parts[1].Split('.');
            var len = subDomains.Length;
            for (var i = len - 1; i >= 0; i--)
            {
                var subDomain = string.Join('.', subDomains[i..(len)]);
                if (!map.ContainsKey(subDomain))
                    map.Add(subDomain, 0);
                map[subDomain] += hitCount;
            }
        }
        foreach (var item in map)
        {
            result.Add($"{item.Value} {item.Key}");
        }

        return result;
    }
    #endregion

    #region Summary Ranges
    public IList<string> SummaryRanges(int[] nums)
    {
        var result = new List<string>();
        for (int i = 0, j = 0; i < nums.Length; j++)
        {
            if (j + 1 < nums.Length && nums[j + 1] == nums[j] + 1)
                continue;

            if (i == j)
                result.Add($"{nums[i]}");
            else
                result.Add($"{nums[i]}->{nums[j]}");
            i = j + 1;
        }

        return result;

    }
    #endregion
}