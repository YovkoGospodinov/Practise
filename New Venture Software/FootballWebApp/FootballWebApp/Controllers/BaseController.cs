using System.Web.Http;
using ManagerDataAccess;

namespace FootballWebApp.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected FootBall_ManagerEntities entities = new FootBall_ManagerEntities();

        protected BaseController()
        {
            entities.Configuration.ProxyCreationEnabled = false;
        }
    }
}
