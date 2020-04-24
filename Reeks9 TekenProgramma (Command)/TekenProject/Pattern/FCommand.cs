using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TekenProject.Pattern
{
    public class FCommand : ADoubleKeyCommand
    {
        public FCommand(Helper helper) : base(helper)
        {

        }

        public override void Execute(Key secondKey)
        {
            helper.StrokeNr = secondKey - Key.D0;
        }
    }
}
