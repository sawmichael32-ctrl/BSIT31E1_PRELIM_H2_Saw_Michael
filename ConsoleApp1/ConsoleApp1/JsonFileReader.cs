using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using ConsoleApp1;

public class JsonFileReader : BaseFileReader
{
    public override string SupportedFormat => "JSON";

    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening JSON stream...");

        string json = File.ReadAllText(filePath);

        using JsonDocument doc = JsonDocument.Parse(json);

        int count = 0;

        if (doc.RootElement.ValueKind == JsonValueKind.Object)
            count = doc.RootElement.EnumerateObject().Count();
        else if (doc.RootElement.ValueKind == JsonValueKind.Array)
            count = doc.RootElement.GetArrayLength();

        Console.WriteLine($" -> Parsed {count} root properties.");

        Console.WriteLine("\n--- First 100 Characters ---");

        Console.WriteLine(json.Length > 100
            ? json.Substring(0, 100)
            : json);

        Console.WriteLine("\n----------------------------");
    }
}