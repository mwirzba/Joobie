using Joobie.Validators;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Joobie.Models.JobModels
{
    public class CVJobApplicationUser
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int JobId { get; set; }

        public string CvName { get; set; }

        [NotMapped]
        [CvValidation]
        [Required(ErrorMessage ="CV jest wymagane")]
        public IFormFile Cv { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public long JobsId { get; set; }
        public Job Job { get; set; }
    }
}
