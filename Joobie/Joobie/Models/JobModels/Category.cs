using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Joobie.Models.JobModels
{
    public class Category
    {
        [Key]
        public byte Id { get; set; }

        [Required]
        [Display(Name = "Kategoria")]
        public string Name { get; set; }

    }
}
