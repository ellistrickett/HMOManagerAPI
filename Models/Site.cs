using System.ComponentModel.DataAnnotations;

namespace HMOManagerAPI.Models
{
    public class Site
    {
        public required int SiteId { get; set; }
        [MaxLength(250)]
        public required string Name { get; set; }
        [MaxLength(500)]
        public required string Address { get; set; }
        public List<Room>? Rooms { get; set; }
    }
}
