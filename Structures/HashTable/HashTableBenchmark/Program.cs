using System;
using HashTable;

namespace HashTableBenchmark
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable.HashTable table = new HashTable.HashTable(5);

            for(int i = 0; i < 20; i++)
            {
                Console.WriteLine("key: " + i.ToString() + " hash: " + table.HashKey(i.ToString()));
            }

            Console.WriteLine(Environment.NewLine);
            table.Add("389", "one");
            table.Add("415", "two");
            table.Add("999", "tree");
            table.Add("4", "four");
            table.Add("9", "nine");
            table.Add("13", "thirteen");

            DisplayAll(table);

            Console.WriteLine("Removing all");

            table.RemoveAll();

            DisplayAll(table);
        }

        public static void DisplayAll(HashTable.HashTable table)
        {
            table.InitializeIterator();
            while(table.HasNext())
            {
                var key = table.GetNextKey();
                var value = table.Get(key);
                Console.WriteLine("key: " + key + " value: " + value);
            }
        }
    }
}
