// <copyright file="Program.cs" company="Nate Bachmeier">
// Copyright (c) Nate Bachmeier. All rights reserved.
// </copyright>

namespace Fat32Algo
{
    using System;
    using System.Text;

    /// <summary>
    /// Represents a simple test utility for the algorithms.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point for console.
        /// </summary>
        public static void Main()
        {
            var fatTable = new FatTable(
                maxBlocks: 1024,
                pageSize: 10);

            var expected = RandomString(fatTable.PageSize * 5);
            fatTable.WriteFile("taco.txt", expected);

            var actual = fatTable.ReadTextFile("taco.txt");
            if (expected != actual)
            {
                Console.WriteLine("Sad.");
            }

            Console.WriteLine("works.");
        }

        private static string RandomString(int length)
        {
            var sb = new StringBuilder(length);
            for (var ix = 0; ix < length; ix++)
            {
                sb.Append((char)((int)'A' + (ix % 26)));
            }

            return sb.ToString();
        }
    }
}
