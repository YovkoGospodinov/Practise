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
    public class LeaguesController : BaseController, IController<League>
    {
        public LeaguesController()
            : base() { }

        public IList<League> Get()
        {
            var leagues = base.entities.Leagues.ToList();

            return leagues;
        }

        public HttpResponseMessage Post([FromBody]League league)
        {
            try
            {
                int leagueId = league.Id;
                var leagueToUpdate = base.entities.Leagues.FirstOrDefault(l => l.Id == leagueId);

                if (leagueToUpdate != null)
                {
                    base.entities.Entry(leagueToUpdate).CurrentValues.SetValues(league);
                }
                else
                {
                    base.entities.Leagues.Add(league);
                }

                base.entities.SaveChanges();

                var message = Request.CreateResponse(HttpStatusCode.Created, league);
                message.Headers.Location = new Uri(Request.RequestUri + league.Name);

                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete([FromBody]League league)
        {
            try
            {
                var leagueId = league.Id;
                var leagueToRemove = base.entities.Leagues.FirstOrDefault(l => l.Id == leagueId);

                if (leagueToRemove != null)
                {
                    base.entities.Leagues.Remove(leagueToRemove);

                    base.entities.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Player with the passed {leagueId} does not exist in the database!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
