using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication3.Enums;
using ConsoleApplication3.Models.Human;

namespace ConsoleApplication3
{
    public class Student : Human
    {
        private Grade grade;
        private List<Mark> marksList;

        public Student(string firstName, string lastName, Grade grade)
        {
            if (firstName == null)
            {
                throw new ArgumentNullException();
            }

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Grade = grade;
            this.marksList = new List<Mark>();
        }

        public Grade Grade
        {
            get { return this.grade; }
            set { this.grade = value; }
        }

        public List<Mark> MarksList
        {
            get
            {
                return this.marksList;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException($"Mark is null");
                }

                this.marksList = value;
            }
        }

        public string ListMarks()
        {
            var marks = this.marksList.Select(mark => $"{mark.Subject} => {mark.MarkValue}").ToList();
            return string.Join("\n", marks);
        }
    }
}
