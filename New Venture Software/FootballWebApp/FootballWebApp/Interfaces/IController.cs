using System.Collections.Generic;
using System.Net.Http;

namespace FootballWebApp.Interfaces
{
    public interface IController<T> 
        where T : class
    {
        IList<T> Get();

        HttpResponseMessage Post(T entry);

        HttpResponseMessage Delete(T entry);
    }
}
