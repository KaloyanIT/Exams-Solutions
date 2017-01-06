using System.Collections.Generic;

namespace ConsoleApplication3.Models
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
