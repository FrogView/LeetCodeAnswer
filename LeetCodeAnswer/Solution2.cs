using System;
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
            for (int i = 0; i < 32; i+=2)
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

        public int GetSub(int a,int b)
        {
            return GetSum(a, -b);
        }
    }
}
