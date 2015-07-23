using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_4
{
    public struct Range {
        public int Start;
        public int Finish;

        public override string ToString()
        {
            return Start + " - " + Finish;
        }
    }

    
    class Interval : IComparable<Interval>
    {
 

        public Range Range;
        private List<Range> taken = new List<Range>();
        public long Sum = 0;

        public Interval(Range range,long sum)
        {
            this.Sum = sum;
            this.Range = range;
            taken.Add(range);
        }

        public bool CanAddRange(Range range) {
            foreach (Range r in taken) {
                if (intersects(r, range))
                    return false;
            }
            return true;
        }

        public void AddRange(Range range) {
            taken.Add(range);
        }

        private bool intersects(Range rangeA, Range rangeB)
        {
            if ((rangeA.Start >= rangeB.Start && rangeA.Start <= rangeB.Finish)
                || (rangeA.Finish >= rangeB.Start && rangeA.Finish <= rangeB.Finish)
                || (rangeA.Start >= rangeB.Start && rangeA.Finish <= rangeB.Finish)
                || (rangeA.Start <= rangeB.Start && rangeA.Finish >= rangeB.Finish))
                return true;

            return false;
        }

        public int CompareTo(Interval other) {
            return -1*Sum.CompareTo(other.Sum);
        }

    }
}
