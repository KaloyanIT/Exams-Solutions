using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolSystem.Framework
{
    public interface ICommandFactory
    {
        ICommand CreateStudentCommand(IModelFactory modelFactory);
    }
}
