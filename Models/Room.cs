using System.ComponentModel.DataAnnotations;

namespace HMOManagerAPI.Models
{
    public class Room
    {
        public required int RoomId { get; set; }
        [MaxLength(100)]
        public required string Name { get; set; }
        public required bool IsOccupied { get; set; }
        public DateTime? MovedInDate { get; set; }
        public DateTime? ContractEndDate { get; set; }
        public RentFrequency? RentFrequency { get; set; }
        public int RentAmount { get; set; }
        public DateTime? RentDueDate { get; set; }
        public required int SiteId { get; set; }
        public required Site Site { get; set; }
        public List<Tenant>? Tenants { get; set; }
    }
    public enum RentFrequency
    {
        Weekly,
        Monthly,
        Quarterly,
        PaidInAdvance
    }
}
