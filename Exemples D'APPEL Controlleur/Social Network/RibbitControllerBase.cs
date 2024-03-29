﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RibbitMvc.Data;
using RibbitMvc.Models;
using RibbitMvc.Services;

namespace RibbitMvc.Controllers
{
    public class RibbitControllerBase : Controller
    {
        protected IContext DataContext;
        public User CurrentUser { get; private set; }
        public IUserService Users { get; private set; }
        public ISecurityService  Security { get; private set; }

        public RibbitControllerBase()
        {
            DataContext = new Context();
            Users = new UserService(DataContext);
            Security = new SecurityService(Users);
            CurrentUser = Security.GetCurrentUser();
        }

        protected override void Dispose(bool disposing)
        {
            if (DataContext != null)
            {
                base.Dispose(disposing);
            }

        }
    }
}