using ConsoleApplication3.Enums;
using ConsoleApplication3.Models.Human;

namespace ConsoleApplication3
{
    public class Teacher : Human
    {
        public Teacher(string firstName, string lastName, Subject subject)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Subject = subject;
        }

        public Subject Subject { get; set; }

        public void AddMark(Student teacher, float markValue)
        {
            var mark = new Mark(this.Subject, markValue);
            teacher.MarksList.Add(mark);
        }
    }
}
