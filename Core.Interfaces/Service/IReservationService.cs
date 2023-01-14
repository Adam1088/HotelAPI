using Infrastructure.Data.DTO;

namespace Core.Interfaces.Service
{
    public interface IReservationService
    {
        Task<List<ReservationDTO>> GetAllReservations(CancellationToken token = default);
        Task<ReservationDTO> GetReservationById(string reservationId, CancellationToken token = default);
    }
}
