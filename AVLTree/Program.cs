using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            avltree tree = new avltree();
            tree.avltree_add("a", 2);
            tree.avltree_add("b", 6);
            tree.avltree_add("c", 5);
        }
    }
}
