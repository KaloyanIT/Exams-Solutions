using System.Collections.Generic;
using ConsoleApplication3.Models;

namespace ConsoleApplication3.Core.Commands
{
    public class TeacherAddMarkCommand : ICommand
    {
        public string Execute(IList<string> prms)
        {
            var teacherId = int.Parse(prms[0]);
            var studentId = int.Parse(prms[1]);
            var student = Engine.Students[teacherId];
            var teacher = Engine.Teachers[studentId];
            teacher.AddMark(student, float.Parse(prms[2]));
            return $"Teacher {teacher.FirstName} {teacher.LastName} added mark {float.Parse(prms[2])} to student {student.FirstName} {student.LastName} in {teacher.Subject}.";
        }
    }
}