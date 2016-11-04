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
        public IList<Team> GetAll()
        {
            var teams = base.entities.Teams.Include("Country").Include("League").ToList();
            return teams;
        }

        public HttpResponseMessage Get(int id)
        {
            var team = base.entities.Teams.FirstOrDefault(t => t.Id == id);

            if (team != null)
            {
               return  Request.CreateResponse(HttpStatusCode.OK, team);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Team with the passed Id does not exist in the database!");
            }
        }

        public HttpResponseMessage Post([FromBody]Team team)
        {
            try
            {
                base.entities.Teams.Add(team);

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

        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var teamToRemove = base.entities.Teams.FirstOrDefault(t => t.Id == id);

                if (teamToRemove == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Team with the passed {id} does not exist in the database!");
                }
                else
                {
                    base.entities.Teams.Remove(teamToRemove);

                    base.entities.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(int id, [FromBody] Team team)
        {
            try
            {
                var teamToUpdate = base.entities.Teams.FirstOrDefault(t => t.Id == id);

                if (teamToUpdate == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Team with the passed {id} does not exist in the database!");
                }
                else
                {
                    teamToUpdate.Name = team.Name;
                    teamToUpdate.NickName = team.NickName;
                    teamToUpdate.CountryId = team.CountryId;
                    teamToUpdate.LeagueId = team.LeagueId;
                    teamToUpdate.CityId = team.CityId;

                    base.entities.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, teamToUpdate);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
