using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Joobie.Models.JobModels
{
    public class WorkingHours
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }

        [Required]
        [Display(Name = "Godziny")]
        public string Name { get; set; }
    }
}