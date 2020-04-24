using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EersteProject
{
    public abstract class Persoon
    {
        string name;

        public Persoon(string name)
        {
            this.name = name;
        }

        public string Name
        {
            get { return name; }
        }

        public virtual string WelcomeMessage
        {
            get { return "Hello " + name; }
        }

        public abstract string DoSomething();
    }
}
