﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_MODELS
{
    public partial class AgeCategory
    {
        public override string ToString()
        {
            return $"({MinAge} - {MaxAge})";
        }
    }
}
