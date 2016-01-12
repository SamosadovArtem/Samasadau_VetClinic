using System.Web.Mvc;

namespace VetClinic.Areas.Default
{
    public class DefaultAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Default";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "Doctor",
                url: "registration/{action}/{id}",
                defaults: new { controller = "Doctor", action = "Register", id = UrlParameter.Optional }
                );

            context.MapRoute(
                name: "default",
                url:"{controller}/{action}/{id}",
                defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "VetClinic.Areas.Default.Controllers" }
            );
        }
    }
}
