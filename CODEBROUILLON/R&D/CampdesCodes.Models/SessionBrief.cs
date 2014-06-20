using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CampdesCodes.Models
{
    public  class SessionBrief
    {
        public int Id{ get; set; }
        public string Title { get; set;  }
        public int SpeakerId { get; set; }
        public int TrackId { get; set; }
        public int TimeSlotId { get; set; }
        public int RoomId { get; set; }
        public string Level { get; set; }
        public string Tags { get; set; }
    }
}
