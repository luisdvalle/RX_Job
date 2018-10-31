using System.Collections.Generic;
using System.Threading.Tasks;

namespace rx_job_webapp.Interfaces
{
    public interface IRestClient<T> where T : class
    {
        string Host { get; set; }
        string Path { get; set; }

        Task<IEnumerable<T>> GetAll();

        Task<bool> UpdateSingle(string status);
    }
}
