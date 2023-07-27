using Datastructures.DataStructures.AvlTrees;
using Datastructures.DataStructures.BinaryTrees;
using Datastructures.DataStructures.Heaps;
using Datastructures.DataStructures.Searching_Algorithms;
using Datastructures.DataStructures.Sorting_Algorithms;
using Datastructures.DataStructures.Stacks;
using Datastructures.DataStructures.String_Manupulation;
using Datastructures.DataStructures.Tries;
using Datastructures.Graphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace Datastructures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var partition = new Partition();

            int n = 10;
            int[] nums = new int[] { 1,2,5}; // Memoization table

            var result = partition.CanPartitiom(nums);
            Console.WriteLine(result);
        }


        //public static int[] Merge(int[] nums1, int m, int[] nums2, int n)
        //{
        //    var temp = new int[m];

        //    for (var i = 0; i < m; i++) temp[i] = nums1[i];

        //    var idx1 = 0;
        //    var idx2 = 0;
        //    var pushIndex = 0;

        //    while (idx1 < m && idx2 < n)
        //    {
        //        nums1[pushIndex++] = temp[idx1] < nums2[idx2] ? temp[idx1++] : nums2[idx2++];
        //    }

        //    while (idx1 < m) nums1[pushIndex++] = temp[idx1++];
        //    while (idx2 < n) nums1[pushIndex++] = nums2[idx2++];
        //    return nums1;
        //}

        //public static int ClimbStairs(int n)
        //{
        //    if (n <= 3)
        //        return n;

        //    int[] dp = new int[n + 1];
        //    dp[0] = 1;
        //    dp[1] = 2;

        //    for (int i = 2; i <= n; i++)
        //    {
        //        dp[i] = dp[i-1] + dp[i-2];
        //    }

        //    return dp[n-1];
        //}

    }
//least memory space
//public class Solution1
//{
//    public string AddBinary(string a, string b)
//    {
//        var ls = new List<int>();

//        for (int i = a.Length - 1, j = b.Length - 1, remainder = 0; i >= 0 || j >= 0 || remainder > 0;)
//        {
//            var firstDigit = i >= 0 ? a[i--] - '0' : 0;
//            var secondDigit = j >= 0 ? b[j--] - '0' : 0;
//            ls.Add(firstDigit ^ secondDigit ^ remainder);
//            remainder = ((firstDigit | secondDigit) & remainder) | (firstDigit & secondDigit);
//        }
//        GC.Collect();
//        ls.Reverse();
//        return string.Concat(ls);
//    }
        //highest speed
    //    public static string AddBinaryFastest(string a, string b)
    //    {
    //        char[] A = (new string('0', Math.Max(a.Length, b.Length) + 1 - a.Length) + a).ToCharArray();

    //        int cy = 0;
    //        int ia = A.Length - 1;
    //        int ib = b.Length - 1;
    //        for (; ib >= 0 || cy != 0; ia--, ib--)
    //        {
    //            int p = (A[ia] - '0') + cy + (ib >= 0 ? b[ib] - '0' : 0);

    //            A[ia] = (char)((p & 1) + '0');

    //            cy = (p & 2) >> 1;
    //        }

    //        string res = A[0] == '0'
    //            ? new string(A, 1, A.Length - 1)
    //            : new string(A);
    //        return res;
    //    }

    //}
}
