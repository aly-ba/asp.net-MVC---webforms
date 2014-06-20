using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaSenegal.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Pseudo { get; set; }

        public ICollection<Role> Roles { get; set; }

        public User()
        {
            this.Roles = new List<Role>();
        }

    }
}
