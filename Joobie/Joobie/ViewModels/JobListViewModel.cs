using Joobie.Models.JobModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joobie.ViewModels
{
    public class JobListViewModel
    {
        public Job MyProperty { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
