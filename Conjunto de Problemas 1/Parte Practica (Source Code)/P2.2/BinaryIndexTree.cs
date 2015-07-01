using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_2._2
{
    class BinaryIndexTree
    {
        private int[] tree;
        public BinaryIndexTree(int n) {
            tree = new int[n];
            for (int i = 0; i < tree.Length; i++) {
                tree[i] = 0;
            }
        }

        public int Sum(int sumToIndex) {
            int sum = 0;
            for (; sumToIndex != 0; sumToIndex -= (sumToIndex & (-sumToIndex))) {
                sum += tree[sumToIndex]; 
            }
            return sum;
        }

        public int Sum(int sumFromIndex,int sumToIndex)
        {
            return this.Sum(sumToIndex) - sumFromIndex == 1 ? 0 : this.Sum(sumFromIndex - 1);
        }

        public void update(int index, int value) {
            for (; index < tree.Length; index += (index & (-index))) {
                tree[index] += value;
            }
        }
    }
}
