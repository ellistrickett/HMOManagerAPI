namespace HMOManagerAPI.Models
{
    public class OccupiedRoomInfoDto
    {
        public int RoomId { get; set; }
        public required string Name { get; set; }
        public DateTime RentDueDate { get; set; }
        public int RentAmount { get; set; }
    }
}
