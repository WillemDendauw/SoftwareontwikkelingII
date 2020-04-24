using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProxyModel.Pattern
{
    public class FileAccesException : Exception
    {
        public FileAccesException(string message) : base(message)
        {

        }
    }
}
