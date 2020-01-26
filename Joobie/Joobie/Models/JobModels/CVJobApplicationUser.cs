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
        public string CvName { get; set; }

        [NotMapped]
        [CvValidation]
        [Required(ErrorMessage ="CV jest wymagane")]
        public IFormFile Cv { get; set; }

        public long JobInMiddleTableId { get; set; }
        public Job JobInMiddleTable { get; set; }


        public string EmployeeUserId { get; set; }
        public ApplicationUser EmployeeUser { get; set; }
    }
}
