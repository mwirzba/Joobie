namespace Joobie.ViewModels
{
    public class SearchSettingViewModel
    {
        public string SearchString { get; set; } = "";
        public string CitySearchString { get; set; } = "";
        public Filter[] Categories { get; set; }
        public Filter[] TypesOfContracts { get; set; }
        public Filter[] WorkingHour { get; set; }

        public SearchSettingViewModel()
        {
            SearchString = "";
            CitySearchString = "";
            Categories = new Filter[] { };
            TypesOfContracts = new Filter[] { };
            WorkingHour = new Filter[] { };
        }
    }
}
