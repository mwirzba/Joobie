using Joobie.Infrastructure;
using System.Collections.Generic;

namespace Joobie.ViewModels
{
    public class ListViewModel<T>
    {
        public IEnumerable<T> Items { get; set; }
        public PagingInfo PagingInfo { get; set; }

      //  public SearchStringSession searchStringSession { get; set; }
    }
}
