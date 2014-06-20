using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillaSenegal.Models;

namespace VillaSenegal.DAL.Configuration
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.Property(p => p.Id).HasColumnOrder(0);

            this.Property(p => p.Pseudo)
                .IsRequired().HasMaxLength(100);

            this.Property(p => p.Prenom)
                .IsOptional().HasMaxLength(100);

            this.Property(p => p.Nom)
                .IsRequired().HasMaxLength(100);


            this.HasMany(a => a.Roles)
                .WithMany(b => b.Users).Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("RoleId");
                    m.ToTable("webpages_UsersInRoles");

                });

        }
    }
}
