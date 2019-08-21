using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        [DataRow(38,2)]
        [DataRow(22,4)]
        [DataRow(10,1)]
        [DataRow(8,8)]
        public void TestAddDigits(int x,int y)
        {
            var res = s.AddDigits(x);
            Assert.AreEqual(y, res);
        }

        [TestMethod]
        [DataRow(-2147483648,false)]
        [DataRow(1, true)]
        [DataRow(6, true)]
        [DataRow(8, true)]
        [DataRow(14, false)]
        public void TestIsUgly(int x,bool expected)
        {
            var res = s.IsUgly(x);
            Assert.AreEqual(expected, res);
        }
    }
}
