using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Array
{
    class Program
    {
        static void DiaplayArray(string arr)
        {
            Console.Write("Forward String: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i]);
            }
            Console.WriteLine();
            Console.Write("Backward String: ");
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                Console.Write(arr[i]);
            }
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            string str;
            Console.WriteLine("Enter the String");
            str = Console.ReadLine();
            DiaplayArray(str);
        }
    }
}