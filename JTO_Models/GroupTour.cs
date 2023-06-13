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
    [Table("GroupTours")]
    public partial class GroupTour
    {
        [ForeignKey("AgeCategoryID")]
        public AgeCategory? AgeCategory { get; set; }

        public int? AgeCategoryID { get; set; }

        [ForeignKey("DestinationID")]
        public Destination? Destination { get; set; }

        public int? DestinationID { get; set; }

        [Required]
        public DateTime Enddate { get; set; }

        [Key]
        public int GroupTourID { get; set; }

        [Required]
        public int MaxParticipants { get; set; }

        [Required]
        public string Name { get; set; }

        public ObservableCollection<Participant>? Participants { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("ResponsibleID")]
        public Person? Responsible { get; set; }

        public int? ResponsibleID { get; set; }

        [Required]
        public DateTime Startdate { get; set; }

        [ForeignKey("ThemeID")]
        public Theme? Theme { get; set; }

        public int? ThemeID { get; set; }
    }
}