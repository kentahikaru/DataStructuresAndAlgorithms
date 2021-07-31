using System;

namespace HashTable
{
    public class HashTable
    {
        private int tableSize { get; set; }
        private int size { get; set; }
        private Node[] table { get; set; }

        public HashTable(int tableSize)
        {
            this.size = 0;
            this.tableSize = tableSize;
            this.table = new Node[tableSize];
            
            for(int i = 0; i < this.table ; i++)
            {
                table[i] = null;
            }
        }
    }
}