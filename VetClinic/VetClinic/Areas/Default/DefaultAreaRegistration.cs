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
                name: "Recall",
                url: "Recall/{action}/{id}",
                defaults: new { controller = "Recall", action = "ChooseDoctor", id = UrlParameter.Optional }
                );

            context.MapRoute(
                name: "Detail",
                url: "Detail/{action}/{id}",
                defaults: new { controller = "Detail", action = "GetPet", id = UrlParameter.Optional }
                );

            context.MapRoute(
                name: "Card",
                url: "Card/{action}/{id}",
                defaults: new { controller = "Card", action = "SelectPetToEntry", id = UrlParameter.Optional }
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
