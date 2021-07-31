using System;

namespace HashTable
{
    public class HashTable
    {
        private int tableSize { get; set; }
        private int size { get; set; }
        private Node[] table { get; set; }
        private Node currentNode { get; set; }
        private int currentIndex { get; set; }

        public HashTable(int tableSize)
        {
            this.size = 0;
            this.tableSize = tableSize;
            this.table = new Node[tableSize];
            
            for(int i = 0; i < this.table.Length; i++)
            {
                table[i] = null;
            }
        }

        public bool Add(string key, string value)
        {
            if(Find(key) != null)
            {
                return false;
            }

            Node newNode = new Node(key, value);
            int block = HashKey(key);

            newNode.next = table[block];
            table[block] = newNode;
            this.size++;
            return true;
        }

        public string Get(string key)
        {
            Node node = Find(key);
            if(node == null)
            {
                return string.Empty;
            }
            else
            {
                return node.value;
            }
        }

        public bool Includes(string key)
        {
            if (Find(key) == null)
                return false;
            else
                return true;
        }

        public void Remove(string key)
        {
            int block = HashKey(key);
            Node node = table[block];

            if (node == null)
            {
                throw new Exception("Table doesn't contain key: " + key);
            }
            else if(string.Equals(key, node.key))
            {
                table[block] = node.next;
                node = null;
                this.size--;
            }
            else
            {
                while(node.next != null)
                {
                    node = node.next;
                    if (string.Equals(key, node.key))
                    {
                        node = node.next;
                        this.size--;
                        return;
                    }
                    
                }
                throw new Exception("Table doesn't contain key: " + key);
            }
        }

        public void RemoveAll()
        {
            for(int i = 0; i < this.tableSize; i++)
            {
                Node node = table[i];

                if (node != null && node.next != null)
                {
                    do
                    {
                        while (node.next.next != null)
                            node = node.next;

                        node.next = null;
                        node = table[i];
                    } while (table[i].next != null);
                }

                if (table[i] != null)
                {
                    table[i].next = null;
                    table[i] = null;
                }
            }
            
            this.size = 0;
        }

        public int GetSize()
        {
            return this.size;
        }

        public Node Find(string key)
        {
            int block = HashKey(key);
            Node node = table[block];

            while(node != null)
            {
                if (string.Equals(key, node.key))
                    return node;
                node = node.next;
            }

            return null;
        }

        public int HashKey(string key)
        {
            long h = 0;
            for(int i = 0; i < key.Length; i++)
            {
                h = (h << 2) + key[i];
            }

            return (int)Math.Abs(h % tableSize);
        }

        public void InitializeIterator()
        {
            currentNode = null;
            currentIndex = this.tableSize;

            for(int i = 0; i < this.tableSize; i++)
            {
                if (table[i] == null)
                    continue;
                else
                {
                    currentNode = table[i];
                    currentIndex = i;
                    break;
                }
            }
        }

        public bool HasNext()
        {
            if(currentNode == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string GetNextKey()
        {
            if (currentNode == null)
            {
                return string.Empty;
            }

            var key = currentNode.key;
            if (currentNode.next != null)
            {
                currentNode = currentNode.next;
                return key;
            }
            else
            {
                for(int i = currentIndex + 1; i < this.tableSize; i++)
                {
                    if (table[i] == null)
                        continue;
                    currentNode = table[i];
                    currentIndex = i;
                    return key;
                }
                currentNode = null;
                currentIndex = this.tableSize;
                return key;
            }
        }
    }
}