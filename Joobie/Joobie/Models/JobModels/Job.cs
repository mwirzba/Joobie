
using Joobie.Models.JobModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Joobie.Models.JobModels
{
    public class Job
    {
        [Key]
        public long Id { get; set; }


        [Display(Name = "Nazwa")]
        public string Name { get; set; }


        [Display(Name = "Opis")]
        public string Description { get; set; }


        [Display(Name = "Lokalizacja")]
        public string Localization { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data dodania")]
        public DateTime? AddedDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Termin wygaśnięcia")]
        public DateTime? ExpirationDate { get; set; }


        [Display(Name = "Wynagrodzenie")]
        public string Salary { get; set; }

        [Required]
        [Display(Name = "Kategoria")]
        public byte CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [Display(Name = "Kategoria")]
        public virtual Category Category { get; set; }

        [Required]
        [Display(Name = "Rodzaj kontraktu")]
        public byte TypeOfContractId { get; set; }

        [ForeignKey("TypeOfContractId")]
        [Display(Name = "Rodzaj kontraktu")]
        public virtual TypeOfContract TypeOfContract { get; set; }

        [Required]
        [Display(Name = "Godziny pracy")]
        public byte WorkingHoursId { get; set; }

        [ForeignKey("WorkingHoursId")]
        [Display(Name = "Godziny pracy")]
        public virtual WorkingHours WorkingHours { get; set; }


        [Display(Name = "Użytkownik")]
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        [Display(Name = "Użytkownik")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
