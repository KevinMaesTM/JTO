using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_MODELS
{
    public partial class Destination
    {
        public override string ToString()
        {
            return $"{Name} - {City} ({Country})";
        }
    }
}