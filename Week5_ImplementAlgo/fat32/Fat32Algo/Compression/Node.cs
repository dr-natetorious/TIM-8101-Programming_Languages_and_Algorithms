using System;
using System.Collections.Generic;
using System.Linq;

namespace Fat32Algo.Compression
{
    /// <summary>
    /// Represents a node in the Huffman Compression frequency tree.
    /// </summary>
    class Node : IComparable<Node>, IComparer<Node>
    {
        /// <summary>
        /// Gets or sets the left branch
        /// </summary>
        public Node Left { get; set; }

        /// <summary>
        /// Gets or sets the right branch.
        /// </summary>
        public Node Right { get; set; }

        /// <summary>
        /// Gets or sets the value of this node.
        /// </summary>
        public byte Value { get; set; }

        /// <summary>
        /// Gets or sets the frequency of occurring
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        /// Gets a value indicating wheather this is a leaf node.
        /// </summary>
        public bool IsLeaf
        {
            get { return Left == null && Right == null; }
        }

        /// <summary>
        /// Implements the IComparable.
        /// </summary>
        /// <param name="other">The node to come which comes first.</param>
        /// <returns>
        /// <list type="bullet">
        /// <item>-1 this is before</item>
        /// <item>0 these are equal</item>
        /// <item>1 this is after</item>
        /// </list>
        /// </returns>
        public int CompareTo(Node other)
        {
            return this.Frequency - other.Frequency;
        }

        /// <summary>
        /// Implements the IComparer.
        /// </summary>
        /// <param name="x">This</param>
        /// <param name="y">That</param>
        /// <returns><see cref="CompareTo(Node)"/> value.</returns>
        public int Compare(Node x, Node y)
        {
            return x.CompareTo(y);
        }

        /// <summary>
        /// Gets a debug friendly string.
        /// </summary>
        public override string ToString()
        {
            return $"Value={Value}, F={Frequency}, Left={Left?.Frequency}, Right={Right?.Frequency}";
        }

        /// <summary>
        /// Build the tree based on the frequency information
        /// </summary>
        /// <param name="frequencies">
        /// An array equal to <see cref="Huffman.R"/> length.
        /// 
        /// Each position directly aligns with the value in the domain.
        /// 
        /// Example frequency of value 5 is equal to frequency[5]
        /// </param>
        /// <returns>The root node</returns>
        public static Node BuildTrie(int[] frequencies)
        {
            // Create a bunch of trees that are single nodes
            // Skip any values which are zero as they are not present
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

            // Continue merging the tree until we have a single node
            // This is accomplished by taking the two smallest trees and merging them
            // Since we're building up the final result will be correctly ordered.
            while (list.Count > 1)
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

            // Finally return last remaining value which must be root
            return list.FirstOrDefault();
        }

        /// <summary>
        /// Find and remove the minimum node from the <paramref name="nodeList"/>.
        /// </summary>
        /// <remarks>
        /// TODO: This should use a priority queue instead of resorting each time.
        /// </remarks>
        /// <param name="nodeList">The list of nodes to use.</param>
        /// <returns>The minimum node based on <see cref="Node.Frequency"/></returns>
        private static Node GetMinimum(List<Node> nodeList)
        {
            var min = nodeList.OrderBy(n => n.Frequency).FirstOrDefault();
            if (min != null)
            {
                nodeList.Remove(min);
            }

            return min;
        }
    }
}
