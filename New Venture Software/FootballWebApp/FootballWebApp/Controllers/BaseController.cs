using System.Web.Http;
using ManagerDataAccess;

namespace FootballWebApp.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected FootBallManagerEntities entities = new FootBallManagerEntities();

        protected BaseController()
        {
            entities.Configuration.ProxyCreationEnabled = false;
        }
    }
}
