using System.ComponentModel.DataAnnotations;

namespace Joobie.Models.JobModels
{
    public class TypeOfContract
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        [Display(Name = "Typ Kontraktu")]
        public string Name { get; set; }
    }
}