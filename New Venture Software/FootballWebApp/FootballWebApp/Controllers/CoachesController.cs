using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using ManagerDataAccess;
using FootballWebApp.Interfaces;

namespace FootballWebApp.Controllers
{
    public class CoachesController : BaseController, IController<Coach>
    {
        public CoachesController() 
            : base() { }

        public IList<Coach> GetAll()
        {
            var coaches = base.entities.Coaches.ToList();
            return coaches;
        }

        public HttpResponseMessage Get(int id)
        {
            var coach = base.entities.Coaches.FirstOrDefault(c => c.Id == id);

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
            try
            {
                base.entities.Coaches.Add(coach);

                base.entities.SaveChanges();

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
            try
            {
                var coachToRemove = base.entities.Coaches.FirstOrDefault(c => c.Id == id);

                if (coachToRemove == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Coach with the passed {id} does not exist in the database!");
                }
                else
                {
                    base.entities.Coaches.Remove(coachToRemove);

                    base.entities.SaveChanges();

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

                    base.entities.SaveChanges();

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
