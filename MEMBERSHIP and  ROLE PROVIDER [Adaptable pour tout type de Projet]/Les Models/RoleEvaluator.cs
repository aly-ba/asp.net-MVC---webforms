using System.Web.Security;

namespace VillaSenegal.Présentation.Models
{
    public class RoleEvaluator
    {
        public bool CanEdit
        {
            get 
            {
                return  Roles.IsUserInRole("admin") ||
                        Roles.IsUserInRole("manager") ||
                        Roles.IsUserInRole("user");
            }
        }

        public bool CanDelete
        {
            get 
            {
                return  Roles.IsUserInRole("admin") ||
                        Roles.IsUserInRole("manager");
            }
        }
    }
}