using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RibbitMvc.Models;

namespace RibbitMvc.Services
{
    interface IRibbitService
    {
        Ribbit GetBy(int id);
        Ribbit Create(User user,string status, DateTime? created=null);

    }
}
