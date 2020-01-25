using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Joobie.ViewModels
{
    public class SearchSettingViewModel
    {
       public string SarchString        {get; set; }
       public string CitySearchString    {get; set; }
       public int[] Categories           {get; set; }
       public int[] TypesOfContracts     {get; set; }
       public int[] WorkingHour { get; set; }
    }
}
