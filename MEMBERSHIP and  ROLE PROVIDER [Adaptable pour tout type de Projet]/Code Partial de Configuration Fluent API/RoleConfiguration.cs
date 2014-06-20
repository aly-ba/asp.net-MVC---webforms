using System.Data.Entity.ModelConfiguration;
using VillaSenegal.Models;

namespace VillaSenegal.DAL.Configuration
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            this.ToTable("webpages_Roles");
            this.Property(p => p.RoleName).HasMaxLength(256).IsRequired();
        }
    }
}
