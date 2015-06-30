using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_3._3
{
    struct Pair {
        public int a, b;
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Read base input:
            List<Pair> restrictions = new List<Pair>();
            String[] nums;
            nums = Console.ReadLine().Split(' ');
            int elems = Convert.ToInt32(nums[0]), restCount = Convert.ToInt32(nums[1]);

            for (int i = 0; i < restCount; i++)
            {
                String[] r = Console.ReadLine().Split(' ');
                int a = Convert.ToInt32(r[0]), b = Convert.ToInt32(r[1]);
                Pair p = new Pair();
                p.a = a;
                p.b = b;
                restrictions.Add(p);

            }

            //Read both element's lists.
            int aSize = Convert.ToInt32(Console.ReadLine());
            String[] elementsA = Console.ReadLine().Split(' ');
            int bSize = Convert.ToInt32(Console.ReadLine());
            String[] elementsB = Console.ReadLine().Split(' ');

            //Arrays to check in O(1);
            if (aSize != bSize)
            {
                Console.WriteLine("INCORRECTO");
                return; //WA
            }
            bool[] listA = new bool[bSize + aSize], listB = new bool[bSize + aSize];
            for (int i = 0; i < elementsA.Length; i++) {
                int n = Convert.ToInt32(elementsA[i]) - 1;
                listA[n] = true;
            }
            for (int i = 0; i < elementsB.Length; i++)
            {
                int n = Convert.ToInt32(elementsB[i]) - 1;
                listB[n] = true;
            }

            for (int i = 0; i < restrictions.Count;i++) {
                Pair r = restrictions[i];
                if ((listA[r.a - 1] && listA[r.b - 1]) || (listB[r.a - 1] && listB[r.b - 1]))
                {
                    Console.WriteLine("INCORRECTO");
                    return; //WA
                }
            }
            

            Console.WriteLine("CORRECTO");
            Console.Read();

        }
    }
}
