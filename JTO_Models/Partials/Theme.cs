using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_MODELS
{
    public partial class Theme
    {
        public override string ToString()
        {
            return Name;
        }

        public Theme() { }
        public Theme(string name) { 
            Name = name;
        }
    }
}
