using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace DataStructures
{
    class avltree
    {
        class Node
        {
            public string key;
            public int value;
            public Node left;
            public Node right;
            public Node(string key, int value)
            {
                this.key = key;
                this.value = value;
            }
        }
        Node root;
        private int getHeight(Node current)
        {
            int height = 0;
            if (current != null)
            {
                int l = getHeight(current.left);
                int r = getHeight(current.right);
                int m = Math.Max(l, r);
                height = m + 1;
            }
            return height;
        }
        private int balance_factor(Node current)
        {
            int l = getHeight(current.left);
            int r = getHeight(current.right);
            int b_factor = l - r;
            return b_factor;
        }

        private Node RotateRR(Node p)
        {
            Node pivot = p.right;
            p.right = p.left;
            p.left = p;
            return pivot;
        }
        private Node RotateLL(Node p)
        {
            Node pivot = p.left;
            p.left = p.right;
            p.right = p;
            return pivot;
        }
        private Node RotateLR(Node p)
        {
            Node pivot = p.left;
            p.left = RotateRR(pivot);
            return RotateLL(p);
        }
        private Node RotateRL(Node p)
        {
            Node pivot = p.right;
            p.right = RotateLL(pivot);
            return RotateRR(p);
        }

        public void avltree_add(string key, int value)
        {
            Node newItem = new Node(key, value);
            if (root == null)
            {
                root = newItem;
            }
            else
            {
                root = Insert(root, newItem);
            }
        }
        private Node Insert(Node currentItem, Node n)
        {
            if (currentItem == null)
            {
                currentItem = n;
                return currentItem;
            }
            else if (n.value < currentItem.value)
            {
                currentItem.left = Insert(currentItem.left, n);
                currentItem = Balance(currentItem);
            }
            else if (n.value > currentItem.value)
            {
                currentItem.right = Insert(currentItem.right, n);
                currentItem = Balance(currentItem);
            }
            return currentItem;
        }
        private Node Balance(Node currentItem)
        {
            int bFactor = balance_factor(currentItem);
            if (bFactor > 1)
            {
                if (balance_factor(currentItem.left) > 0)
                {
                    currentItem = RotateLL(currentItem);
                }
                else
                {
                    currentItem = RotateLR(currentItem);
                }
            }
            else if (bFactor < -1)
            {
                if (balance_factor(currentItem.right) > 0)
                {
                    currentItem = RotateRL(currentItem);
                }
                else
                {
                    currentItem = RotateRR(currentItem);
                }
            }
            return currentItem;
        }
        public void avltree_min(string key, int value)
        {

        }
        public void avltree_lookup(avltree tree, int value)
        {
            if (root == null)
            {
                Console.WriteLine("Tree is empty");
            }
            DisplayTree(root);
        }
        private void DisplayTree(Node currentItem)
        {
            if (currentItem != null)
            {
                DisplayTree(currentItem.left);
                Console.Write("({0}) ", currentItem.value);
                DisplayTree(currentItem.right);
            }
        }
        public void avltree_max(string key, int value)
        {

        }
    }
}

