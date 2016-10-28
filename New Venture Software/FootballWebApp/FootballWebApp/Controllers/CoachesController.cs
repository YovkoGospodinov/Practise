using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using ManagerDataAccess;

namespace FootballWebApp.Controllers
{
    public class CoachesController : ApiController
    {
        FootBall_ManagerEntities entities = new FootBall_ManagerEntities();
        public IList<Coach> Get()
        {
            entities.Configuration.ProxyCreationEnabled = false;

            var coaches = entities.Coaches.ToList();
            return coaches;
        }

        public HttpResponseMessage Get(int id)
        {
            entities.Configuration.ProxyCreationEnabled = false;

            var coach = entities.Players.FirstOrDefault(c => c.Id == id);

            if (coach != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, coach);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Coach with the passed Id - {id} does not exist in the database!");
            }
        }

        public HttpResponseMessage Post([FromBody]Coach coach)
        {
            entities.Configuration.ProxyCreationEnabled = false;

            try
            {
                entities.Coaches.Add(coach);

                entities.SaveChanges();

                var message = Request.CreateResponse(HttpStatusCode.Created, coach);
                message.Headers.Location = new Uri(Request.RequestUri + coach.Name);

                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Delete(int id)
        {
            entities.Configuration.ProxyCreationEnabled = false;

            try
            {
                var coachToRemove = entities.Coaches.FirstOrDefault(c => c.Id == id);

                if (coachToRemove == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Coach with the passed {id} does not exist in the database!");
                }
                else
                {
                    entities.Coaches.Remove(coachToRemove);

                    entities.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(int id, [FromBody] Coach coach)
        {
            entities.Configuration.ProxyCreationEnabled = false;

            try
            {
                var coachToUpdate = entities.Coaches.FirstOrDefault(c => c.Id == id);

                if (coachToUpdate == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Coach with the passed {id} does not exist in the database!");
                }
                else
                {
                    coachToUpdate.Name = coach.Name;

                    entities.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, coachToUpdate);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
