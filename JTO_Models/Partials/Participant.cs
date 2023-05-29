using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_MODELS
{
    public partial class Participant
    {
        public Participant(int grouptourId, int personId, int roleId) 
        { 
            GroupTourID = grouptourId;
            PersonID = personId;
            RoleID = roleId;
        }

        public Participant() { }
    }
}
