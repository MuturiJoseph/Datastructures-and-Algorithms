using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Datastructures.DataStructures.BinaryTrees.Tree;

namespace Datastructures.DataStructures.AvlTrees
{
    public class AvlTree
    {
        private class Node
        {
            public int _value;
            public int height;
            public Node leftChild;
            public Node rightChild;

            public Node(int value)
            {
                _value = value;
            }
            public override string ToString()
            {
                return "Node=" + _value.ToString();
            }
        }
        private Node root;

        public void AvlInsert(int value)
        {
            root = AvlInsert(value, root);
        }
        private Node AvlInsert(int value,Node root)
        {
            if (root == null)
                return new Node(value) ;

            if(value < root._value)
                root.leftChild = AvlInsert(value,root.leftChild);
            if(value > root._value)
                root.rightChild = AvlInsert(value,root.rightChild);

            SetHeight(root);

            return Balance(root);
        }

        private Node Balance(Node root)
        {
            if (IsLeafHeavy(root))
            {
                if (BalanceFactor(root.leftChild) < 0)
                    root.leftChild = RotateLeft(root.leftChild);
                return RotateRight(root);
            }
            else if (IsRightHeavy(root))
            {
                if (BalanceFactor(root.rightChild) > 0)
                    root.rightChild = RotateRight(root.rightChild);
                return RotateLeft(root);
            }
            return root;
        }

        private Node RotateLeft(Node root)
        {
            var newRoot = root.rightChild;

            root.rightChild = newRoot.leftChild;
            newRoot.leftChild = root;

            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }

        private Node RotateRight(Node root)
        {
            var newRoot = root.leftChild;

            root.leftChild = newRoot.rightChild;
            newRoot.rightChild = root;

            SetHeight(root);
            SetHeight(newRoot);

            return newRoot;
        }

        private void SetHeight(Node node)
        {
            node.height = Math.Max(
                Height(node.rightChild),
                Height(node.leftChild)) + 1;
        }
        private bool IsLeafHeavy(Node node)
        {
            return BalanceFactor(node) > 1;
        }
        private bool IsRightHeavy(Node node)
        {
            return BalanceFactor(node) < -1;
        }
        private int BalanceFactor(Node node)
        {
            return (node == null) ? 0 : Height(node.leftChild) - Height(node.rightChild);
        }

        private int Height(Node node)
        {
            return (node == null) ? -1 : node.height;
        }
    }
}
