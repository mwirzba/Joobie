using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joobie.Models.JobModels
{
    public class TypeOfContract
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required]
        [Display(Name = "Typ Kontraktu")]
        public string Name { get; set; }
    }
}