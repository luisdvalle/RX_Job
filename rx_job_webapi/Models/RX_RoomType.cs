using System.ComponentModel.DataAnnotations;

namespace rx_job_webapi.Models
{
    public class RX_RoomType
    {
        [Key]
        public string RoomType { get; set; }
        public int Count { get; set; }
    }
}