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
    [Table("Persons")]
    public class Person
    {
        [Required]
        public string City { get; set; }

        [ForeignKey("CountryID")]
        public Country Country { get; set; }

        [Required]
        public int CountryID { get; set; }

        [Required]
        public bool CourseResponsible { get; set; }

        [Required]
        public DateOnly DateOfBirth { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public bool GroupTourResponsible { get; set; }

        public string? medicalSheet { get; set; }

        [Required]
        public bool MemberHealthInsurance { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Number { get; set; }

        public ObservableCollection<Participant> Participants { get; set; }

        [Key]
        public int PersonID { get; set; }

        public string? Phone { get; set; }

        [Required]
        public bool Sex { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Zip { get; set; }
    }
}