using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fat32Algo.Compression
{
    class Node : IComparable<Node>, IComparer<Node>
    {
        public Node Left { get; set; }

        public Node Right { get; set; }

        public byte Value { get; set; }

        public int Frequency { get; set; }

        public bool IsLeaf
        {
            get { return Left == null && Right == null; }
        }

        public int CompareTo(Node other)
        {
            return this.Frequency - other.Frequency;
        }

        public int Compare(Node x, Node y)
        {
            return x.CompareTo(y);
        }

        public override string ToString()
        {
            return $"Value={Value}, F={Frequency}, Left={Left?.Frequency}, Right={Right?.Frequency}";
        }

        public static Node BuildTrie(int[] frequencies)
        {
            var list = new List<Node>();
            for (var ix = 0; ix < frequencies.Length; ix++)
            {
                if (frequencies[ix] == 0)
                {
                    continue;
                }

                list.Add(
                    new Node
                    {
                        Value = (byte)ix,
                        Frequency = frequencies[ix]
                    });
            }

            while (list.Count > 0)
            {
                // Merge the two smallest trees...
                var x = GetMinimum(list);
                var y = GetMinimum(list);

                var parent = new Node
                {
                    Value = 0,
                    Frequency = x.Frequency + y.Frequency,
                    Left = x,
                    Right = y
                };
                list.Add(parent);
            }

            return list.FirstOrDefault();
        }

        private static Node GetMinimum(List<Node> nodes)
        {
            var min = nodes.OrderBy(n => n.Frequency).FirstOrDefault();
            if (min != null)
            {
                nodes.Remove(min);
            }

            return min;
        }
    }
}
