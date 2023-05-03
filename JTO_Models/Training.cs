using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_MODELS
{
    [Table("Trainings")]
    public class Training
    {
        [ForeignKey("CourseID")]
        public Course Course { get; set; }

        [Required]
        public int CourseID { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("PersonID")]
        public Person Person { get; set; }

        [Required]
        public int PersonID { get; set; }

        [ForeignKey("RoleID")]
        public Role Role { get; set; }

        [Required]
        public int RoleID { get; set; }

        [Key]
        public int TrainingID { get; set; }
    }
}