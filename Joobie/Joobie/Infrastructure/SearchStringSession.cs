using Joobie.Data;
using Joobie.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Joobie.Infrastructure
{
    public class SearchStringSession
    {

        [Newtonsoft.Json.JsonIgnore] public ISession Session { get; set; }
        public SearchSettingViewModel searchSetting;
        public static SearchStringSession GetSession(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            SearchStringSession searchStringSession = session?.GetJson<SearchStringSession>("Search") ?? new SearchStringSession();

            searchStringSession.Session = session;

            return searchStringSession;
        }

        public void SetSearch(SearchSettingViewModel newSearch)
        {
            searchSetting = newSearch;
            Session.SetJson("Search", this);
        }

    }
}
