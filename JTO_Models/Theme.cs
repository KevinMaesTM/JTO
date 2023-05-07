using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    [Table("Themes")]
    public partial class Theme
    {
        public ObservableCollection<GroupTour> GroupTours { get; set; }

        [Required]
        public string Name { get; set; }

        [Key]
        public int ThemeID { get; set; }
    }
}