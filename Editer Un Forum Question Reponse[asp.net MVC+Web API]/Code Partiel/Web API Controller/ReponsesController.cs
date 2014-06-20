using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MESSADIIS.Data;

namespace MESSADIIS.Controllers
{
    public class ReponsesController : ApiController
    {
        private MessadiisRepository _repo;

        public ReponsesController(MessadiisRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Reponse> Get(int questionId)
        {
            return _repo.GetReponsesByQuestion(questionId);
        }

        public HttpResponseMessage Post(int questionId,
            [FromBody]Reponse newReponse)
        {
            if (newReponse.Creation == default(DateTime))
            {
                newReponse.Creation = DateTime.UtcNow;
            }
            newReponse.QuestionId = questionId;

            if (_repo.AddReponse(newReponse) &&
                _repo.Save())
            {
                Request.CreateResponse(HttpStatusCode.Created, newReponse);

            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

    }
}
