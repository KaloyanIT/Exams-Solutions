using System;
using ConsoleApplication3.Models;

namespace ConsoleApplication3.Core.Providers
{
    public class ConsoleReaderProvider : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}