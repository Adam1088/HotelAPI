using AutoMapper;
using Core.Interfaces.Repository;
using Core.Interfaces.Service;
using Infrastructure.Data.DTO;
using Infrastructure.Data.Entities;

namespace Core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
        }

        public async Task<List<ReservationDTO>> GetAllReservations(CancellationToken token = default)
        {
            List<ReservationEntity> reservationEntities = await _reservationRepository.GetAllReservations(token);

            List<ReservationDTO> reservationDtos = _mapper.Map<List<ReservationDTO>>(reservationEntities);

            return reservationDtos;
        }

        public async Task<ReservationDTO> GetReservationById(string reservationId, CancellationToken token = default)
        {
            ReservationEntity result = await _reservationRepository.GetReservationById(int.Parse(reservationId), token);

            ReservationDTO reservationDto = _mapper.Map<ReservationDTO>(result);

            return reservationDto;
        }
    }
}
