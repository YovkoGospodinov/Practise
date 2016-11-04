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
    public class PlayersController : BaseController, IController<Player>
    {
        public PlayersController()
            : base() { }
                
        public IList<Player> GetAll()
        {
            //          var query = @"SELECT p.[Id]
            //    ,p.[Name]
            //    ,p.[BirthDate]
            //    ,p.[Position]
            //    ,t.[Name] AS [TeamId]
            //    ,c.[Name] AS [CountryId]
            //    ,p.[MonthlyWage]
            //    ,t1.[Name] AS [PreviousTeadmId]
            //FROM [FootBall Manager].[dbo].[Players] AS p
            //Join Teams AS t
            //ON p.TeamId = t.Id
            //JOIN Teams AS t1
            //ON p.PreviousTeadmId = t1.Id
            //JOIN Countries AS c
            //ON p.CountryId = c.Id";
            //          var players = base.entities.Players.SqlQuery(query).ToList();
            var players = base.entities.Players.Include("Team").Include("Country").ToList();

            return players;
        }

        public HttpResponseMessage Get(int id)
        {
            var player = base.entities.Players.FirstOrDefault(p => p.Id == id);

            if (player != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, player);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Player with the passed Id - {id} does not exist in the database!");
            }
        }

        public HttpResponseMessage Post([FromBody]Player player)
        {
            try
            {
                base.entities.Players.Add(player);

                entities.SaveChanges();

                var message = Request.CreateResponse(HttpStatusCode.Created, player);
                message.Headers.Location = new Uri(Request.RequestUri + player.Name);

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
                var playerToRemove = base.entities.Players.FirstOrDefault(p => p.Id == id);

                if (playerToRemove == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Player with the passed {id} does not exist in the database!");
                }
                else
                {
                    base.entities.Players.Remove(playerToRemove);

                    base.entities.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        public HttpResponseMessage Put(int id, [FromBody] Player player)
        {
            try
            {
                var playerToUpdate = base.entities.Players.FirstOrDefault(p => p.Id == id);

                if (playerToUpdate == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Player with the passed {id} does not exist in the database!");
                }
                else
                {
                    playerToUpdate.Name = player.Name;
                    playerToUpdate.BirthDate = player.BirthDate;
                    playerToUpdate.Position = player.Position;
                    playerToUpdate.TeamId = player.TeamId;
                    playerToUpdate.CountryId = player.CountryId;
                    playerToUpdate.MonthlyWage = player.MonthlyWage;
                    playerToUpdate.PreviousTeadmId = player.PreviousTeadmId;

                    entities.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK, playerToUpdate);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
