using Core.Interfaces.Service;
using Infrastructure.Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            List<ReservationDTO> reservationDtos = await _reservationService.GetAllReservations(HttpContext.RequestAborted);

            return Ok(reservationDtos);
        }

        [HttpGet("{reservationId}")]
        public async Task<IActionResult> GetReservation([FromRoute] string reservationId)
        {
            ReservationDTO result = await _reservationService.GetReservationById(reservationId, HttpContext.RequestAborted);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
