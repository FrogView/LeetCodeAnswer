using System;
using System.Collections.Generic;

namespace LeetCodeAnswer
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();
            object result;
            result = solution.DeleteDuplicates(new ListNode(1) { next = new ListNode(1) { next = new ListNode(2) { next = new ListNode(3) { next = new ListNode(3) } } } });

            Console.WriteLine("Hello World!");
        }
    }



}
