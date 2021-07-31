namespace HashTable
{
    public class Node
    {
        public string key { get; set; }
        public string value { get; set; }
        public Node next { get; set;}

        public Node(string key, string value)
        {
            this.key = key;
            this.value = value;
            this.next = null;
        }
    }
}