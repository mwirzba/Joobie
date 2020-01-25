using Joobie.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Joobie.Infrastructure
{
    public class SearchStringSession
    {
        [Newtonsoft.Json.JsonIgnore] public ISession Session { get; set; }
        public SearchSettingViewModel date = new SearchSettingViewModel
        {
            SarchString = "",
            CitySearchString = "",
            Categories = new int[] { },
            TypesOfContracts = new int[] { },
            WorkingHour = new int[] { }
        };
        public static SearchStringSession GetDateSession(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SearchStringSession dataSession = session?.GetJson<SearchStringSession>("Data") ?? new SearchStringSession();

            dataSession.Session = session;

            return dataSession;
        }

        public void SetDate(SearchSettingViewModel Newdate)
        {
            date = Newdate;
            Session.SetJson("Data", this);
        }

    }
}
