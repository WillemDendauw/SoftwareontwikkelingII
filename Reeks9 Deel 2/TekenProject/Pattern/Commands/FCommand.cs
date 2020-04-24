using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace TekenProject.Pattern.Commands
{
    public class FCommand : ADoubleKeyCommand
    {
        
        public FCommand(Helper helper) : base(helper)
        {
        }

        public override void Execute(Key secondkey)
        {
            helper.StrokeNr = secondkey - Key.D0; //nummer ingegeven
        }
    }
}
