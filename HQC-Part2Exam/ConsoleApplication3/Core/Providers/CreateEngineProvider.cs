namespace ConsoleApplication3.Core.Providers
{
    public class CreateEngineProvider
    {
        public void Execute(ConsoleReaderProvider readerProvider, ConsoleWriterProvider writerProvider)
        {
            var engine = new Engine(readerProvider, writerProvider);
            engine.StartEngine();
        }
    }
}
