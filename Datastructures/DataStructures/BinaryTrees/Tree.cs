using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Datastructures.DataStructures.BinaryTrees.Tree;

namespace Datastructures.DataStructures.BinaryTrees
{
    public class Tree
    {
        public class Node
        {
            public int _value;
            public Node leftChild;
            public Node rightChild;
            public Node(int value)
            {
                this._value = value;
            }
            public override string ToString()
            {
                return "Node="+ _value.ToString();
            }
        }
        public Node root;
        public void Insert(int value)
        {
            var node = new Node(value);

            if(root == null)
            {
                root = node;
                return;
            }
            var current = root;
            while (true)
            {
                if (value < current._value)
                {
                    if (current.leftChild == null)
                    {
                        current.leftChild = node;
                        break;
                    }
                    current = current.leftChild;
                }
                else
                {
                    if (current.rightChild == null)
                    {
                        current.rightChild = node;
                        break;
                    }
                    current = current.rightChild;
                }
            }
        }
        public bool Find(int value)
        {
            var current = root;
            while(current != null)
            {
                if(value < current._value)
                    current = current.leftChild;
                else if(value > current._value)
                    current = current.rightChild;
                else
                    return true;
            }
            return false;
            //if (root == null)
            //    throw new InvalidOperationException();

            //var current = root;
            //while (true)
            //{
            //    if (value == current._value)
            //        return true;
            //    else
            //    {
            //        if (value < current._value)
            //        {
            //            if (current.leftChild == null)
            //                return false;
            //            else
            //            {
            //                if (value == current._value)
            //                    return true;
            //                current = current.leftChild;
            //            }
            //        }
            //        else
            //        {
            //            if (current.rightChild == null)
            //                return false;
            //            else
            //            {
            //                if (value == current._value)
            //                    return true;
            //                current = current.rightChild;
            //            }
            //        }
            //    }
            //}
        }

        public void TraversePreOrder()
        {
            TraversePreOrder(root);
        }
        public void TraverseInOrder()
        {
            TraverseInOrder(root);
        }
        public void TraversePostOrder()
        {
            TraversePostOrder(root);
        }
        private void TraversePreOrder(Node root)
        {
            //base
            if(root == null)
                return;

            Console.WriteLine(root);
            TraversePreOrder(root.leftChild);
            TraversePreOrder(root.rightChild);
        }
        private void TraverseInOrder(Node root)
        {
            //base
            if (root == null)
                return;

            TraverseInOrder(root.leftChild);
            Console.WriteLine(root);
            TraverseInOrder(root.rightChild);
        }
        private void TraversePostOrder(Node root)
        {
            //base
            if (root == null)
                return;

            TraversePostOrder(root.leftChild);
            TraversePostOrder(root.rightChild);
            Console.WriteLine(root);
        }

        public int Height()
        {
            return Height(root);
        }
        private int Height(Node root)
        {
            if(root == null)
                return -1;

            if(IsLeaf(root))
                return 0;
            return 1 + Math.Max(
                Height(root.rightChild),
                Height(root.leftChild));
        }

        //for binarySearchTree
        // time complexity -> O(log n)
        public int MinValue()
        {
            if (root == null)
                throw new InvalidOperationException();

            var current = root;
            var lastCurrent = current;
            while(current != null)
            {
                lastCurrent = current;
                current = current.leftChild;
            }
            return lastCurrent._value;
        }

        //for binaryTree
        // time complexity -> O(n)
        private int MinValue(Node root)
        {
            if (IsLeaf(root))
                return root._value;

            var left = MinValue(root.leftChild);
            var right = MinValue(root.rightChild);

            return Math.Min(Math.Min(left, right),root._value);
        }

        public bool Equal(Tree other)
        {
            if (other == null)
                return false;

            return Equal(root, other.root);
        }
        private bool Equal(Node first, Node second)
        {
            if (first == null && second == null)
                return true;

            if(first != null && second != null)
                return first._value == second._value
                    && Equal(first.leftChild,second.leftChild)
                    && Equal(first.rightChild,second.rightChild);

            return false;
        }

        public bool IsBinaryTree()
        {
            return IsBinaryTree(root, int.MinValue, int.MaxValue);
        }

        private bool IsBinaryTree(Node root,int min, int max)
        {
            if (root == null)
                return true;
            if(root._value < min || root._value > max)
                return false;

            return IsBinaryTree(root.leftChild, min, root._value - 1)
                && IsBinaryTree(root.rightChild,root._value + 1,max);
        }

        public void SwapRoot()
        {
            var temp = root.leftChild;
            root.leftChild = root.rightChild;
            root.rightChild = temp;
        }

        public ArrayList NodesAtKthDistance(int distance)
        {
            var list = new ArrayList();
            NodesAtKthDistance(root, distance,list);
            return list;
        }

        private void NodesAtKthDistance(Node root,int distance,ArrayList list)
        {
            if (root == null)
                return;

            if (distance == 0)
            {
                list.Add(root._value);
                return;
            }
            NodesAtKthDistance(root.leftChild, distance - 1,list);
            NodesAtKthDistance(root.rightChild, distance - 1,list);
        }

        public void LevelOrderTraversal()
        {
            for(int i = 0; i <= Height(); i++)
            {
                foreach(var value in NodesAtKthDistance(i))
                    Console.WriteLine(value);
            }
        }

        private bool IsLeaf(Node root)
        {
            return root.leftChild == null && root.rightChild == null;
        }
    }
}
