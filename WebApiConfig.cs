using System.Web.Http;
using exmainationApi.Filters;

namespace exmainationApi {
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Filters.Add(new ValidateModelAttribute());
        }
    }
}