using System.Collections.Generic;
using ConsoleApplication3.Models;

namespace ConsoleApplication3.Core.Commands
{
    public class RemoveStudentCommand : ICommand
    {
        public string Execute(IList<string> paras)
        {
            Engine.Students.Remove(int.Parse(paras[0]));
            return $"Student with ID {int.Parse(paras[0])} was sucessfully removed.";
        }
    }
}