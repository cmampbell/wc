using System;
using System.IO;
using System.CommandLine;

namespace wc;

class Program
{
    static async Task<int> Main(string[] args)
    {
        var functionArgument = new Argument<string>(
            name: "function",
            description: "arguement that determines output"
        );

        var fileArgument = new Argument<FileInfo>(
            name: "file",
            description: "the file to read"
        );

        var rootCommand = new RootCommand("Word Count"){
            functionArgument,
            fileArgument
        };
        rootCommand.SetHandler((byteArgumentValue, file) =>
            {
                if (byteArgumentValue == "-c")
                {
                    CountBytes(file);
                }
                else if (byteArgumentValue == "-l")
                {
                    CountLines(file);
                } else if(byteArgumentValue == "-w"){
                    CountWords(file);
                }
            },
            functionArgument, fileArgument);

        return await rootCommand.InvokeAsync(args);
    }

    static void CountBytes(FileInfo file)
    {
        Console.WriteLine($"{file.Length} {file}");
    }

    static void CountLines(FileInfo file)
    {
        int lineCount = File.ReadLines(file.FullName).ToList().Count;
        Console.WriteLine($"{lineCount} {file}");
    }

    static void CountWords(FileInfo file){
        // implement word count function
        int count = 0;
        bool inWord = false;
        string text = File.ReadAllText(file.FullName);//.Length
        int length = text.Length;
        //word is a standalone sequence of characters
        for(int i = 0; i < length; i++ ){
            char c = text[i];
            if(char.IsLetterOrDigit(c)){
                inWord = true;
            } else {
                inWord = false;
                count++;
            }
        }
        Console.WriteLine($"{count} {file}");
    }
}