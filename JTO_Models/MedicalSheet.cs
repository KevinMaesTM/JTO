using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_MODELS
{
    [Table("MedicalSheets")]
    public class MedicalSheet
    {
        [Required]
        public string Description { get; set; }

        [Key]
        public int MedicalSheetID { get; set; }

        [ForeignKey("PersonID")]
        public Person Person { get; set; }

        [Required]
        public int PersonID { get; set; }
    }
}