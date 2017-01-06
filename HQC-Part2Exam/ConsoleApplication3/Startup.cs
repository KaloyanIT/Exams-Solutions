using ConsoleApplication3.Core;
using ConsoleApplication3.Core.Providers;

namespace ConsoleApplication3
{
    public class Startup
    {
        public static void Main()
        {
            // TODO: abstract at leest 2 mor provider like thiso ne
            var readLine = new ConsoleReaderProvider();
            var writeLine = new ConsoleWriterProvider();
            var engineProvider = new CreateEngineProvider();
            engineProvider.Execute(readLine, writeLine);
        }
    }
}
