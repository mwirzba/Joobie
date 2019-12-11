
using Joobie.Models.JobModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joobie.Models.JobModels
{
    public class Job
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Localization { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public byte CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public byte TypeOfContractId { get; set; }
        public virtual TypeOfContract TypeOfContract { get; set; }
        public byte WorkingHoursId { get; set; }
        public virtual WorkingHours WorkingHours { get; set; }
        public int SalaryId { get; set; }
        public virtual Salary Salary { get; set; }
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
