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
    [Table("AgeCategories")]
    public partial class AgeCategory
    {
        [Key]
        public int AgeCategoryID { get; set; }

        public ObservableCollection<GroupTour>? GroupTours { get; set; }

        public bool? IsActive { get; set; } = true;
        public int? MaxAge { get; set; }

        public int? MinAge { get; set; }
    }
}