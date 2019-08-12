using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LeetCodeAnswer
{
    public partial class Solution
    {


        //Second Highest Salary
        /*
        SELECT
        (SELECT DISTINCT
            Salary
        FROM
            Employee
        ORDER BY Salary DESC
        OFFSET 1 ROWS
        FETCH NEXT 1 ROWS ONLY) AS SecondHighestSalary
        ;
        */

        //Combine Two Tables
        /*
        SELECT a.FirstName,a.LastName,b.City,b.State FROM Person as a
        LEFT JOIN Address as b on a.PersonId=b.PersonId
        */

        /// <summary>
        /// Factorial Trailing Zeroes
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int TrailingZeroes(int n)
        {
            //every five numbers have one zero.
            if (n <= 0) return 0;
            int count = 0;
            while (n > 0)
            {
                count += n / 5;
                n = n / 5;
            }
            return count;
        }

        public int Factorial(int num)
        {
            if (num <= 0) return 0;
            if (num == 1) return 1;
            return num * Factorial(num - 1);
        }
        /// <summary>
        /// Excel Sheet Column Number
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int TitleToNumber(string s)
        {
            int index = 0;
            int num = 0;
            for (int i = s.Length - 1; i >= 0; i--)
            {
                int val = s[i] - 'A' + 1;
                num += val * (int)Math.Pow(26, index++);
            }
            return num;
        }
        /// <summary>
        /// Majority Element
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MajorityElement(int[] nums)
        {
            int minLen = nums.Length / 2;
            Dictionary<int, int> countDic = new Dictionary<int, int>();
            foreach (var item in nums)
            {
                if (countDic.ContainsKey(item))
                {
                    countDic[item]++;
                }
                else
                {
                    countDic.Add(item, 1);
                }
                if (countDic[item] > minLen)
                {
                    return item;
                }
            }
            return 0;
        }
        /// <summary>
        /// Excel Sheet Column Title
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string ConvertToTitle(int n)
        {
            //进制转化
            int temp = n;
            StringBuilder tempResult = new StringBuilder();
            while (temp != 0)
            {
                temp--;
                tempResult.Insert(0,(char)(temp % 26 + 65));
                temp /= 26;
            }

            return tempResult.ToString();
        }
        /// <summary>
        /// Two Sum II - Input array is sorted
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] numbers, int target)
        {
            //大则加，小则减
            int l = 0, r = numbers.Length - 1, sum;
            while (true)
            {
                sum = numbers[l] + numbers[r];
                if (sum == target)
                    break;
                else if (sum < target)
                    l += 1;
                else
                    r -= 1;
            }
            return new int[2] { l + 1, r + 1 };
        }
        /// <summary>
        /// Intersection of Two Linked Lists
        /// </summary>
        /// <param name="headA"></param>
        /// <param name="headB"></param>
        /// <returns></returns>
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            //根据链表长度最终A和B会同时到达尾部。。。
            if (headA == null || headB == null) return null;
            ListNode pA = headA, pB = headB;
            while (pA != pB)
            {
                pA = pA == null ? headB : pA.next;
                pB = pB == null ? headA : pB.next;
            }
            return pA;
        }
        /// <summary>
        /// Linked List Cycle
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            var fast = head;
            var slow = head;

            while (fast != null && fast.next != null)
            {
                fast = fast.next.next;
                slow = slow.next;
                if (slow == fast)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Single Number
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {
            int x = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                //this is magical
                x ^= nums[i];
            }
            return x;
        }
        /// <summary>
        /// Valid Palindrome
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s)) return true;
            s = s.ToLower();
            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                if (!char.IsLetterOrDigit(s[i]))
                {
                    i++;
                    continue;
                }
                if (!char.IsLetterOrDigit(s[j]))
                {
                    j--;
                    continue;
                }

                if (s[i] == s[j])
                {
                    i++;
                    j--;
                    continue;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Best Time to Buy and Sell Stock II
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit2(int[] prices)
        {
            //只要是正收益就全部加起来
            if (prices == null) return 0;
            int maxProfit = 0;
            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i - 1])
                {
                    maxProfit += prices[i] - prices[i - 1];
                }
            }
            return maxProfit;
        }
        /// <summary>
        /// Best Time to Buy and Sell Stock
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            //找极值即可
            if (prices == null || prices.Length <= 1) return 0;
            int max = 0, minPrice = int.MaxValue;
            for (int i = 0; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                {
                    minPrice = prices[i];
                }
                if (prices[i] - minPrice > max)
                {
                    max = prices[i] - minPrice;
                }
            }
            return max < 0 ? 0 : max;
        }

        /// <summary>
        /// Pascal's Triangle II
        /// </summary>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        public IList<int> GetRow(int rowIndex)
        {
            if (rowIndex == 0) return new List<int>() { 1 };

            var preRows = GetRow(rowIndex - 1);
            IList<int> rowList = new List<int>();
            for (int j = 0; j <= rowIndex; j++)
            {
                var left = (j - 1) >= 0 ? preRows[j - 1] : 0;
                var right = j >= preRows.Count ? 0 : preRows[j];
                rowList.Add(left + right);
            }
            return rowList;
        }
        /// <summary>
        /// Pascal's Triangle
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public IList<IList<int>> Generate(int numRows)
        {
            List<IList<int>> res = new List<IList<int>>();
            if (numRows == 0) return res;
            for (int i = 0; i < numRows; i++)
            {
                IList<int> rowList = new List<int>();
                if (i == 0)
                {
                    rowList = new List<int>() { 1 };
                }
                else
                {
                    for (int j = 0; j <= i; j++)
                    {
                        var left = (j - 1) >= 0 ? res[i - 1][j - 1] : 0;
                        var right = j >= res[i - 1].Count ? 0 : res[i - 1][j];
                        rowList.Add(left + right);
                    }
                }
                res.Add(rowList);
            }
            return res;
        }
        /// <summary>
        /// Path Sum
        /// </summary>
        /// <param name="root"></param>
        /// <param name="sum"></param>
        /// <returns></returns>
        public bool HasPathSum(TreeNode root, int sum)
        {
            var sumList = GetSumList(root);
            if (sumList.Contains(sum))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<int> GetSumList(TreeNode treeNode)
        {
            if (treeNode == null) return new List<int>();
            if (treeNode.left == null && treeNode.right == null)
            {
                return new List<int>() { treeNode.val };
            }
            List<int> sumList = new List<int>();
            if (treeNode.right != null)
            {
                sumList.AddRange(GetSumList(treeNode.right).Select(p => p += treeNode.val).ToList());
            }
            if (treeNode.left != null)
            {
                sumList.AddRange(GetSumList(treeNode.left).Select(p => p += treeNode.val).ToList());
            }
            return sumList;
        }
        /// <summary>
        /// Minimum Depth of Binary Tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            else if (root.left == null && root.right == null) return 1;
            else if (root.left == null)
            {
                return 1 + MinDepth(root.right);
            }
            else if (root.right == null)
            {
                return 1 + MinDepth(root.left);
            }
            else
            {
                return 1 + Math.Min(MinDepth(root.left), MinDepth(root.right));
            }
        }

        /// <summary>
        /// Balanced Binary Tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsBalanced(TreeNode root)
        {
            //判断每一个子树的高度差
            //PS: 二叉树的操作好像大部分都可以通过子树的递归来实现
            if (root == null) return true;

            if (IsBalanced(root.left) && IsBalanced(root.right) && Math.Abs(maxDepth(root.left) - maxDepth(root.right)) <= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Convert Sorted Array to Binary Search Tree
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {
            //递归方法，每次取中间值
            if (nums == null) return null;
            int count = nums.Length;
            return numArrayToBST(nums, 0, count - 1);
        }

        public TreeNode numArrayToBST(int[] nums, int start, int end)
        {
            if (start > end)
            {
                return null;
            }
            if (start == end)
            {
                return new TreeNode(nums[start]);
            }
            int index = (start + end) / 2;
            TreeNode treeNode = new TreeNode(nums[index]);
            treeNode.left = numArrayToBST(nums, start, index - 1);
            treeNode.right = numArrayToBST(nums, index + 1, end);
            return treeNode;
        }

        /// <summary>
        /// Binary Tree Level Order Traversal II
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            if (root == null) return new List<IList<int>>();
            Stack<IList<int>> res = new Stack<IList<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                List<int> levelList = new List<int>();
                int levelCount = queue.Count;
                for (int i = 0; i < levelCount; i++)
                {
                    var node = queue.Dequeue();
                    levelList.Add(node.val);
                    if (node.left != null)
                    {
                        queue.Enqueue(node.left);
                    }
                    if (node.right != null)
                    {
                        queue.Enqueue(node.right);
                    }
                }
                res.Push(levelList);
            }
            return res.ToList();
        }
        /// <summary>
        /// Maximum Depth of Binary Tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(TreeNode root)
        {
            if (root == null) return 0;
            return maxDepth(root);
        }

        public int maxDepth(TreeNode treeNode)
        {
            return treeNode == null ? 0 : 1 + Math.Max(maxDepth(treeNode.left), maxDepth(treeNode.right));
        }

        /// <summary>
        ///  Symmetric Tree
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymmetric(TreeNode root)
        {
            //左右对称，即 .left==.right
            if (root == null) return true;

            bool IsSame(TreeNode p, TreeNode q)
            {
                if (p == null && q == null) return true;
                if (p?.val != q?.val) return false;

                return IsSame(p.left, q.right) && IsSame(p.right, q.left);
            }

            return IsSame(root.left, root.right);
        }

        /// <summary>
        /// Same Tree
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            if (p == null && q == null) return true;
            if (p?.val != q?.val) return false;

            return IsSameTree(p.right, q.right) && IsSameTree(p.left, q.left);
        }
        /// <summary>
        /// Merge Sorted Array
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            int i1 = m - 1, i2 = n - 1, i = m + n - 1;
            while (i2 >= 0)
                nums1[i--] = i1 < 0 ? nums2[i2--]
                                    : nums2[i2] >= nums1[i1] ? nums2[i2--] : nums1[i1--];
        }
        /// <summary>
        /// Remove Duplicates from Sorted List
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return null;
            List<int> vals = new List<int>();
            ListNode res = new ListNode(0) { };
            ListNode pre = res;
            while (head != null)
            {
                if (!vals.Contains(head.val))
                {
                    vals.Add(head.val);
                    res.next = new ListNode(head.val);
                    res = res.next;
                }
                head = head.next;
            }
            return pre.next;
        }

        /// <summary>
        /// Climbing Stairs
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            //爬楼梯
            /*
            第 i 阶可以由以下两种方法得到：
            在第 (i−1) 阶后向上爬一阶。
            在第 (i−2) 阶后向上爬 2 阶。
            所以到达第 i 阶的方法总数就是到第 (i−1) 阶和第 (i−2) 阶的方法数之和。
            令 dp[i] 表示能到达第 i 阶的方法总数：
            dp[i]=dp[i−1]+dp[i−2]
            */
            if (n == 0) return 0;
            if (n == 1) return 1;
            int dp0 = 1, dp1 = 1;
            int res = 0;
            for (int i = 2; i <= n; i++)
            {
                res = dp0 + dp1;

                dp0 = dp1;
                dp1 = res;
            }
            return res;
        }
        /// <summary>
        /// Sqrt(x)
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int MySqrt(int x)
        {
            var result = Math.Sqrt(x);
            return (int)result;
        }

        /// <summary>
        /// Add Binary
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public string AddBinary(string a, string b)
        {
            int aIndex = a.Length - 1;
            int bIndex = b.Length - 1;
            int carry = 0, bitA = 0, bitB = 0, sum = 0;
            StringBuilder sb = new StringBuilder();
            while (aIndex >= 0 || bIndex >= 0)
            {
                bitA = aIndex >= 0 ? a[aIndex] - '0' : 0;
                bitB = bIndex >= 0 ? b[bIndex] - '0' : 0;
                sum = bitA + bitB + carry;

                switch (sum)
                {
                    case 0: sb.Insert(0, 0); carry = 0; break;
                    case 1: sb.Insert(0, 1); carry = 0; break;
                    case 2: sb.Insert(0, 0); carry = 1; break;
                    case 3: sb.Insert(0, 1); carry = 1; break;
                }
                aIndex--;
                bIndex--;
            }
            return carry == 0 ? sb.ToString() : sb.Insert(0, carry).ToString();
        }

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
            if (nums == null || nums.Length <= 0) return 0;
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
            while (l1 != null && l2 != null)
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
                if (strList.TrueForAll(p => p.StartsWith(temp)))
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

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x) { val = x; }
    }

    /// <summary>
    /// Min Stack
    /// </summary>
    public class MinStack
    {
        private List<int> list = new List<int>();
        /** initialize your data structure here. */
        public MinStack()
        {

        }

        public void Push(int x)
        {
            list.Insert(0, x);
        }

        public void Pop()
        {
            list.RemoveAt(0);
        }

        public int Top()
        {
            return list[0];
        }

        public int GetMin()
        {
            return list.Min();
        }
    }
}
