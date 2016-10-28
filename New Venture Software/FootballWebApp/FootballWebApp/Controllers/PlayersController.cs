﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using ManagerDataAccess;

namespace FootballWebApp.Controllers
{
    public class PlayersController : ApiController
    {
        FootBall_ManagerEntities entities = new FootBall_ManagerEntities();

        
        public IList<Player> Get()
        {
            entities.Configuration.ProxyCreationEnabled = false;

            var players = entities.Players.ToList();
            return players;
        }

        public HttpResponseMessage Get(int id)
        {
            entities.Configuration.ProxyCreationEnabled = false;

            var player = entities.Players.FirstOrDefault(p => p.Id == id);

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
            entities.Configuration.ProxyCreationEnabled = false;

            try
            {
                entities.Players.Add(player);

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
            entities.Configuration.ProxyCreationEnabled = false;

            try
            {
                var playerToRemove = entities.Players.FirstOrDefault(p => p.Id == id);

                if (playerToRemove == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Player with the passed {id} does not exist in the database!");
                }
                else
                {
                    entities.Players.Remove(playerToRemove);

                    entities.SaveChanges();

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
            entities.Configuration.ProxyCreationEnabled = false;

            try
            {
                var playerToUpdate = entities.Players.FirstOrDefault(p => p.Id == id);

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
