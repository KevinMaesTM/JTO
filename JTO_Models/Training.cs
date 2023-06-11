using JTO_Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTO_MODELS
{
    [Table("Trainings")]
    public partial class Training
    {
        [Required]
        public DateTime? Date { get; set; }

        public bool? IsActive { get; set; } = true;

        [Required]
        public string? Name { get; set; }

        public ObservableCollection<Trainee> Trainees { get; set; }

        [Key]
        public int TrainingID { get; set; }
    }
}