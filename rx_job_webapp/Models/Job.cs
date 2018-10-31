using Newtonsoft.Json;

namespace rx_job_webapp.Models
{
    public class Job
    {
        [JsonProperty("jobID")]
        public int JobID { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("floor")]
        public string Floor { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("roomType")]
        public string RoomType { get; set; }
    }
}
