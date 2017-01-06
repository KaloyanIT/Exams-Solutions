using System;
using ConsoleApplication3.Models;

namespace ConsoleApplication3.Core.Providers
{
    public class ConsoleWriterProvider : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}