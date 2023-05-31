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
    [Table("Destinations")]
    public partial class Destination
    {
        [Required]
        public string City { get; set; }

        public string Country { get; set; }

        [Key]
        public int DestinationID { get; set; }

        public ObservableCollection<GroupTour>? GroupTours { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Zip { get; set; }
    }
}