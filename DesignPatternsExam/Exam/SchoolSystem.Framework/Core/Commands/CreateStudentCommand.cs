using System.Collections.Generic;
using SchoolSystem.Framework.Core.Commands.Contracts;
using SchoolSystem.Framework.Models;
using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework.Core.Commands
{
    public class CreateStudentCommand : ICommand
    {
        private static int currentStudentId = 0;
        private readonly IModelFactory modelFactory;
        //private readonly IStudent student;

        public CreateStudentCommand(IModelFactory modelFactory)
        {
            this.modelFactory = modelFactory;
        }

        //public IStudent Student { get; set; }

        public string Execute(IList<string> parameters)
        {
            var firstName = parameters[0];
            var lastName = parameters[1];
            var grade = (Grade)int.Parse(parameters[2]);

            //var student = new Student(firstName, lastName, grade);
            var student = this.modelFactory.CreateStudent(firstName, lastName, grade);
            Engine.Students.Add(currentStudentId, student);

            return $"A new student with name {firstName} {lastName}, grade {grade} and ID {currentStudentId++} was created.";
        }
    }
}
