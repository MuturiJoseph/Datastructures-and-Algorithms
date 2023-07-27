using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures
{
    internal class Partition
    {
        public bool CanPartitiom(int[] nums)
        {
            //tabulation
            if (nums.Length < 2) return false;
            int sum = 0;
            for (int i = 0; i < nums.Length; i++) sum += nums[i];
            if (sum % 2 != 0) return false;
            sum /= 2;
            bool[] dp = new bool[sum + 1];
            dp[0] = true;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = sum; j > 0; j--)
                {
                    if (j - nums[i] >= 0)
                        dp[j] = dp[j] || dp[j - nums[i]];
                }
            }
            return dp[sum];
        }

        public static bool CanPartitiomMemo(int[] nums)
        {
            //memoization

            if (nums.Length < 2) return false;

            int totalSum = nums.Sum();

            if (totalSum % 2 != 0) return false;

            int targetSum = totalSum / 2;

            Dictionary<string, bool> memo = new Dictionary<string, bool>();

            return PartitionHelper(nums, targetSum, 0, memo);
        }
        private static bool PartitionHelper(int[] nums, int targetSum, int index, Dictionary<string, bool> memo)
        {
            if (targetSum == 0) return true;
            if (index >= nums.Length || targetSum < 0) return false;

            string key = $"{index}-{targetSum}";
            if (memo.ContainsKey(key)) return memo[key];

            bool includeCurrent = PartitionHelper(nums, targetSum - nums[index], index + 1, memo);
            bool excludeCurrent = PartitionHelper(nums, targetSum, index + 1, memo);

            bool result = includeCurrent || excludeCurrent;

            memo[key] = result;
            return result;
        }
    }
}
