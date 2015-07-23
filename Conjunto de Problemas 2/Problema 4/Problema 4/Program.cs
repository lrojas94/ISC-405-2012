using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_4
{
    class Program
    {
        public static List<int> Input = new List<int>();
        private static int K;
        private static List<Interval> intervals = new List<Interval>();
        static void Main(string[] args)
        {
            string[] init = Console.ReadLine().Split(' ');
            int n = Convert.ToInt32(init[0]);
            K = Convert.ToInt32(init[1]);
            //Input = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToList();
            for (int i = 0; i < n; i++) {
                int num = Convert.ToInt32(Console.ReadLine());
                Input.Add(num);
            }

            generateIntervals();
            MaxSum();
            Console.Read();
        }
        

        private static void generateIntervals() { // O(n^2) -> 10^4 = Max Input, so Max O = 10^8. 
            for (int i = 0; i < Input.Count; i++) {
                int sum = 0;
                for (int j = i; j < Input.Count; j++)
                {
                    sum += Input[j];
                    Range range = new Range
                    {
                        Start = i,
                        Finish = j
                    };
                    intervals.Add(new Interval(range, sum));
                }
            }
        }

        public static void MaxSum() { // -> Approach GREEDY/BRUTE FORCE.
            long MaxFound = Int64.MinValue;
            intervals.Sort(); //Sort ascending (Base of the Greedy approach)
            for (int i = 0; i < intervals.Count; i++) {
                long actualSum = intervals[i].Sum;
                List<Range> taken = new List<Range>();
                taken.Add(intervals[i].Range);
                int k = K - 1; //Asume we already picked this range.
                for (int j = 0; j < intervals.Count; j++) {
                    if (k == 0)
                        break;
                    if (intervals[i].CanAddRange(intervals[j].Range)) {
                        actualSum += intervals[j].Sum; //Just pick it. Since the approach is greedy we just take the
                        intervals[i].AddRange(intervals[j].Range); //biggest sum, which is stored at J.
                        taken.Add(intervals[j].Range);
                        k--;
                    }
                }

                if (k == 0)
                    MaxFound = Math.Max(MaxFound, actualSum);
                
                
            }

            Console.WriteLine(MaxFound);
        }
    }
}
