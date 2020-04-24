using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EersteProject
{
    public class Student : Persoon
    {
        int studentennummer;
        public Student(string name, int nr) : base(name)
        {
            this.studentennummer = nr;
        }

        public override string WelcomeMessage
        {
            get { return base.WelcomeMessage + ", your studentnumber is " + studentennummer; }
        }

        public override string DoSomething()
        {
            return "This is the return in Student from DoSomething()";
        }
    }
}
