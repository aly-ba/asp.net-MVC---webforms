using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillaSenegal.Models;

namespace VillaSenegal.DAL.Configuration
{
    public class MemberShipConfiguration : EntityTypeConfiguration<MemberShip>
    {
        public MemberShipConfiguration()
        {
            this.ToTable("webpages_Membership");
            this.HasKey(p => p.UserId);

            this.Property(p => p.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(p => p.ConfirmationToken)
                .HasMaxLength(128).HasColumnType("nvarchar");

            this.Property(p => p.PasswordFailuresSinceLastSuccess)
                .IsRequired();

            this.Property(p => p.Password).IsRequired()
                .HasMaxLength(128).HasColumnType("nvarchar");

            this.Property(p => p.PasswordSalt)
                .IsRequired().HasMaxLength(128).HasColumnType("nvarchar");

            this.Property(p => p.PasswordVerificationToken)
                .HasMaxLength(128).HasColumnType("nvarchar");
        }
    }
}
