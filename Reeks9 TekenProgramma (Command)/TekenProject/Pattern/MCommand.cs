using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TekenProject.Pattern
{
    public class MCommand : ADoubleKeyCommand
    {
        public MCommand(Helper helper) : base(helper)
        {

        }

        public override void Execute(Key secondkey)
        {
            //word later gedaan
        }
    }
}
