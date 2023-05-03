using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_MODELS
{
    [Table("Participants")]
    public class Participant
    {
        [ForeignKey("GroupTourID")]
        public GroupTour GroupTour { get; set; }

        [Required]
        public int GroupTourID { get; set; }

        [Key]
        public int ParticipantID { get; set; }

        [ForeignKey("PersonID")]
        public Person Person { get; set; }

        [Required]
        public int PersonID { get; set; }

        [ForeignKey("RoleID")]
        public Role Role { get; set; }

        [Required]
        public int RoleID { get; set; }
    }
}