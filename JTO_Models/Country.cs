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
    [Table("Countries")]
    public class Country
    {
        [Key]
        public int CountryID { get; set; }

        public ObservableCollection<Destination>? Destinations { get; set; }

        [Required]
        public string Name { get; set; }

        public ObservableCollection<Person>? Persons { get; set; }
    }
}