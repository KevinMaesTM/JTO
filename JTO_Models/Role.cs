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
    [Table("Roles")]
    public partial class Role
    {
        [Required]
        public string AssignedObject { get; set; }

        public bool? IsActive { get; set; } = true;

        [Required]
        public string Name { get; set; }

        public ObservableCollection<Participant>? Participants { get; set; }

        [Key]
        public int RoleID { get; set; }

        public ObservableCollection<Trainee> Trainees { get; set; }
    }
}