using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.Entities
{
    [Table("Reservations")]
    public class ReservationEntity
    {
        [Key]
        public int ReservationId { get; set; }
        public DateTime ReservationTime { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateOut { get; set; }
        public int RoomId { get; set; }
        public virtual EmployeeEntity ResponsibleEmployee { get; set; }
    }
}
