using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_MODELS
{
    public partial class AgeCategory
    {
        public AgeCategory() { }    
        public AgeCategory(int minAge, int maxAge) 
        {
            MinAge = minAge;
            MaxAge = maxAge;
        }
        public override string ToString()
        {
            return $"({MinAge} - {MaxAge})";
        }
    }
}
