using System.CodeDom;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Modules;
using SchoolSystem.Cli.Configuration;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using Ninject.Extensions.Factory;
using SchoolSystem.Framework;
using SchoolSystem.Framework.Core;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Providers;
using SchoolSystem.Framework.Models.Contracts;
using ICommand = SchoolSystem.Framework.Core.Commands.Contracts.ICommand;

namespace SchoolSystem.Cli
{
    public class SchoolSystemModule : NinjectModule
    {
        private const string ConsoleReaderProvider = "ConsoleReaderProvider";
        private const string ConsoleWriterProvider = "ConsoleWriterProvider";
        private const string CommandParserProvider = "CommandParserProvider";
        private const string CreateStudentCommand = "CreateStudentCommand";
        private const string CreateTeacherCommand = "CreateTeacherCommand";
        private const string RemoveStudentCommand = "RemoveStudentCommand";
        private const string RemoveTeacherCommand = "RemoveTeacherCommand";
        private const string StudentListMarksCommand = "StudentListMarksCommand";
        private const string TeacherAddMarkCommand = "TeacherAddMarkCommand";





        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .BindDefaultInterface();
            });

            //Factories
            Bind<IModelFactory>().ToFactory().InSingletonScope();
            Bind<ICommandFactory>().ToFactory().InSingletonScope();

            Bind<IReader>().To<ConsoleReaderProvider>().Named(ConsoleReaderProvider);
            Bind<IWriter>().To<ConsoleWriterProvider>().Named(ConsoleWriterProvider);
            Bind<IParser>().To<CommandParserProvider>().Named(CommandParserProvider);

            Bind<ICommand>().To<CreateStudentCommand>().Named(CreateStudentCommand);
            //Bind<ICommand>()
            

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();
            if (configurationProvider.IsTestEnvironment)
            {
            }
        }
    }
}