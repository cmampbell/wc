using System;
using System.IO;

namespace wc;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        //File.Open(".\test.txt");

        if (args.Length > 0)
        {
            foreach (var arg in args)
            {
                Console.WriteLine($"Argument={arg}");
            }
        }
        else
        {
            Console.WriteLine("No arguments");
        }
    }
}

