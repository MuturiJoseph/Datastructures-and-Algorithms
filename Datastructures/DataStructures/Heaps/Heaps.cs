using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Datastructures.DataStructures.Heaps
{
    public class Heaps
    {
        private int[] heap = new int[10];
        private int size;

        public void Insert(int value)
        {
            if(IsFull())
                throw new InvalidOperationException();

            heap[size++] = value;

            BubbleUp();
        }

        public int Remove()
        {
            if(IsEmpty())
                throw new InvalidOperationException();

            var root = heap[0];
            heap[0] = heap[--size];
            heap[size] = 0;

            BubbleDown();

            return root;
        }
        public int Max()
        {
            if(IsEmpty())
                throw new InvalidOperationException();

            return heap[0];
        }
        public bool IsFull()
        {
            return size == heap.Length;
        }

        public bool IsEmpty()
        {
            return size == 0;
        }

        private void BubbleUp()
        {
            var index = size - 1;
            while (index > 0 && heap[index] > heap[Parent(index)])
            {
                Swap(index, Parent(index));
                index = Parent(index);
            }
        }

        private void BubbleDown()
        {
            var index = 0;
            while (index <= size && !IsValidParent(index))
            {
                var largerChildIndex = LargerChildIndex(index);
                Swap(index, largerChildIndex);
                index = largerChildIndex;
            }
        }

        private int Parent(int index)
        {
            return (index - 1) / 2;
        }

        private void Swap(int index,int parentIndex)
        {
            var temp = heap[index];
            heap[index] = heap[parentIndex];
            heap[parentIndex] = temp;
        }

        private int LargerChildIndex(int index)
        {
            if (!HasLeftChild(index))
                return index;
            if(!HasRightChild(index))
                return LeftChildIndex(index);

            return (LeftChild(index) > RightChild(index))
                    ? LeftChildIndex(index) :
                    RightChildIndex(index);
        }

        private bool HasLeftChild(int index)
        {
            return LeftChildIndex(index) <= size;
        }

        private bool HasRightChild(int index)
        {
            return RightChildIndex(index) <= size;
        }

        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
                return true;

            var isValid = heap[index] >= LeftChild(index);

            if (HasRightChild(index))
                isValid = isValid && heap[index] >= RightChild(index);

            return isValid;
        }

        private int LeftChild(int index)
        {
            return heap[LeftChildIndex(index)];
        }

        private int RightChild(int index)
        {
            return heap[RightChildIndex(index)];
        }

        private int LeftChildIndex(int index)
        {
            return index * 2 + 1;
        }

        private int RightChildIndex(int index)
        {
            return index * 2 + 2;
        }
    }
}
