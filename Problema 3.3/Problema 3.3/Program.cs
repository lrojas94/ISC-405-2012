using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read both element's lists.
            int aSize = Convert.ToInt32(Console.ReadLine());
            String[] elementsA = Console.ReadLine().Split(' ');
            int bSize = Convert.ToInt32(Console.ReadLine());
            String[] elementsB = Console.ReadLine().Split(' ');

            //Arrays to check in O(1);
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

            int restrictions = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < restrictions; i++) {
                String[] restriction = Console.ReadLine().Split(' ');
                int ra = Convert.ToInt32(restriction[0]) - 1, rb = Convert.ToInt32(restriction[1]) - 1;
                //Check if they are in list A.
                if ((listA[ra] && listA[rb]) || (listB[ra] && listB[rb]))
                {
                    Console.WriteLine("Wrong Answer");
                    return;
                }

            }

            Console.WriteLine("Accepted!");
            Console.Read();

        }
    }
}
