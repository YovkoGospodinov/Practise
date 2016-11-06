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

        public IList<Coach> Get()
        {
            var coaches = base.entities.Coaches.Include("Team").ToList();

            return coaches;
        }

        public HttpResponseMessage Post([FromBody]Coach coach)
        {
            try
            {
                int coachId = coach.Id;
                var coachToUpdate = base.entities.Coaches.FirstOrDefault(c => c.Id == coachId);

                if (coachToUpdate != null)
                {
                    base.entities.Entry(coachToUpdate).CurrentValues.SetValues(coach);
                }
                else
                {
                    var coachToBeAdded = new Coach()
                    {
                        Name = coach.Name,
                        TeamId = coach.TeamId
                    };

                    base.entities.Coaches.Add(coachToBeAdded);
                }

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

        [HttpDelete]
        public HttpResponseMessage Delete([FromBody]Coach coach)
        {
            try
            {
                var coachId = coach.Id;
                var coachToRemove = base.entities.Coaches.FirstOrDefault(c => c.Id == coachId);

                if (coachToRemove != null)
                {
                    base.entities.Coaches.Remove(coachToRemove);

                    base.entities.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Coach with the passed {coachId} does not exist in the database!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
