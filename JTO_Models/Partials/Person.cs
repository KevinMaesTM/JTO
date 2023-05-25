using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_MODELS
{
    public partial class Person
    {
        public override string ToString()
        {
            return $"{Name} {Surname}";
        }
    }
}
