using System;
using System.IO;
using ConsoleApp1;

public class CsvFileReader : BaseFileReader
{
    public override string SupportedFormat => "CSV";

    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening CSV stream...");

        string[] lines = File.ReadAllLines(filePath);

        int rows = lines.Length;
        int columns = lines.Length > 0 ? lines[0].Split(',').Length : 0;

        Console.WriteLine($" -> Detected {rows} rows and {columns} columns.");

        string content = File.ReadAllText(filePath);

        Console.WriteLine("\n--- First 100 Characters ---");

        Console.WriteLine(content.Length > 100
            ? content.Substring(0, 100)
            : content);

        Console.WriteLine("\n----------------------------");
    }
}