using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MESSADIIS.Data;

namespace MESSADIIS.Controllers
{
    public class QuestionsController : ApiController
    {
        private IMessadiisRepository _repo;
        public QuestionsController(IMessadiisRepository repo)
        {
            _repo = repo;
        }

        //just map verb only thid
        //retourne une collection de nos questions (object)
        public IEnumerable<Question> Get(bool inclusReponses =false )
        {
            IQueryable<Question> results;

            if (inclusReponses == true)
            {
                results = _repo.GetQuestionsInclusReponses();
                                 
            }

            else
            {
                results = _repo.GetQuestions();
                    
            }

            //_repo.GetQuestionsInclusReponses()
            //                      .OrderByDescending(t => t.Creation)
            //                      .Take(50);

            var questions =results.OrderByDescending(t => t.Creation)
                                 .Take(50);
                     return questions;
        }

        //FromBody for security not violating data for our each 
        //of our collection
        // i prefre to use HttpResponseMessage despit Question Object
        //because I als can process the errors with this kind of return 
        //type

        public HttpResponseMessage Post([FromBody]Question newQuestion)
        {
            if (newQuestion.Creation == default(DateTime))
            {
                newQuestion.Creation = DateTime.UtcNow;
            }

            if (_repo.AddQuestion(newQuestion) &&
                _repo.Save())
            {
                return Request.CreateResponse(HttpStatusCode.Created,
                    newQuestion);
            }

            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        //public HttpResponseMessage Post([FromBody]Question newQuestion)
        //{
        //    if (newQuestion.Creation == default(DateTime))
        //    {
        //        newQuestion.Creation = DateTime.UtcNow;
        //    }

        //    if (_repo.AddQuestion(newQuestion) &&
        //        _repo.Save())
        //    {
        //        return Request.CreateResponse(HttpStatusCode.Created,
        //          newQuestion);
        //    }
        //    return Request.CreateResponse(HttpStatusCode.BadRequest);
        //}

    }
}
