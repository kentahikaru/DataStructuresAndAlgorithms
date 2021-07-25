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

        public void Add(int key, string value)
        {
            if (key == null || string.IsNullOrEmpty(value))
                throw new ArgumentException("key or value is null");

            if (root == null)
            {
                root = new Node(key, value);
                return;
            }

            Node newNode = new Node(key, value);
            AddNode(root, newNode);
        }

        private void AddNode(Node currentNode, Node newNode)
        {
            if (newNode.key < currentNode.key)
            {
                if (currentNode.left == null)
                    AddNodeToLeft(currentNode, newNode);
                else
                    AddNode(currentNode.left, newNode);
            }
            else if (newNode.key > currentNode.key)
            {
                if (currentNode.right == null)
                    AddNodeToRight(currentNode, newNode);
                else
                    AddNode(currentNode.right, newNode);
            }
            else
            {
                newNode = null;
            }
        }

        private void AddNodeToLeft(Node currentNode, Node newNode)
        {
            currentNode.left = newNode;
            size++;
        }

        private void AddNodeToRight(Node currentNode, Node newNode)
        {
            currentNode.right= newNode;
            size++;
        }

        public void Remove(int key)
        {
            RemoveNode(root, key);
        }

        private void RemoveNode(Node node, int key)
        {
            if(node != null)
            {
                if(node.key == key)
                {
                    RemoveRootNode(node);
                    size--;
                }
                else if(key < node.key)
                    RemoveNode(node.left, key);
                else
                    RemoveNode(node.right, key);
            }
            else
            {
                throw new ArgumentException("node with key '" + key.ToString() + "' doesn't exist");
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

        public Node Get(int key)
        {
            return GetNode(root, key);
        }

        private Node GetNode(Node node, int key)
        {
            if(node == null)
            {
                throw new Exception("Didn't find node with key: " + key.ToString());
            }
            else
            {
                if(key == node.key)
                {
                    return node;
                }
                else if(key < node.key)
                {
                    return GetNode(node.left, key);
                }
                else
                {
                    return GetNode(node.right, key);
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