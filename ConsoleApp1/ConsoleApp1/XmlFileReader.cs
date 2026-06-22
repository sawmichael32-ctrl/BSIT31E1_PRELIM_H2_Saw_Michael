using System;
using System.Linq;
using System.Xml.Linq;
using ConsoleApp1;

public class XmlFileReader : BaseFileReader
{
    public override string SupportedFormat => "XML";

    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening XML stream...");

        XDocument doc = XDocument.Load(filePath);

        string rootName = doc.Root.Name.LocalName;
        int descendants = doc.Descendants().Count();

        Console.WriteLine($" -> Root element: <{rootName}> with {descendants} descendant nodes.");

        string xmlText = doc.ToString();

        Console.WriteLine("\n--- First 100 Characters ---");

        Console.WriteLine(xmlText.Length > 100
            ? xmlText.Substring(0, 100)
            : xmlText);

        Console.WriteLine("\n----------------------------");
    }
}