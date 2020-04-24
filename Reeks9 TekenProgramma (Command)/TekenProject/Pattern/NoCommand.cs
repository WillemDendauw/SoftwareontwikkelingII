using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TekenProject.Pattern
{
    public class NoCommand : ICommand
    {
        protected Helper helper;

		public NoCommand(Helper helper)
        {
            this.helper = helper;
        }

		public virtual void Execute(Key key)
        {

        }

        public virtual int NumberKeys => 0;
    }
}
