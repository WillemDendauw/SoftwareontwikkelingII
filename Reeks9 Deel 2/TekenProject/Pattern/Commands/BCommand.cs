using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TekenProject.Pattern.Commands
{
    public class BCommand : ADoubleKeyCommand
    {
        public BCommand(Helper helper) : base(helper)
        {
        }

        public override void Execute(Key secondkey)
        {
            helper.FillNr = secondkey - Key.D0; //nummer ingegeven
           
        }
    }
}
