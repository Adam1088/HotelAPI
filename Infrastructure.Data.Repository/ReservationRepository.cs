using Core.Interfaces.Repository;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly DataContext _context;

        public ReservationRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<ReservationEntity>> GetAllReservations(CancellationToken token = default)
        {
            List<ReservationEntity> reservations = await _context.Reservations.ToListAsync(token);

            return reservations;
        }

        public async Task<ReservationEntity> GetReservationById(int reservationId, CancellationToken token = default)
        {
            ReservationEntity? result = await _context.Reservations.FirstOrDefaultAsync(r => r.ReservationId == reservationId, token);

            return result;
        }
    }
}
