using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TekenProject.Pattern.Commands
{
    public abstract class ADoubleKeyCommand : NoCommand
    {
        public ADoubleKeyCommand(Helper helper) : base(helper)
        {}

        public override int NumberKeys => 2;    
    }
}
