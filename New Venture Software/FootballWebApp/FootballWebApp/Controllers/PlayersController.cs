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
                
        public IList<Player> Get()
        {
            var players = base.entities.Players.Include("Team1").Include("Country").ToList();

            return players;
        }

        public HttpResponseMessage Post([FromBody]Player player)
        {
            try
            {
                int playerId = player.Id;
                var playerToUpdate = base.entities.Players.FirstOrDefault(p => p.Id == playerId);

                if (playerToUpdate != null)
                {
                    base.entities.Entry(playerToUpdate).CurrentValues.SetValues(player);
                }
                else
                {
                    var playerToBeAdded = new Player()
                    {
                        Name = player.Name,
                        Position = player.Position,
                        BirthDate = player.BirthDate,
                        PreviousTeadmId = player.TeamId,
                        CountryId = player.CountryId,
                        PreviousTeadmId = null,
                        MonthlyWage = null
                    };

                    base.entities.Players.Add(playerToBeAdded);
                }

                base.entities.SaveChanges();

                var message = Request.CreateResponse(HttpStatusCode.Created, player);
                message.Headers.Location = new Uri(Request.RequestUri + player.Name);

                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete([FromBody]Player player)
        {
            try
            {
                var playerId = player.Id;
                var playerToRemove = base.entities.Players.FirstOrDefault(p => p.Id == playerId);

                if (playerToRemove != null)
                {
                    base.entities.Players.Remove(playerToRemove);

                    base.entities.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Player with the passed {playerId} does not exist in the database!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
