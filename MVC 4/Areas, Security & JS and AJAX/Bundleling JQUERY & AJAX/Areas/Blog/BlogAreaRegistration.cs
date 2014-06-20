using System.Web.Mvc;

namespace Lesson14.Areas.Blog
{
    public class BlogAreaRegistration : AreaRegistration
    {
        private const string YearPattern = @"\d{4}";
        private const string TwoDigitPattern = @"\d{2}";

        public override string AreaName
        {
            get
            {
                return "Blog";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                name: "BlogDetails",
                url: "blog/{year}/{month}/{day}/{title}",
                defaults: new { controller = "Blog", action = "Details" },
                constraints: new { year = YearPattern, month = TwoDigitPattern, day = TwoDigitPattern }
            );

            context.MapRoute(
                name: "BlogByDay",
                url: "blog/{year}/{month}/{day}",
                defaults: new { controller = "Blog", action = "ByDay" },
                constraints: new { year = YearPattern, month = TwoDigitPattern, day = TwoDigitPattern }
            );

            context.MapRoute(
                name: "BlogByMonth",
                url: "blog/{year}/{month}",
                defaults: new { controller = "Blog", action = "ByMonth" },
                constraints: new { year = YearPattern, month = TwoDigitPattern }
            );

            context.MapRoute(
                name: "BlogByYear",
                url: "blog/{year}",
                defaults: new { controller = "Blog", action = "ByYear" },
                constraints: new { year = YearPattern }
            );

            context.MapRoute(
                name: "BlogAction",
                url: "blog/{action}/{value}",
                defaults: new { controller = "Blog", action = "Index", value = UrlParameter.Optional }            );

            context.MapRoute(
                name: "BlogDefault",
                url: "blog",
                defaults: new { controller = "Blog", action = "Index" }
            );
        }
    }
}
