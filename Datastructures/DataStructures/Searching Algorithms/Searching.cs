using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures.DataStructures.Searching_Algorithms
{
    public class Searching
    {
        public int LinearSearch(int[] array,int target)
        {
            for(int i = 0; i < array.Length; i++)
                if (array[i] == target)
                    return i;
            return -1;
        }

        //Recursive method for binarySearch
        public int BinarySearchRec(int[] array, int target)
        {
            return BinarySearchRec(array,target, 0, array.Length - 1);
        }
        private int BinarySearchRec(int[] array,int target,int left,int right)
        {
            if(right < left)
                return -1;

            var middle = (left + right)/2;

            if (array[middle] == target)
                return middle;

            if (target < array[middle])
                return BinarySearchRec(array,target,left,middle - 1);

            return BinarySearchRec(array, target, middle+1, right);
        }

        //Iterative method for binarySearch
        public int BinarySearchIte(int[] array,int target)
        {
            var left = 0;
            var right = array.Length - 1;

            while(left <= right)
            {
                var middle = (left + right)/2;
                if (array[middle] == target)
                    return middle;

                if(target < array[middle])
                    right = middle - 1;
                else
                    left = middle + 1;
            }
            return -1;
        }

        public int TernarySearch(int[] array, int target)
        {
            return TernarySearch(array, target, 0, array.Length -1);
        }
        private int TernarySearch(int[] array,int target,int left,int right)
        {
            if(right < left)
                return -1;

            var partitionSize = (right - left)/3;
            var mid1 = left + partitionSize;
            var mid2 = right - partitionSize;

            if (array[mid1] == target)
                return mid1;

            if (array[mid2] == target)
                return mid2;

            if(target < array[mid1])
                return BinarySearchRec(array,target,left,mid1 - 1);

            if (target > array[mid1])
                return BinarySearchRec(array, target, mid2 + 1, right);

            return BinarySearchRec(array, target, mid1 + 1, mid2 - 1);
        }

        public int JumpSearch(int[] array,int target)
        {
            if(array.Length == 0)
                return -1;

            var blockSize = (int) Math.Sqrt(array.Length);
            int start = 0;
            int next = blockSize;

            while (array[next - 1] < target)
            {
                start = next;
                if(start >= array.Length)
                    break;

                next += blockSize;
                if(next > array.Length)
                    next = array.Length;

                for(int i = start;i < next;i++)
                    if (array[i] == target)
                        return i;
            }
            return -1;
        }
        public int ExponentialSearch(int[] array,int target)
        {
            int bound = 1;
            while (bound < array.Length && array[bound] < target)
                bound *= 2;

            int left = bound / 2;
            int right = Math.Min(bound , array.Length - 1);

            return BinarySearchRec(array, target, left, right);
        }
    }
}
