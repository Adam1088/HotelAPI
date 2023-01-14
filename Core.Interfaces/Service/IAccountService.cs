using Infrastructure.Data.DTO;

namespace Core.Interfaces.Service
{
    public interface IAccountService
    {
        Task<string> GetLoginByEmployeeId(string employeeId, CancellationToken token = default);
        Task<int> CreateAccount(AccountDTO newAccount);
        Task UpdateAccount(string accountId, AccountDTO request);
        Task<bool> DeleteAccount(string accountId);
    }
}
