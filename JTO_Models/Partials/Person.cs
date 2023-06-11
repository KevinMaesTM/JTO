using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace JTO_MODELS
{
    public partial class Person
    {
        public Person() { }
        public override string ToString()
        {
            return $"{Name} {Surname}";
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Person);
        }

        public bool Equals(Person other)
        {
            if (other == null)
                return false;

            return City == other.City && Country == other.Country && Number == other.Number && Street == other.Street && Zip == other.Zip && DateOfBirth == other.DateOfBirth && Name == other.Name && Surname == other.Surname; 
        }
    }
}
