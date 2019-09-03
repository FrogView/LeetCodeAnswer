﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace LeetCodeAnswer
{
    public partial class Solution
    {
        public class NumArray
        {
            private int[] numArray = new int[0];
            private Dictionary<int, int> values = new Dictionary<int, int>();
            public NumArray(int[] nums)
            {
                numArray = nums;
                int count = 0;
                for (int i = 0; i < numArray.Length; i++)
                {
                    count += numArray[i];
                    values.Add(i, count);
                }
            }

            public int SumRange(int i, int j)
            {
                return values[j] - values[i];
            }
        }

        public bool IsPowerOfThree(int n)
        {
            if (n < 1) return false;
            for (int i = 0; i < 32; i += 2)
            {
                if ((1 << i) == n)
                {
                    return true;
                }
            }
            return false;
        }

        public void ReverseString(char[] s)
        {
            int mid = s.Length / 2;
            for (int i = 0; i < mid; i++)
            {
                var temp = s[i];
                s[i] = s[s.Length - i];
                s[s.Length - 1] = temp;
            }
        }

        public bool IsVowel(char c)
        {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u'
                || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U';
        }

        public string ReverseVowels(string s)
        {
            int start = 0;
            int end = s.Length - 1;
            var arr = s.ToCharArray();
            while (start < end)
            {
                if (!IsVowel(arr[start]))
                {
                    start++;
                    continue;
                }
                if (!IsVowel(arr[end]))
                {
                    end--;
                    continue;
                }
                if (IsVowel(arr[start]) && IsVowel(arr[end]))
                {
                    var temp = arr[start];
                    arr[start] = arr[end];
                    arr[end] = temp;

                    start++;
                    end--;
                }
            }
            return new string(arr);
        }

        public int[] Intersection(int[] nums1, int[] nums2)
        {
            return nums1.Intersect(nums2).ToArray();
        }

        public int[] Intersection2(int[] nums1, int[] nums2)
        {
            var nums1Map = new Dictionary<int, int>();
            var nums2Map = new Dictionary<int, int>();
            var result = new List<int>();

            for (int i = 0; i < nums1.Length; i++)
            {
                if (nums1Map.ContainsKey(nums1[i]))
                    nums1Map[nums1[i]] += 1;
                else
                    nums1Map[nums1[i]] = 1;
            }

            for (int i = 0; i < nums2.Length; i++)
            {
                if (nums2Map.ContainsKey(nums2[i]))
                    nums2Map[nums2[i]] += 1;
                else
                    nums2Map[nums2[i]] = 1;
            }

            foreach (var item in nums1Map)
            {
                if (nums2Map.ContainsKey(item.Key))
                {
                    int count = System.Math.Min(nums2Map[item.Key], item.Value);
                    while (count > 0)
                    {
                        result.Add(item.Key);
                        count--;
                    }
                }
            }

            return result.ToArray();
        }

        public int GetSum(int a, int b)
        {
            if (b == 0) return a;

            var noCarry = a ^ b;
            var carry = a & b;

            return GetSum(noCarry, carry << 1);
        }

        public int GetSub(int a, int b)
        {
            return GetSum(a, -b);
        }

        public IList<string> ReadBinaryWatch(int num)
        {
            List<string> watches = new List<string>();
            for (int i = 0; i < 12; i++)
            {
                int countI = GetBinaryCount(i);
                if (countI > num)
                {
                    continue;
                }
                for (int j = 0; j < 60; j++)
                {
                    int countJ = GetBinaryCount(j);
                    if (countI + countJ == num)
                    {
                        watches.Add($"{i}:{j.ToString("D2")}");
                    }
                    else if (countI + countJ > num)
                    {
                        continue;
                    }
                }
            }
            return watches;
        }

        public int GetBinaryCount(int num)
        {
            int res = 0;
            while (num != 0)
            {
                if ((num & 0x01) == 1)
                {
                    res++;
                }
                num = num >> 1;
            }
            return res;
        }

        public int SumOfLeftLeaves(TreeNode root)
        {
            int sum = 0;
            SumOfLeft(root, true, ref sum);
            return sum;
        }

        public void SumOfLeft(TreeNode root, bool isLeft, ref int sum)
        {
            if (root != null)
            {
                if (root.left == null && root.right == null)
                {
                    if (isLeft)
                    {
                        sum += root.val;
                    }
                }

                if (root.left != null)
                {
                    SumOfLeft(root.left, true, ref sum);
                }

                if (root.right != null)
                {
                    SumOfLeft(root.right, false, ref sum);
                }
            }
        }

        public string ToHex(int num)
        {
            if (num == 0) return "0";
            if (num == 1) return "1";
            uint number = (uint)num;
            Dictionary<uint, string> dict = new Dictionary<uint, string>()
            {
                { 10,"a"},
                {11,"b" },
                {12,"c" },
                {13,"d" },
                { 14,"e"},
                { 15,"f"},
            };
            StringBuilder sb = new StringBuilder();
            while (number > 0)
            {
                uint temp = number % 16;
                if (dict.ContainsKey(temp))
                {
                    sb.Insert(0, dict[temp]);
                }
                else
                {
                    sb.Insert(0, temp);
                }
                number = number / 16;
            }
            return sb.ToString();
        }

        public int LongestPalindrome(string s)
        {
            int[] array = new int[64];
            foreach (var item in s)
            {
                array[item - 'A']++;
            }
            int mid = 0;
            int len = 0;
            foreach (var item in array)
            {
                if (item % 2 == 1)
                {
                    mid = 1;
                    len += item - 1;
                }
                if (item % 2 == 0)
                {
                    len += item;
                }
            }
            return len + mid;
        }

        public IList<string> FizzBuzz(int n)
        {
            List<string> list = new List<string>();
            for (int i = 1; i <= n; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    list.Add("FizzBuzz");
                }
                else if (i % 3 == 0)
                {
                    list.Add("Fizz");
                }
                else if (i % 5 == 0)
                {
                    list.Add("Buzz");
                }
                else
                {
                    list.Add(i.ToString());
                }
            }
            return list;
        }

        public int ThirdMax(int[] nums)
        {
            int[] array = new int[3];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.MinValue;
            }
            int n = 0;
            int s = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                int value = nums[i];
                if (value == int.MinValue)
                {
                    s = 1;
                    continue;
                }
                if (array.Contains(value)) continue;
                for (int j = 0; j < array.Length; j++)
                {
                    if (value > array[j])
                    {
                        for (int t = array.Length - 1; t > j; t--)
                        {
                            array[t] = array[t - 1];
                        }
                        array[j] = value;
                        n++;
                        break;
                    }
                }
            }
            return n + s >= 3 ? array[array.Length - 1] : array[0];
        }

        public string AddStrings(string num1, string num2)
        {
            int len1 = num1.Length - 1;
            int len2 = num2.Length - 1;
            StringBuilder res = new StringBuilder();
            int pus = 0;
            int sub = 0;
            while (len1 >= 0 || len2 >= 0)
            {
                int val1 = len1 < 0 ? 0 : num1[len1] - '0';
                int val2 = len2 < 0 ? 0 : num2[len2] - '0';

                var val = val1 + val2 + pus;
                if (val >= 10)
                {
                    sub = val % 10;
                    pus = val / 10;
                }
                else
                {
                    sub = val;
                    pus = 0;
                }
                res.Insert(0, sub);

                len1--;
                len2--;
                sub = 0;
            }
            if (pus != 0)
            {
                res.Insert(0, pus);
            }
            return res.ToString();
        }

        public IList<IList<int>> LevelOrder(Node root)
        {
            if (root == null) return new List<IList<int>>();
            IList<IList<int>> levels = new List<IList<int>>();

            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                List<int> levelList = new List<int>();
                int num = queue.Count;
                for (int i = 0; i < num; i++)
                {
                    var node = queue.Dequeue();
                    levelList.Add(node.val);
                    if (node.children != null)
                    {
                        foreach (var item in node.children)
                        {
                            if (queue != null)
                            {
                                queue.Enqueue(item);
                            }
                        }
                    }
                }
                levels.Add(levelList);
            }
            return levels;
        }

        public int CountSegments(string s)
        {
            return s.Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;
        }


    }

    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }
        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
        }
    }
}
