using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LeetCodeAnswer
{
    public partial class Solution
    {
        public int[] PlusOne(int[] digits)
        {
            if (digits.All(p => p == 9))
            {
                int[] result = new int[digits.Length + 1];
                result[0] = 1;
                return result;
            }
            else
            {
                for (int i = digits.Length - 1; i >= 0; i--)
                {
                    if (digits[i] < 9)
                    {
                        digits[i] += 1;
                        break;
                    }
                    else
                    {
                        digits[i] = 0;
                    }
                }
                return digits;
            }
        }
        public int LengthOfLastWord(string s)
        {
            //从后往前找第一个单词
            if (s == "") return 0;
            string lastWord = "";
            for (int i = s.Length - 1; i >= 0; i--)
            {
                if (s[i] == ' ')
                {
                    if (lastWord != "")
                    {
                        break;
                    }
                }
                else
                {
                    lastWord = s[i] + lastWord;
                }
            }
            return lastWord.Length;
        }

        /// <summary>
        /// Maximum Subarray
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            //动态规划：当到达一个位置时，如果此时的子序列之和小于 0 的话，那么从当前位置开始的新子序列一定比保留原来的子序列的和更大。
            //递推公式：dp[i] = Math.max(dp[i - 1] + nums[i], nums[i])
            if (nums.Length == 1) return nums[0];
            int max = nums[0], cur = nums[0];
            for (int n = 1; n < nums.Length; n++)
            {
                if (cur <= 0)
                {
                    cur = nums[n];
                }
                else
                {
                    cur += nums[n];
                }
                max = Math.Max(cur, max);
            }
            return max;
        }

        /// <summary>
        /// Count and Say
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string CountAndSay(int n)
        {
            if (n == 1) return "1";
            if (n == 2) return "11";
            if (n == 3) return "21";

            //递归解法，依次读取前一个数的Count and Say
            string readStr = CountAndSay(n - 1);
            string result = "";
            char current = readStr[0];
            int num = 1;
            for (int i = 1; i < readStr.Length; i++)
            {
                if (current != readStr[i])
                {
                    result += $"{num}{current}";
                    current = readStr[i];
                    num = 1;
                }
                else
                {
                    num++;
                }
            }
            result += $"{num}{current}";
            return result;
        }
        /// <summary>
        /// Search Insert Position
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int SearchInsert(int[] nums, int target)
        {
           
            int i = nums.ToList().BinarySearch(target);
            return i >= 0 ? i : ~i;
        }
        /// <summary>
        ///  Implement strStr()
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {
            if (needle.Length == 0) return 0;
            for (int i = 0; i <= haystack.Length - needle.Length; i++)
            {
                for (int j = 0; j < needle.Length; j++)
                {
                    if (haystack[i + j] != needle[j]) break;
                    if (j == needle.Length - 1) return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// RemoveElement
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public int RemoveElement(int[] nums, int val)
        {
            if (nums == null) return 0;
            int len = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != val)
                {
                    nums[len] = nums[i];
                    len++;
                }
            }
            return len;
        }

        /// <summary>
        /// Remove Duplicates from Sorted Array
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            if (nums==null || nums.Length <= 0) return 0;
            if (nums.Length == 1) return 1;
            int len = 1;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[i - 1])
                {
                    nums[len] = nums[i];
                    len++;
                }
            }
            return len;
        }

        /// <summary>
        /// Merge Two Sorted Lists
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            if (l1 == null && l2 == null) return null;
            ListNode result = new ListNode(0);
            ListNode temp = result;
            while (l1!=null && l2!=null)
            {
                if (l1.val < l2.val)
                {
                    result.next = new ListNode(l1.val);
                    l1 = l1.next;
                }
                else
                {
                    result.next = new ListNode(l2.val);
                    l2 = l2.next;
                }
                result = result.next;

            }
            if (l1 != null)
            {
                result.next = l1;
            }
            if (l2 != null)
            {
                result.next = l2;
            }
            return temp.next ?? new ListNode(0);
        }

        private static readonly Dictionary<char, char> counterpart = new Dictionary<char, char>()
        {
            {')', '('},
            {'}', '{'},
            {']', '['}
        };

        /// <summary>
        /// Valid Parentheses
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            Stack<char> charStack = new Stack<char>();
            foreach (var c in s)
            {
                if (!counterpart.TryGetValue(c, out char needChar))
                {
                    charStack.Push(c);
                }
                else if (!charStack.TryPop(out char lastChar) || lastChar != needChar)
                {
                    return false;
                }
            }
            return charStack.Count() == 0;
        }
        public string LongestCommonPrefix(string[] strs)
        {
            if (strs == null || strs.Length <= 0) return "";
            if (strs.Length == 1) return strs[0];
            string result = "";
            string temp = "";
            string maxLengthStr = strs.Max();
            List<string> strList = strs.ToList();
            foreach (var item in maxLengthStr)
            {
                temp += item;
                if(strList.TrueForAll(p => p.StartsWith(temp)))
                {
                    result = temp;
                }
                else
                {
                    break;
                }
            }
            return result;
        }
        public int Reverse(int x)
        {
            bool flag = x < 0 ? true : false;
            string intStr = x.ToString().Replace("-", "");
            string outStr = "";
            foreach (var item in intStr)
            {
                outStr = item + outStr;
            }
            if (int.TryParse(outStr, out int num))
            {
                return flag ? -num : num;
            }
            else
            {
                return 0;
            }
        }

        public bool IsPalindrome(int x)
        {
            if (x < 0) return false;
            if (x < 10) return true;
            int temp = x;
            int num = 0;
            while (temp > 0)
            {
                num = (num * 10) + temp % 10;
                temp = temp / 10;
            }
            return num == x;

        }

        public int RomanToInt(string s)
        {
            Dictionary<char, int> romanDic = new Dictionary<char, int>()
            {
                { 'I',1 },{'V',5},{'X',10},{'L',50},{'C',100},{'D',500},{'M',1000},
            };
            int num = 0, temp = 0, val = 0;
            for (int i = 0; i < s.Length; i++)
            {
                val = romanDic[s[i]];
                if (temp < val)
                {
                    num -= temp;
                }
                else
                {
                    num += temp;
                }
                temp = val;
            }
            num += temp;
            return num;
        }
    }

    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
