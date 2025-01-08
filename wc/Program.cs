using System;
using System.IO;
using System.CommandLine;

namespace wc;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var fileOption = new Option<FileInfo?>(
            name: "-c",
            description: "Read the byte count of the file.");

        var rootCommand = new RootCommand("Sample app for System.CommandLine");
        rootCommand.AddOption(fileOption);

        rootCommand.SetHandler((file) => 
            { 
                ReadFile(file!); 
            },
            fileOption);

        return await rootCommand.InvokeAsync(args);
    }

    static void ReadFile(FileInfo file)
    {
        // File.ReadLines(file.FullName).ToList()
        //     .ForEach(line => Console.WriteLine(line));
        Console.WriteLine($"{file.Length} {file}");
    }
}