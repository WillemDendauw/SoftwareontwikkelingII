using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TekenProject.Pattern.Commands
{
    public interface ICommand
    {
        void Execute(Key key);
        int NumberKeys { get; }      
    }
}
