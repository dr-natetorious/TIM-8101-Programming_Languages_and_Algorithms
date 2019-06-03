// <copyright file="Huffman.cs" company="Nate Bachmeier">
// Copyright (c) Nate Bachmeier. All rights reserved.
// </copyright>

namespace Fat32Algo.Compression
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    /// <summary>
    /// Implements a variant of the Huffman Compression Algorithm.
    ///
    /// The code builds a tree of frequently used byte values,
    ///     such that frequently used values will have a short bit sequence.
    /// </summary>
    /// <remarks>
    /// Based on description from Sedgewick, R. (2014). Algorithms, Fourth Edition.
    /// </remarks>
    public class Huffman
    {
        /// <summary>
        /// Gets a constant for the maximum search space.
        /// </summary>
        private static readonly int R = byte.MaxValue;

        /// <summary>
        /// Compress the content into the fewest number of bits using Huffman Compressions.
        /// </summary>
        /// <remarks>
        /// The compressed payload will be laid out in memory as
        ///     { frequency chart } { compressed bytes }.
        /// </remarks>
        /// <param name="content">The byte stream to be compressed.</param>
        /// <returns>The compressed payload.</returns>
        public static byte[] Compress(byte[] content)
        {
            // Determine the character frequencies...
            int[] frequencies = new int[R];
            foreach (var ch in content)
            {
                frequencies[ch]++;
            }

            // Sort them based on a tree, then get the code book.
            Node root = Node.BuildTrie(frequencies);
            var codes = BuildCode(root);

            // Enumerate across the content a second time
            // This build a list of bit flags indicating the code words
            var bits = new List<bool>();
            foreach (var ch in content)
            {
                foreach (var c in codes[ch])
                {
                    if (c == '1')
                    {
                        bits.Add(true);
                    }
                    else
                    {
                        bits.Add(false);
                    }
                }
            }

            // Create a memory stream for holding the output
            // First write the frequency information so that it can be decoded in later
            // Then append the compressed code words.
            var compressed = new BitArray(bits.ToArray());
            using (var memoryStream = new MemoryStream())
            {
                using (var byteWriter = new BinaryWriter(memoryStream, Encoding.UTF8, true))
                {
                    foreach (var frequency in frequencies)
                    {
                        byteWriter.Write(frequency);
                    }

                    foreach (var word in ToByteArray(compressed))
                    {
                        byteWriter.Write(word);
                    }
                }

                return memoryStream.ToArray();
            }
        }

        /// <summary>
        /// Decompress the contents back into the original message.
        /// </summary>
        /// <param name="content">The result of <see cref="Compress(byte[])"/> operation.</param>
        /// <returns>The original contents.</returns>
        public static byte[] Decompress(byte[] content)
        {
            // Create a binary reader for traversing the structure..
            using (var reader = new BinaryReader(new MemoryStream(content)))
            {
                // Extract out the frequency information and rebuild the tree...
                var frequencies = new int[R];
                for (var ix = 0; ix < frequencies.Length; ix++)
                {
                    frequencies[ix] = reader.ReadInt32();
                }

                Node root = Node.BuildTrie(frequencies);

                // Next read the compressed code words in the payload
                var compressed = new List<byte>();
                while (reader.PeekChar() != -1)
                {
                    compressed.Add(reader.ReadByte());
                }

                // Translate the bytes into a continuous bit array so we don't need to worry about alignmnet
                // Hand all of this to decoder along with the tree to be traversed.
                return Decoder(new BitArray(compressed.ToArray()), root);
            }
        }

        /// <summary>
        /// Decodes the <paramref name="bitArray"/> code words based on the <paramref name="root"/> tree.
        /// </summary>
        /// <param name="bitArray">The code words to be decoded.</param>
        /// <param name="root">The tree used for forming the code words.</param>
        /// <returns>The decoded message.</returns>
        private static byte[] Decoder(BitArray bitArray, Node root)
        {
            var head = root;
            var decoded = new List<byte>();
            for (var ix = 0; ix < bitArray.Count; ix++)
            {
                var bit = bitArray.Get(ix);
                if (bit == true)
                {
                    head = head.Right;
                }
                else
                {
                    head = head.Left;
                }

                if (head.IsLeaf)
                {
                    decoded.Add(head.Value);
                    head = root;
                }
            }

            return decoded.ToArray();
        }

        /// <summary>
        /// Builds the code words from a given <paramref name="root"/>.
        /// </summary>
        /// <remarks>
        /// Code words are returned as sequences of 1s and 0s.
        ///
        /// These strings need to be translated into BitArray values.
        /// </remarks>
        /// <param name="root">The tree to be traversed.</param>
        /// <returns>Value[ix] = CodeWord Bit Sequence (eg "1011").</returns>
        private static string[] BuildCode(Node root)
        {
            string[] codes = new string[R];
            BuildCode(codes, root, string.Empty);

            return codes;
        }

        /// <summary>
        /// Builds the code words from a given <paramref name="node"/>.
        /// </summary>
        /// <param name="codes">The code words structure.</param>
        /// <param name="node">The current node in the tree.</param>
        /// <param name="code">The current prefix so far.</param>
        private static void BuildCode(string[] codes, Node node, string code)
        {
            if (node.IsLeaf)
            {
                codes[node.Value] = code;
            }

            BuildCode(codes, node.Left, code + '0');
            BuildCode(codes, node.Right, code + '1');
        }

        /// <summary>
        /// Utility to convert a bit array into byte[].
        /// </summary>
        /// <param name="bits">The bits to convert to byte[].</param>
        private static byte[] ToByteArray(BitArray bits)
        {
            int numBytes = bits.Count / 8;
            if (bits.Count % 8 != 0)
            {
                numBytes++;
            }

            byte[] bytes = new byte[numBytes];
            int byteIndex = 0, bitIndex = 0;

            for (int i = 0; i < bits.Count; i++)
            {
                if (bits[i])
                {
                    bytes[byteIndex] |= (byte)(1 << (7 - bitIndex));
                }

                bitIndex++;
                if (bitIndex == 8)
                {
                    bitIndex = 0;
                    byteIndex++;
                }
            }

            return bytes;
        }
    }
}
