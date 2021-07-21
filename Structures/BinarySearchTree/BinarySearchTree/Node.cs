namespace Structures.BinarySearchTree.BinarySearchTree
{
    public class Node
    {
        public int key { get;set; }
        public string value { get;set; }
        public Node left { get; set; }
        public Node right { get; set; }

        public Node(int key, string value)
        {
            this.key = key;
            this.value = value;
        }
    }
}