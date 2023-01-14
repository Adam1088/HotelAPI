using Core.Interfaces.Service;
using Infrastructure.Data.DTO;
using Microsoft.AspNetCore.Mvc;

namespace HotelAPI.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetLoginByEmployeeId(string employeeId)
        {
            string login = await _accountService.GetLoginByEmployeeId(employeeId, HttpContext.RequestAborted);

            if(login == null)
                return NotFound();

            return Ok(login);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAccount([FromBody] AccountDTO newAccount)
        {
            int accountId = await _accountService.CreateAccount(newAccount);

            return Ok(accountId);
        }

        [HttpPut("{accountId}")]
        public async Task<IActionResult> UpdateAccount([FromRoute] string accountId, [FromBody] AccountDTO request)
        {
            await _accountService.UpdateAccount(accountId, request);

            return Ok();
        }

        [HttpDelete("{accountId}")]
        public async Task<IActionResult> DeleteAccount([FromRoute] string accountId)
        {
            bool hasAccountBeenDeleted = await _accountService.DeleteAccount(accountId);

            if (!hasAccountBeenDeleted)
                return NotFound();

            return NoContent();
        }
    }
}
