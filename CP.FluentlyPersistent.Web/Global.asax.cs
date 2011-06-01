using System.Web.Mvc;
using System.Web.Routing;
using CP.FluentlyPersistent.Web.Bootstrap;

namespace CP.FluentlyPersistent.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteRegistry.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteRegistry.RegisterRoutes(RouteTable.Routes);

            var container = Container.Initialize();
            DependencyResolver.SetResolver(new SmDependencyResolver(container));
        }
    }
}