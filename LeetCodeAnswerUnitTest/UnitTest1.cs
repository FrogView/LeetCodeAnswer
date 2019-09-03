using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace LeetCodeAnswerUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        LeetCodeAnswer.Solution s = new LeetCodeAnswer.Solution();

        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        [DataRow(38, 2)]
        [DataRow(22, 4)]
        [DataRow(10, 1)]
        [DataRow(8, 8)]
        public void TestAddDigits(int x, int y)
        {
            var res = s.AddDigits(x);
            Assert.AreEqual(y, res);
        }

        [TestMethod]
        [DataRow(-2147483648, false)]
        [DataRow(1, true)]
        [DataRow(6, true)]
        [DataRow(8, true)]
        [DataRow(14, false)]
        public void TestIsUgly(int x, bool expected)
        {
            var res = s.IsUgly(x);
            Assert.AreEqual(expected, res);
        }

        [TestMethod]
        [DataRow(new int[] { 1 }, new int[] { 1 })]
        [DataRow(new int[] { 0, 1, 0, 3, 12 }, new int[] { 1, 3, 12, 0, 0 })]
        public void TestMoveZeroes(int[] nums, int[] expected)
        {
            s.MoveZeroes(nums);

            Assert.IsTrue(nums.SequenceEqual(expected));
        }

        [TestMethod]
        [DataRow("abba", "dog cat cat dog", true)]
        [DataRow("abba", "dog cat cat fish", false)]
        [DataRow("aaaa", "dog cat cat dog", false)]
        [DataRow("abba", "dog dog dog dog", false)]
        public void TestWordPattern(string pattern, string str, bool expected)
        {
            bool actul = s.WordPattern(pattern, str);
            Assert.AreEqual(expected, actul);
        }

        [TestMethod]
        [DataRow("1807", "7810", "1A3B")]
        [DataRow("1123", "0111", "1A1B")]
        public void TestGetHint(string secret, string guess, string expected)
        {
            string actul = s.GetHint(secret, guess);
            Assert.AreEqual(expected, actul);
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 }, new int[] { 2 })]
        [DataRow(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 }, new int[] { 9, 4 })]
        public void TestIntersection(int[] num1, int[] num2, int[] expected)
        {
            var actul = s.Intersection(num1, num2);
            Assert.IsTrue(actul.OrderBy(p => p).SequenceEqual(expected.OrderBy(p => p)));
        }

        [TestMethod]
        [DataRow(new int[] { 1, 2, 2, 1 }, new int[] { 2, 2 }, new int[] { 2, 2 })]
        [DataRow(new int[] { 4, 9, 5 }, new int[] { 9, 4, 9, 8, 4 }, new int[] { 9, 4 })]
        public void TestIntersection2(int[] num1, int[] num2, int[] expected)
        {
            var actul = s.Intersection2(num1, num2);
            Assert.IsTrue(actul.OrderBy(p => p).SequenceEqual(expected.OrderBy(p => p)));
        }

        [TestMethod]
        [DataRow(2, 3, 5)]
        [DataRow(10, 100, 110)]
        [DataRow(101, 110, 211)]
        public void TestGetSum(int a, int b, int expected)
        {
            var actul = s.GetSum(a, b);
            Assert.AreEqual(expected, actul);
        }

        [TestMethod]
        [DataRow(8, 3, 5)]
        [DataRow(100, 1, 99)]
        [DataRow(101, 110, -9)]
        public void TestGetSub(int a, int b, int expected)
        {
            var actul = s.GetSub(a, b);
            Assert.AreEqual(expected, actul);
        }

        [TestMethod]
        [DataRow(new int[] { 3, 2, 1 }, 1)]
        [DataRow(new int[] { 2, 2, 2, 3, 3, 3, 1 }, 1)]
        [DataRow(new int[] { 2, 2, 3, 1 }, 1)]
        [DataRow(new int[] { 1, 2 }, 2)]
        [DataRow(new int[] {1, 2, 2, 5, 3, 5},2)]
        [DataRow(new int[] {1, 2, -2147483648}, -2147483648)]
        public void TestThirdMax(int[] nums,int expected)
        {
            var actul = s.ThirdMax(nums);
            Assert.AreEqual(expected, actul);
        }

        [TestMethod]
        [DataRow("1", "2", "3")]
        [DataRow("9","99","108")]
        [DataRow("11", "22", "33")]
        [DataRow("0", "0", "0")]
        [DataRow("19", "89", "108")]
        public void TestAddStrings(string a, string b, string expected)
        {
            var actul = s.AddStrings(a, b);
            Assert.AreEqual(expected, actul);
        }
    }
}
