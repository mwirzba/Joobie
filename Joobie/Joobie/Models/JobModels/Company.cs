using System.ComponentModel.DataAnnotations;

namespace Joobie.Models.JobModels
{
    public class Company
    {
        [Key]
        public long Id { get; set; }

        [Required]
        [Display(Name = "Nazwa firmy")]
        public string Name { get; set; }
    }
}