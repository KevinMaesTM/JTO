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

        public override bool Equals(object obj)
        {
            return Equals(obj as Destination);
        }

        public bool Equals(Destination other)
        {
            if (other == null)
                return false;

            return City == other.City && Country == other.Country && Name == other.Name && Number == other.Number && Street == other.Street && Zip == other.Zip;
        }
    }
}