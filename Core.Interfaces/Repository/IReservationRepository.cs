using Infrastructure.Data.Entities;

namespace Core.Interfaces.Repository
{
    public interface IReservationRepository
    {
        Task<List<ReservationEntity>> GetAllReservations(CancellationToken token = default);
        Task<ReservationEntity> GetReservationById(int reservationId, CancellationToken token = default);
    }
}
