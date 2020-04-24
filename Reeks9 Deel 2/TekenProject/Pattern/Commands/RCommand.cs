using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TekenProject.Pattern.Commands
{
    public class RCommand : NoCommand
    {
        public RCommand(Helper helper) : base(helper)
        {
        }

        public override void Execute(Key key)
        {
            helper.ClearCanvas();       
        }

        public override int NumberKeys => 1; //direct uitvoeren

    }
}
