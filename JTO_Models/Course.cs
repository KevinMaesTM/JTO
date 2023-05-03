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
    [Table("Courses")]
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Required]
        public string Name { get; set; }

        public ObservableCollection<Training>? Trainings { get; set; }
    }
}