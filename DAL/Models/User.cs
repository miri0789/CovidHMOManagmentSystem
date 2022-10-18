﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dto
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Identity { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int BuildingNumber { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string MobileNumber { get; set; }
        public DateTime RecoveryDate { get; set; }
        public DateTime PositiveResultDate { get; set; }
        public string ImagePath { get; set; }
        public IEnumerable<VaccinationsUser> VaccinationsUsers { get; set; }
    }
}
