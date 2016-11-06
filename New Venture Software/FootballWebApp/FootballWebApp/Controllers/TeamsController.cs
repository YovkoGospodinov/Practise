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
    public class TeamsController : BaseController, IController<Team>
    {
        public TeamsController()
            : base() { }

        public IList<Team> Get()
        {
            var teams = base.entities.Teams.Include("Country").Include("League").Include("City").ToList();
            return teams;
        }

        public HttpResponseMessage Post([FromBody]Team team)
        {
            try
            {
                int teamId = team.Id;
                var teamToUpdate = base.entities.Teams.FirstOrDefault(t => t.Id == teamId);

                if (teamToUpdate != null)
                {
                    base.entities.Entry(teamToUpdate).CurrentValues.SetValues(team);
                }
                else
                {
                    var teamToBeAdded = new Team()
                    {
                        Name = team.Name,
                        NickName = team.NickName,
                        LeagueId = team.LeagueId,
                        CountryId = team.CountryId,
                        CityId = team.CityId
                    };
                    base.entities.Teams.Add(teamToBeAdded);
                }

                base.entities.SaveChanges();

                var message = Request.CreateResponse(HttpStatusCode.Created, team);
                message.Headers.Location = new Uri(Request.RequestUri + team.Name);

                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete([FromBody]Team team)
        {
            try
            {
                var teamId = team.Id;
                var teamToRemove = base.entities.Teams.FirstOrDefault(t => t.Id == teamId);

                if (teamToRemove != null)
                {
                    base.entities.Teams.Remove(teamToRemove);

                    base.entities.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Team with the passed {teamId} does not exist in the database!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
