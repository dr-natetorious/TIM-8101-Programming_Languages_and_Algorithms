using System;
using System.Text;

namespace Fat32Algo
{
    class Program
    {
        static void Main()
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

        static string RandomString(int length)
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
