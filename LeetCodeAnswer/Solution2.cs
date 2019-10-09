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

        public int PathSum(TreeNode root, int sum)
        {
            Stack<int> data = new Stack<int>();
            int r = 0;
            recursive(root, sum, data, ref r);
            return r;
        }
        void recursive(TreeNode root, int sum, Stack<int> data, ref int r)
        {
            if (root == null) return;
            data.Push(root.val);
            int curr = 0;
            var list = data.ToList();
            for (int i = 0; i < list.Count; i++)
            {//检查包含root->val的解的个数
                curr += list[i];
                if (curr == sum)
                {
                    r++;
                }
            }
            recursive(root.left, sum, data, ref r);
            recursive(root.right, sum, data, ref r);
            data.Pop();
        }

        public int ArrangeCoins(int n)
        {
            int curr = 0;
            int sub = n;
            for (int i = 1; i <= n; i++)
            {
                sub -= i;
                if (sub == 0)
                {
                    return i;
                }
                if (sub < 0)
                {
                    return i - 1;
                }
                if (sub > 0)
                {
                    continue;
                }
            }
            return curr;
        }

        public int Compress(char[] chars)
        {
            int currSum = 0;
            char curr = chars[0];
            int currIndex = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                if (curr == chars[i])
                {
                    currSum++;
                }

                if (curr != chars[i])
                {
                    chars[currIndex++] = curr;
                    if (currSum > 1)
                    {
                        string currStr = currSum.ToString();
                        foreach (var item in currStr)
                        {
                            chars[currIndex++] = item;
                        }
                    }
                    curr = chars[i];
                    currSum = 1;
                }
            }
            chars[currIndex++] = curr;
            if (currSum > 1)
            {
                string currStr = currSum.ToString();
                foreach (var item in currStr)
                {
                    chars[currIndex++] = item;
                }
            }
            return currIndex;
        }

        public int NumberOfBoomerangs(int[][] points)
        {
            int res = 0;
            Dictionary<int, int> distinct = new Dictionary<int, int>();
            for (int i = 0; i < points.Length; i++)
            {
                distinct.Clear();
                for (int j = 0; j < points.Length; j++)
                {
                    if (i == j)
                    {
                        continue;
                    }
                    else
                    {
                        int dis = (points[i][0] - points[j][0]) * (points[i][0] - points[j][0]) + (points[i][1] - points[j][1]) * (points[i][1] - points[j][1]);
                        if (distinct.ContainsKey(dis))
                        {
                            res += distinct[dis] * 2;
                            distinct[dis] += 1;
                        }
                        else
                        {
                            distinct.Add(dis, 1);
                        }
                    }
                }
            }
            return res;
        }

        public IList<int> FindDisappearedNumbers(int[] nums)
        {
            List<int> res = new List<int>();
            int[] arr = new int[nums.Length];
            foreach (var item in nums)
            {
                arr[item - 1]++;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == 0)
                {
                    res.Add(i + 1);
                }
            }
            return res;
        }

        public int MinMoves(int[] nums)
        {
            int count = 0;
            int min = nums.Min();
            for (int i = 0; i < nums.Length; i++)
            {
                count += nums[i] - min;
            }
            return count;
        }

        public int FindContentChildren(int[] g, int[] s)
        {
            Array.Sort(g);
            Array.Sort(s);

            int res = 0;
            int gIndex = 0;
            int sIndex = 0;
            while (gIndex < g.Length && sIndex < s.Length)
            {
                if (s[sIndex] >= g[gIndex])
                {
                    res++;

                    sIndex++;
                    gIndex++;
                }
                else
                {
                    sIndex++;
                }
            }
            return res;
        }

        public bool RepeatedSubstringPattern(string s)
        {
            string str = s + s;
            return str.Substring(1, str.Length - 2).Contains(s);
        }

        public int HammingDistance(int x, int y)
        {
            int distance = 0;
            while (x > 0 || y > 0)
            {
                var val1 = x & 0x01;
                var val2 = y & 0x01;
                if (val1 != val2)
                {
                    distance++;
                }
                x = x >> 1;
                y = y >> 1;
            }
            return distance;
        }

        public int IslandPerimeter(int[][] grid)
        {
            int meter = 0;
            for (int i = 0; i < grid.Length; i++)
            {
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (grid[i][j] == 1)
                    {
                        meter += 4;
                        if(i>0 && grid[i - 1][j] == 1)
                        {
                            meter -= 2;
                        }
                        if (j > 0 && grid[i][j - 1] == 1)
                        {
                            meter -= 2;
                        }
                    }
                }
            }
            return meter;
        }

        public int FindRadius(int[] houses, int[] heaters)
        {
            int houseIndex = 0;
            int heaterIndex = 0;

            int left = 0;
            int maxDistance = 0;
            while (houseIndex < houses.Length && heaterIndex < heaters.Length)
            {
                if (houses[houseIndex] == heaters[heaterIndex])
                {
                    maxDistance = Math.Max(maxDistance, houseIndex - left - 1);
                    left = houseIndex;

                    houseIndex++;
                    heaterIndex++;
                }
                else
                {
                    houseIndex++;
                }
            }
            return maxDistance % 2 == 0 ? maxDistance / 2 : maxDistance / 2 + 1;
        }

        public int FindComplement(int num)
        {
            int res = 0;
            int index = 0;
            while (num > 0)
            {
                var val = num & 0x01;
                val = val == 0 ? 1 : 0;
                res = res | (val << index++);
                num = num >> 1;
            }
            return res;
        }

        public string LicenseKeyFormatting(string S, int K)
        {
            var sb = new StringBuilder();
            int counter = 0;
            for (int i = S.Length - 1; i >= 0; i--)
            {
                if (S[i] != '-')
                {
                    if (counter == K)
                    {
                        counter = 1;
                        sb.Append('-');
                    }
                    else
                    {
                        counter++;
                    }
                    sb.Append(char.ToUpper(S[i]));
                }
            }

            var res = new string(sb.ToString().Reverse().ToArray());
            return res;
        }

        public int FindMaxConsecutiveOnes(int[] nums)
        {
            int res = 0;
            int curr = 0;
            if (nums.Length <= 0) return 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == 1)
                {
                    curr++;
                }
                else
                {
                    res = Math.Max(curr, res);
                    curr = 0;
                }
            }
            return res = Math.Max(curr, res);
        }

        public int[] ConstructRectangle(int area)
        {
            int sub = int.MaxValue;
            int value1 = 1;
            int value2 = 1;
            int mid = area / 2;
            for (int i = mid; i >= 1; i--)
            {
                if (area % i == 0)
                {
                    var curr = Math.Abs(i - (area / i));
                    if (curr < sub)
                    {
                        value1 = i;
                        value2 = area / i;
                        sub = curr;
                    }
                }
            }
            return value1 > value2 ? new int[] { value1, value2 } : new int[] { value2, value1 };
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
