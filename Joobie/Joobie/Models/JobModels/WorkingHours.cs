using System.ComponentModel.DataAnnotations;

namespace Joobie.Models.JobModels
{
    public class WorkingHours
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        [Display(Name = "Godziny")]
        public string Name { get; set; }
    }
}