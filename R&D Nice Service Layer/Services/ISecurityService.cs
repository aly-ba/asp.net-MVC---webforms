using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RibbitMvc.Models;

namespace RibbitMvc.Services
{
    public  interface ISecurityService
    {
        bool Authenticate(string username, string password);
        User CreateUser(string username, string password, bool login);
        User GetCurrentUser();
        bool DoesUserExists(string username);
        bool IsAuthenticate { get; }
        void Login(User user);
        void Login(string username);
        void Logout();
        int  UserId { get; set;  }
        
    }
}
