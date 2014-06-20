using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CampdeCodes.Data.Configuration;
using CampdeCodes.Data.SampleData;
using CampdesCodes.Models;

namespace CampdeCodes.Data
{
    public class CampdeCodeDbContext : DbContext
    {
        public CampdeCodeDbContext()
            : base(nameOrConnectionString: "CodeCampDev") { }


        public DbSet<Session> Sessions { get; set;  }
        public DbSet<Person> Persons { get; set;  }
        public DbSet<Attendance> Attendances { get; set; }


        //Lookup Lists
        public DbSet<Room> Romms { get; set;  }
        public DbSet<TimeSlot> TimeSlots { get; set;  }
        public DbSet<Track> Tracks { get; set;  }

        static CampdeCodeDbContext()
        {
            Database.SetInitializer(new CodeCamperDatabaseInitializer()
                );
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            //Use singular tables names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new SessionConfiguration());
            modelBuilder.Configurations.Add(new AttendanceConfiguration());
        }
    }
}
