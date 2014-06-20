using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillaSenegal.Models
{
    public class OAuthMemberShipMetaData { }

    public class OAuthMemberShip
    {
        public string Provider { get; set;  }
        public string ProviderUserId { get; set; }
        public int UserId { get; set; }
    }
}
