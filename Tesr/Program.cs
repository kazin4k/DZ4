using System;

namespace Tesr
{
    internal class Program
    {
        public static int NOD(int a,int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(NOD(12333,41324));
            Console.ReadLine();
        }
    }
}
