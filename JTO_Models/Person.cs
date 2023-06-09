﻿using JTO_Models;
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
    public partial class Person
    {
        [Required]
        public string City { get; set; }

        public string Country { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public bool GroupTourResponsible { get; set; }

        [Required]
        public bool IsMoni { get; set; } = false;

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

        public ObservableCollection<Trainee> Trainees { get; set; }

        [Required]
        public string Zip { get; set; }
    }
}