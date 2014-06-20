using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MESSADIIS.Data
{
    public class MessadissRepository : IMessadiisRepository
    {
        //the goog choice is to create an instance of the db context hihin lol
        //bonne pratique je préfére because DbContext n'est une classe statique ici lol et
        // ne le sera jaamais pour moi pour de rire ni abstract, ni extension method avec db context

        MessadiisContext _ctx;

        public MessadissRepository(MessadiisContext ctx) 
        {
            _ctx = ctx;
        }

        
        public IQueryable<Question> GetQuestions()
        {
            //the context is a disposable object


            return _ctx.Questions;
        }

        public IQueryable<Reponse> GetReponsesByQuestion(int QuestionId)
        {
            return _ctx.Reponses.Where(r => r.QuestionId == QuestionId);
        }
    }
}