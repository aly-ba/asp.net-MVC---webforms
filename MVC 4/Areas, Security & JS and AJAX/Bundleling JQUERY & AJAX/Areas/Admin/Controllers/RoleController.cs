using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Lesson14.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        //
        // GET: /Admin/Role/

        public ActionResult Index()
        {
            var roles = Roles.GetAllRoles();
            return View(roles);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string roleName)
        {
            if (!Roles.RoleExists(roleName))
            {
                Roles.CreateRole(roleName);
            }

            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            if (!Roles.RoleExists(id))
            {
                return new HttpNotFoundResult();
            }

            return View(model: id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string oldRoleName, string newRoleName)
        {

            if (oldRoleName == newRoleName)
            {
                return RedirectToAction("Index");
            }

            var users = Roles.GetUsersInRole(oldRoleName);

            Roles.RemoveUsersFromRole(users, oldRoleName);

            Roles.DeleteRole(oldRoleName);

            Roles.CreateRole(newRoleName);

            Roles.AddUsersToRole(users, newRoleName);

            return RedirectToAction("Index");
        }


    }
}
