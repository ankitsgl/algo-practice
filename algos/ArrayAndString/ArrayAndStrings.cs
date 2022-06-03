using System;
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
    public static int[] TwoSum(int[] nums, int target)
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
    public static int[] TwoSum2(int[] nums, int target)
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
    public static int LengthOfLongestSubstring_Bruteforce(string s)
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

    public static int LengthOfLongestSubstring_Optimized(string s)
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

    public static int LengthOfLongestSubstring_Optimized2(string s)
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

    public static long StringToInt_bf(string s)
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

    public static long StringToInt_bf2(string s)
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

    public static int MaxWaterArea_bf(int[] height)
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

    public static int MaxWaterArea_Op(int[] height)
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

    public static string IntToRoman(int num)
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
    public static int RomanToInt(string s)
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

    public static IList<IList<int>> FindTwoSums(int[] nums)
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
    public static IList<IList<int>> ThreeSum_bf(int[] nums)
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

    public static IList<IList<int>> ThreeSum_Op(int[] nums)
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


    public static int ThreeSumClosest(int[] nums, int target)
    {    
        Array.Sort(nums);
        var distance = Int32.MaxValue;

        for (int i = 0; i < nums.Length -2; i++)
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
                    left++;;
                }
            }
        }
        return target - distance;
    }
    #endregion

    #region Implement strStr() https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2968/

    public static int StrStr_bf(string haystack, string needle)
    {
        var result = -1;
        
        if (needle.Length > haystack.Length) return result;

        var matchIndex = 0;
        
        for (int i = 0 ; i < haystack.Length; i++)
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


        return matchIndex != needle.Length-1 ? -1: result;
    }

    public static int StrStr_op(string haystack, string needle)
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
                if (st == needle) return index - st.Length+1;
                st = st.Remove(0, 1);
                index++;
            }
        }

        return -1;
    }

    #endregion

    #region Rotate Image https://leetcode.com/explore/interview/card/amazon/76/array-and-strings/2969/

    public static void RotateImage(int[][] matrix)
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
        var right = matrix[0].Length -1;
        
        while(left < right)
        {
            for (var i = 0 ; i < right - left; i++)
            {
                var top = left;
                var bottom = right;
                var temp = matrix[top][left+i];

                matrix[top][left+i] = matrix[bottom-i][left];

                matrix[bottom-i][left] = matrix[bottom][right-i];

                matrix[bottom][right-i] = matrix[top+i][right];

                matrix[top+i][right] = temp;
            }
            left++;
            right--;
        }
    }

    #endregion
}