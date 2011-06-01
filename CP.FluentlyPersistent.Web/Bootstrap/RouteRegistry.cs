using System.Web.Mvc;
using System.Web.Routing;
using Elmah.Contrib.Mvc;

namespace CP.FluentlyPersistent.Web.Bootstrap
{
    public class RouteRegistry
    {
        public void Run()
        {
        }

        public void Reset()
        {
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new ElmahHandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*content}", new { content = @"(.*/)?content(/.*)?" });
            routes.IgnoreRoute("{*scripts}", new { scripts = @"(.*/)?scripts(/.*)?" });
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
                );

        }
    }
}