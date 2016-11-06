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
    public class CitiesController : BaseController, IController<City>
    {
        public CitiesController()
            : base() { }

        public IList<City> Get()
        {
            var cities = base.entities.Cities.ToList();
            return cities;
        }

        public HttpResponseMessage Post([FromBody]City city)
        {
            try
            {
                int cityId = city.Id;
                var cityToUpdate = base.entities.Cities.FirstOrDefault(c => c.Id == cityId);

                if (cityToUpdate != null)
                {
                    base.entities.Entry(cityToUpdate).CurrentValues.SetValues(city);
                }
                else
                {
                    base.entities.Cities.Add(city);
                }

                base.entities.SaveChanges();

                var message = Request.CreateResponse(HttpStatusCode.Created, city);
                message.Headers.Location = new Uri(Request.RequestUri + city.Name);

                return message;
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete([FromBody]City city)
        {
            try
            {
                var cityId = city.Id;
                var cityToRemove = base.entities.Cities.FirstOrDefault(c => c.Id == cityId);

                if (cityToRemove != null)
                {
                    base.entities.Cities.Remove(cityToRemove);

                    base.entities.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Team with the passed {cityId} does not exist in the database!");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
