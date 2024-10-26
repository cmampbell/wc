using System;
using System.IO;

namespace wc;

class Program
{
    static void Main(string[] args)
    {
        //File.Open(".\test.txt");
        //need to get argument from command line
        // need to recognize -c as count the bytes
        // need to open the file
        // need to count the bytes in a fule
        // need to return the byte count to the console
        if (args.Length > 0)
        {
            if(args[0] == "-c"){
                Console.WriteLine("In -c");
            }
        }
        else
        {
            Console.WriteLine("No arguments");
        }
    }
}

