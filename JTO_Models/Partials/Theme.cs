using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

        public override bool Equals(object obj)
        {
            return Equals(obj as Theme);
        }

        public bool Equals(Theme other)
        {
            if (other == null)
                return false;

            return Name == other.Name;
        }
    }
}
