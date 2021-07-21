using System;
using System.Text;

namespace Structures.BinarySearchTree.BinarySearchTree
{
    public class BinarySearchTree
    {
        private int size;
        private Node root;

        public BinarySearchTree()
        {
            root = null;
            size = 0;
        }

        public bool Add(int key, string value)
        {
            if(key == null || string.IsNullOrEmpty(value))
                return false;

            Node newNode = new Node(key, value);
            return AddNode(root, newNode);
        }

        private bool AddNode(Node currentNode, Node newNode)
        {
            if(currentNode == null)
            {
                currentNode = newNode;
                size++;
                return true;
            }
            else
            {
                {
                    if(newNode.key < currentNode.key)
                    {
                        return AddNode(currentNode.left, newNode);
                    }
                    else if(newNode.key > currentNode.key)
                    {
                        return AddNode(currentNode.right, newNode);
                    }
                    else
                    {
                        newNode = null;
                        return false;
                    }
                }
            }
        }

        public bool Remove(int key)
        {
            return RemoveNode(root, key);
        }

        private bool RemoveNode(Node node, int key)
        {
            if(node != null)
            {
                if(node.key == key)
                {
                    RemoveRootNode(node);
                    size--;
                    return true;
                }
                else if(key < node.key)
                    return RemoveNode(node.left, key);
                else
                    return RemoveNode(node.right, key);
            }
            else
            {
                return false;
            }
        }

        private void RemoveRootNode(Node root)
        {
            Node temp;
            if(root.left == null && root.right == null)
            {
                root = null;
            }
            else if(root.right == null)
            {
                temp = root;
                root = root.left;
                temp = null;
            }
            else
            {
                MoveNodeMostLeft(root.right, root);
            }
        }

        private void MoveNodeMostLeft(Node node, Node root)
        {
            if(node != null && node.left == null)
            {
                Node temp = node;
                root.key = node.key;
                root.value = node.value;
                node = node.right;
                temp = null;
            }
            else
            {
                MoveNodeMostLeft(node.left, root);
            }
        }

        public void RemoveAll()
        {
            RemoveAllNodes(root);
            size = 0;
            root = null;
        }

        private void RemoveAllNodes(Node node)
        {
            if(node != null)
            {
                RemoveAllNodes(node.left);
                RemoveAllNodes(node.right);
                Console.WriteLine("Removing node with key " + node.key + " and value: " + node.value);
                node = null;
            }
        }

        public bool Get(int key, string value)
        {
            return GetNode(root, key, value);
        }

        private bool GetNode(Node node, int key, string value)
        {
            if(node == null)
            {
                value = string.Empty;
                return false;
            }
            else
            {
                if(key == node.key)
                {
                    value = node.value;
                    return true;
                }
                else if(key < node.key)
                {
                    return GetNode(node.left, key, value);
                }
                else
                {
                    return GetNode(node.right, key, value);
                }
            }
        }

        public bool Includes(int key)
        {
            return IncludesNode(root, key);
        }

        private bool IncludesNode(Node node, int key)
        {
            if(node == null)
                return false;
            else
            {
                if(key == node.key)
                    return true;
                else if (key < node.key)
                    return IncludesNode(node.left, key);
                else
                    return IncludesNode(node.right, key);
            }
        }

        public void DisplayAll()
        {
            DisplayAllNodes(root);
        }

        private void DisplayAllNodes(Node node)
        {
            if(node != null)
            {
                DisplayAllNodes(node.left);
                Console.WriteLine("Key: " + node.key + " Value: " + node.value);
                DisplayAllNodes(node.right);
            }
        }

        public int GetSize()
        {
            return size;
        }

        public int GetDepth()
        {
            return GetTreeDepth(root);
        }

        private int GetTreeDepth(Node node)
        {
            int depthLeft;
            int depthRight;

            if(node == null)
            {
                return 0;
            }
            else
            {
                depthLeft = GetTreeDepth(node.left);
                depthRight = GetTreeDepth(node.right);
                if(depthLeft > depthRight)
                    return depthLeft + 1;
                else
                    return depthRight + 1;
            }
        }
    }
}