using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_2._2
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryIndexTree tree = new BinaryIndexTree(10);
            tree.update(5, 10);
            for (int i = 0; i < 10; i++) {
                Console.WriteLine((i + 1) + " -> " + tree.Sum(i));
            }

            Console.WriteLine("From 6 - 10 => " + tree.Sum(5, 9));
            Console.Read();
        }
    }
}
