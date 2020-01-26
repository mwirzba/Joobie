using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Joobie.Models.JobModels
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Nazwa Firmy")]
        public string Name { get; set; }
        [Required]
        [Display(Name="Nip")]
        public string Nip { get; set; }
        public string CompanyImagePath { get; set; }
        public ICollection<CVJobApplicationUser> CVJobApplicationUser { get; } = new List<CVJobApplicationUser>();
    }
}
