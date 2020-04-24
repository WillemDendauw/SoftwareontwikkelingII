using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coderingen.Pattern
{
    /// <summary>
    /// Gedeelde interface voor zowel de component (BasisCodering) als de verschillende decorators
    /// </summary>
    public interface ICodering
    { 
        string Codeer(string zin);      
    }
}
