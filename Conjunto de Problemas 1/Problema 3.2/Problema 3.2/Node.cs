using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problema_3._2
{
    enum Color {
       None,
       Red,
       Blue
    }

    class Node
    {
        public int value;
        public List<Node> children = new List<Node>();
        public bool check = false;
        public Color color = Color.None;

        public Node(int value) {
            this.value = value;
        }

    }
}
