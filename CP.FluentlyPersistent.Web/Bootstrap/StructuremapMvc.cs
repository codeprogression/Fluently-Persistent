using System.Web.Mvc;
using CP.FluentlyPersistent.Web.Bootstrap;

[assembly: WebActivator.PreApplicationStartMethod(typeof(StructuremapMvc), "Start")]

namespace CP.FluentlyPersistent.Web.Bootstrap {
    public static class StructuremapMvc {
        public static void Start() {
            var container = Infrastructure.Container.Initialize();
            DependencyResolver.SetResolver(new SmDependencyResolver(container));
        }
    }
}