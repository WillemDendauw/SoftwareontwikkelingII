using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TekenProject.Pattern
{
    public class BCommand : ADoubleKeyCommand
    {
        public BCommand(Helper helper) : base(helper)
        {

        }

        public override void Execute(Key secondKey)
        {
            helper.FillNr = secondKey - Key.D0;
        }
    }
}
