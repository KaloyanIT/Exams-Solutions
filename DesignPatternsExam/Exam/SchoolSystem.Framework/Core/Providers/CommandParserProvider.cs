using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SchoolSystem.Framework.Core.Commands;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework;

namespace SchoolSystem.Framework.Core.Providers
{
    public class CommandParserProvider : IParser
    {
        private readonly IModelFactory modelFactory;
        private readonly ICommandFactory commandFactory;
        private readonly ICommand command;

        public CommandParserProvider(IModelFactory modelFactory, ICommandFactory commandFactory, ICommand command)
        {
            this.modelFactory = modelFactory;
            this.commandFactory = commandFactory;
            this.command = command;
        }

        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split(' ')[0];
            var commandTypeInfo = this.FindCommand(commandName);
            //var command = Activator.CreateInstance(commandTypeInfo) as ICommand;
            //var commnad = new CreateStudentCommand(IModelFactory modelFactory) as ICommand;
            this.commandFactory.CreateStudentCommand(this.modelFactory);

            var command = Activator.CreateInstance<ICommand>();

            return command;
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split(' ').ToList();
            commandParts.RemoveAt(0);

            if (commandParts.Count() == 0)
            {
                return null;
            }

            return commandParts;
        }

        private TypeInfo FindCommand(string commandName)
        {
            var currentAssembly = this.GetType().GetTypeInfo().Assembly;
            var commandTypeInfo = currentAssembly.DefinedTypes
                .Where(type => type.ImplementedInterfaces.Any(inter => inter == typeof(ICommand)))
                .Where(type => type.Name.ToLower().Contains(commandName.ToLower()))
                .SingleOrDefault();

            if (commandTypeInfo == null)
            {
                throw new ArgumentException("The passed command is not found!");
            }

            return commandTypeInfo;
        }
    }
}
