        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            //profile/{action}
            routes.MapRoute(
                name: "ProfileDefault",
                url: "profile/{action}",
                defaults: new { controller = "profile", action = "index" }
            );

            //account/{action}
            routes.MapRoute(
                name: "AccountDefault",
                url: "account/{action}",
                defaults: new {controller = "account",}
            );

            //{username}/{action}

            //followwers
            routes.MapRoute(
                name: "Followers",
                url: "followers",
                defaults: new { controller = "home",action="followers" }
            );
            //following
            routes.MapRoute(
               name: "Following",
               url: "following",
               defaults: new { controller = "home", action = "following" }
           );
            //create
            routes.MapRoute(
               name: "Create",
               url: "create",
               defaults: new { controller = "home", action = "create" }
           );

            //user
            routes.MapRoute(
                name: "UserDefault",
                url: "{username}/{action}",
                defaults: new { controller = "user", action = "index" }
            );

            //root
            routes.MapRoute(
               name: "Default",
               url: "",
               defaults: new { controller = "home", action = "index" }
           );

            //unfollow
            routes.MapRoute(
                name: "Follow",
                url: "follow",
                defaults: new { controller = "home", action = "follow" }
            );


            //unfollow
            routes.MapRoute(
                name: "UnFollow",
                url: "unfollow",
                defaults: new { controller = "home", action = "unfollow" }
            );