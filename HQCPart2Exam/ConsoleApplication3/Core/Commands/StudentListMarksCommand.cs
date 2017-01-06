using System.Collections.Generic;
using ConsoleApplication3.Models;

namespace ConsoleApplication3.Core.Commands
{
    public class StudentListMarksCommand : ICommand
    {
        public string Execute(IList<string> parameters)
        {
            return Engine.Students[int.Parse(parameters[0])].ListMarks();
        }
    }
}