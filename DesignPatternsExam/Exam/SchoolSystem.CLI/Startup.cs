using Ninject;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;

namespace SchoolSystem.Cli
{
    public class Startup
    {
        public static void Main()
        {
            var kernel = new StandardKernel(new SchoolSystemModule());

            //var reader = kernel.Get<IReader>();
            //var writer = new ConsoleWriterProvider();
            //var parser = new CommandParserProvider();

            //var engine = new Engine(reader, writer, parser);
            //engine.Start();

            IEngine engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}