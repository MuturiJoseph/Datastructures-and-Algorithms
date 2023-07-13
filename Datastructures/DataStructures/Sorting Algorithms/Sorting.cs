using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures.DataStructures.Sorting_Algorithms
{
    public class Sorting
    {
        public int[] BubbleSort(int[] array)
        {
            bool isSorted;
            for(int i = 0; i < array.Length; i++)
            {
                isSorted = true;
                for (int j = 1; j < array.Length - i; j++)
                    if (array[j] < array[j - 1])
                    {
                        Swap(array, j, j - 1);
                        isSorted = false;
                    }
                if(isSorted)
                    return array;
            }
            return array;
        }
        public int[] SelectionSort(int[] array)
        {
            //[3,4,7,1,8]
            for(int i = 0; i < array.Length; i++)
            {
                var minIndex = i;
                for(int j = i;j < array.Length; j++)
                    if (array[minIndex] < array[j])
                        minIndex = j;
                Swap(array, minIndex, i);
            }
            return array;
        }
        public int[] InsertionSort(int[] array)
        {
            for(int i = 1; i < array.Length; i++)
            {
                var current = array[i];
                var j = i - 1;
                while(j >= 0 && array[j] > current)
                {
                    array[j+1] = array[j];
                    j--;
                }
                array[j + 1] = current;
            }
            return array;
        }
        public void MergeSort(int[] array)
        {
            if (array.Length < 2)
                return;
            //Divide array into half
            var middle = array.Length / 2;

            int[] left = new int[middle];
            for(int i = 0; i < middle; i++)
                left[i] = array[i];

            int[] right = new int[array.Length - middle];
            for(int i = middle; i < array.Length; i++)
                right[i - middle] = array[i];

            //sort each array => recursive
            MergeSort(left);
            MergeSort(right);

            //marge the arrays
            Merge(left,right,array);
        }
        //private method for marging 2 arrays
        private void Merge(int[] left, int[] right, int[] result)
        {
            int i = 0, j = 0, k=0;
            while(i < left.Length && j < right.Length)
            {
                if (left[i] < right[j])
                    result[k++] = left[i++];
                result[k++] = right[j++];
            }

            while(i < left.Length)
                result[k++] = left[i++];

            while (j < right.Length)
                result[k++] = right[j++];
        }

        public int[] CountingSort(int[] array,int max)
        {
            int[] count = new int[max + 1];

            foreach(var i  in array)
                count[i]++;

            var k = 0;
            for(int i = 0; i < count.Length; i++)
                for(var j = 0; j < count[i]; j++)
                    array[k++] = i;
            return array;
        }
        public int[] BucketSort(int[] array,int numberOfBuckets)
        {
            var i = 0;
            foreach(var bucket in CreateBuckets(array,numberOfBuckets))
            {
                bucket.Sort();
                foreach (var item in bucket)
                    array[i++] = item;
            }
            return array;
        }
        private List<List<int>> CreateBuckets(int[] array,int numberOfBuckets)
        {
            List<List<int>> buckets = new List<List<int>>();

            for (int i = 0; i < numberOfBuckets; i++)
                buckets.Add(new List<int>());

            foreach (var item in array)
                buckets[item / numberOfBuckets].Add(item);

            return buckets;
        }
        private void Swap(int[] array,int index1,int index2)
        {
            var temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        //QuickSort -> mostly used in frameworks and languages
        public void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        private void QuickSort(int[] array, int start, int end)
        {
            if (start >= end)
                return;

            var boundary = partition(array, start, end);

            QuickSort(array, start, boundary - 1);
            QuickSort(array, boundary + 1, end);
        }

        private int partition(int[] array, int start, int end)
        {
            var pivot = array[end];
            var boundary = start - 1;
            for (var i = start; i <= end; i++)
                if (array[i] <= pivot)
                    Swap(array, i, ++boundary);

            return boundary;
        }
    }
}
