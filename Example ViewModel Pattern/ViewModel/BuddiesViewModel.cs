﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RibbitMvc.Models;

namespace RibbitMvc.ViewModel
{
    public class BuddiesViewModel
    {
        public User  User{get; set; }
        public IEnumerable<User> Buddies { get; set; }


    }
}