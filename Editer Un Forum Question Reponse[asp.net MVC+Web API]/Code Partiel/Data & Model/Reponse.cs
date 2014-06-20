using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MESSADIIS.Data
{
    public  class Reponse
    {
        public int Id { get; set; }
        public string Texte {get; set; }
        public DateTime Creation {get; set; }

        public int QuestionId { get; set; } //foreign key

    }

   
}
