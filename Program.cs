using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hash_tables
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable(10);
            hashtable_custom htc = new hashtable_custom();
            ht.Add(7777, "kharray");
            ht.Add(3433, "hichem smati");
            ht.Add(9999, "ey ey");
            ht.Add(6674, "way way way");
            ht.Add(3461, "stik tik tik");
            ht.Add(1212, "boldog");
            ht.Add(8888, "del piero");
            Console.WriteLine(ht[9999]);

            htc.insert(5, "zidane");
            htc.insert(3, "maldini");
            htc.insert(2, "cannavaro");
            htc.insert(10, "bergkamp");
            htc.insert(7, "figo");
            htc.insert(4, "lahm");
            htc.insert(6, "xavi");
            htc.insert(1, "buffon");
            htc.insert(8, "scholes");
            htc.insert(9, "henry");
            htc.insert(11, "drogba el kharray");
            Console.WriteLine(htc.retrieve(10));
        }
    }
    class hashtable_custom
    {
        class hashentry
        {
            int key;
            string data;
            public hashentry(int key, string data)
            {
                this.key = key;
                this.data = data;
            }
            public int getkey()
            {
                return key;
            }
            public string getdata()
            {
                return data;
            }
        }
        int maxSize = 10;
        hashentry[] table;
        public hashtable_custom()
        {
            table = new hashentry[maxSize];
            for (int i = 0; i < maxSize; i++)
            {
                table[i] = null;
            }
        }
        public string retrieve(int key)
        {
            int hash = key % maxSize;
            while (table[hash] != null && table[hash].getkey() != key)
            {
                hash = (hash + 1) % maxSize;
            }
            if (table[hash] == null)
            {
                return "";
            }
            else
            {
                return table[hash].getdata();
            }
        }
        public void insert(int key, string data)
        {
            if (!checkOpenSpace())
            {
                Console.WriteLine("table is at full capacity!");
                return;
            }
            int hash = (key % maxSize);
            while (table[hash] != null && table[hash].getkey() != key)
            {
                hash = (hash + 1) % maxSize;
            }
            table[hash] = new hashentry(key, data);
        }
        private bool checkOpenSpace()
        {
            bool isOpen = false;
            for (int i = 0; i < maxSize; i++)
            {
                if (table[i] == null)
                {
                    isOpen = true;
                }
            }
            return isOpen;
        }
    }
}
