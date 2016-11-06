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
    public class CountriesController : BaseController, IController<Country>
    {
        public CountriesController()
            : base() { }

        public IList<Country> Get()
        {
            var countries = base.entities.Countries.ToList();

            return countries;
        }

        public HttpResponseMessage Post([FromBody]Country country)
        {
            try
            {
                int countryId = country.Id;
                var countryToUpdate = base.entities.Players.FirstOrDefault(c => c.Id == countryId);

                if (countryToUpdate != null)
                {
                    base.entities.Entry(countryToUpdate).CurrentValues.SetValues(country);
                }
                else
                {
                    base.entities.Countries.Add(country);
                }

                base.entities.SaveChanges();

                var message = Request.CreateResponse(HttpStatusCode.Created, country);
                message.Headers.Location = new Uri(Request.RequestUri + country.Name);

                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete([FromBody]Country country)
        {
            try
            {
                var countryId = country.Id;
                var countryToRemove = base.entities.Countries.FirstOrDefault(c => c.Id == countryId);

                if (countryToRemove != null)
                {
                    base.entities.Countries.Remove(countryToRemove);

                    base.entities.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Player with the passed {countryId} does not exist in the database!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
