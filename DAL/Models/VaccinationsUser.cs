using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Dto
{
    public class VaccinationsUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int CreatorId  { get; set; }
        [Required]
        public DateTime VaccinationDate { get; set; }
        [Required]
        public VaccinationCounterEnum VaccinationCounter { get; set; }
        public User User { get; set; }
        public VaccinationsCreator Creator { get; set; }
    }
}
