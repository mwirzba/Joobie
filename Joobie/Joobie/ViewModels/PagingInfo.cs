using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joobie.ViewModels
{
    public class PagingInfo
    {
        public byte TotalItems { get; set; }
        public byte ItemsPerPage { get; set; }
        public byte CurrentPage { get; set; }
        public byte TotalPages => (byte)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
