using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RibbitMvc.ViewModel;

namespace RibbitMvc.Controllers
{
    //
    //GET : /HOME/
    public class HomeController : RibbitControllerBase
    {
        public HomeController(): base ()
        {
        }
    
        public ActionResult Index()
        {
            //CurrentUser
            //Security
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Follow(string username)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UnFollow(string username)
        {
            throw new NotImplementedException(username +"followed");
        }

        public ActionResult Profiles()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Followers()
        {
            if (!Security.IsAuthenticate)
            {
                return RedirectToAction("Index");
            }

            var user = Users.GetAllFor(Security.UserId);

            return View("Buddies", new BuddiesViewModel()
            {
                User = user,
                Buddies = user.Followers
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Following()
        {
            if (!Security.IsAuthenticate)
            {
                return RedirectToAction("Index");
            }

            var user = Users.GetAllFor(Security.UserId);

            return View("Buddies", new BuddiesViewModel()
            {
                User = user,
                Buddies = user.Followings
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create()
        {
            throw new NotImplementedException();
        }
    }
}
