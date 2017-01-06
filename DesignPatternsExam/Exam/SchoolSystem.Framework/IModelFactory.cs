using SchoolSystem.Framework.Models.Contracts;
using SchoolSystem.Framework.Models.Enums;

namespace SchoolSystem.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IModelFactory
    {
        IStudent CreateStudent(string firstName, string lastName, Grade grade);

        ITeacher CreateTeacher(string firstName, string lastName, Subject subject);

        IMark CreateMark(Subject subject, float value);
    }
}
