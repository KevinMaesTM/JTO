using JTO_MODELS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_Models
{
    [Table("Trainees")]
    public class Trainee
    {
        [Required]
        public bool FinishedTraining { get; set; }

        public Person Person { get; set; }

        [ForeignKey("PersonID")]
        public int PersonID { get; set; }

        public Role Role { get; set; }

        [ForeignKey("RoleID")]
        public int RoleID { get; set; }

        [Key]
        public int TraineeID { get; set; }

        public Training Training { get; set; }
    }
}