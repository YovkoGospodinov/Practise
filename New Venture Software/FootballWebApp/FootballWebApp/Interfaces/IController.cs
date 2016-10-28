using System.Collections.Generic;
using System.Net.Http;

namespace FootballWebApp.Interfaces
{
    public interface IController<T> 
        where T : class
    {
        IList<T> GetAll();

        HttpResponseMessage Get(int id);

        HttpResponseMessage Post(T entry);

        HttpResponseMessage Delete(int id);

        HttpResponseMessage Put(int id, T entry);
    }
}
