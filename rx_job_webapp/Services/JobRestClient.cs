using Newtonsoft.Json;
using rx_job_webapp.Interfaces;
using rx_job_webapp.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace rx_job_webapp.Services
{
    public class JobRestClient : IRestClient<Job>
    {
        public string Host { get; set; }
        public string Path { get; set; }
        public static HttpClient Client = new HttpClient();

        public async Task<IEnumerable<Job>> GetAll()
        {
            var stringResponse = await Client.GetStringAsync(Host + Path);

            if (stringResponse != null)
            {
                var response = JsonConvert.DeserializeObject<IEnumerable<Job>>(stringResponse);

                if (response != null)
                {
                    return response;
                }
            }

            return null;
        }

        public async Task<bool> UpdateSingle(string status)
        {
            var data = JsonConvert.SerializeObject(status);
            var contentData = new StringContent(data, System.Text.Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(Host + Path, contentData);

            return response.IsSuccessStatusCode;
        }
    }
}
