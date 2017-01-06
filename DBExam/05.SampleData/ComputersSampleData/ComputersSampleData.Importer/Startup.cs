using System;

namespace ComputersSampleData.Importer
{
    public class Startup
    {
        static void Main(string[] args)
        {
            SampleDataImporter.Create(Console.Out).Import();
        }
    }
}
