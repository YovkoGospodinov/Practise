using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using ManagerDataAccess;

namespace FootballWebApp.Controllers
{
    public class TeamsController : ApiController
    {
        FootBall_ManagerEntities entities = new FootBall_ManagerEntities();
        public IList<Team> Get()
        {
            entities.Configuration.ProxyCreationEnabled = false;

            var teams = entities.Teams.ToList();
            return teams;
        }

        public HttpResponseMessage Get(int id)
        {
            entities.Configuration.ProxyCreationEnabled = false;

            var team = entities.Teams.FirstOrDefault(t => t.Id == id);

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
            entities.Configuration.ProxyCreationEnabled = false;

            try
            {
                entities.Teams.Add(team);

                entities.SaveChanges();

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
            entities.Configuration.ProxyCreationEnabled = false;

            try
            {
                var teamToRemove = entities.Teams.FirstOrDefault(t => t.Id == id);

                if (teamToRemove == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Team with the passed {id} does not exist in the database!");
                }
                else
                {
                    entities.Teams.Remove(teamToRemove);

                    entities.SaveChanges();

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
            entities.Configuration.ProxyCreationEnabled = false;

            try
            {
                var teamToUpdate = entities.Teams.FirstOrDefault(t => t.Id == id);

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

                    entities.SaveChanges();

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
