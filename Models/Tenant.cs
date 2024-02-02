using System.ComponentModel.DataAnnotations;

namespace HMOManagerAPI.Models
{
    public class Tenant
    {
        public int TenantId { get; set; }
        [MaxLength(100)]
        public required string FirstName { get; set; }
        [MaxLength(100)]
        public required string Surname { get; set; }
        [MaxLength(100)]
        public string? MiddleNme { get; set; }
        [MaxLength(255)]
        public required string Email { get; set; }
        [MaxLength(50)]
        public required string PhoneNumber { get; set; }
        public required int RoomId { get; set; }
        public required Room Room { get; set; }
    }
}
    