namespace Infrastructure.Data.DTO
{
    public class ReservationDTO
    {
        public DateTime ReservationTime { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public int RoomId { get; set; }
    }
}
