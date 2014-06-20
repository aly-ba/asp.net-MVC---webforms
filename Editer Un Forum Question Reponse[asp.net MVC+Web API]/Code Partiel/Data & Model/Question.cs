using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MESSADIIS.Data
{
    public class Question
    {
        public int Id { get; set; }
        public string  Titre { get; set; }
        public string   Texte { get; set; }
        public DateTime Creation { get; set; }
        public bool    Drapped { get; set; }

        //les reponses rattachées à une question
        public ICollection<Reponse> Reponses { get; set; }

    }
}