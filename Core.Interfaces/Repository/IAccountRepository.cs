using Infrastructure.Data.DTO;
using Infrastructure.Data.Entities;

namespace Core.Interfaces.Repository
{
    public interface IAccountRepository
    {
        Task<string> GetLoginByEmployeeId(int employeeId, CancellationToken token = default);
        Task<int> CreateAccount(AccountEntity newAccount);
        Task UpdateAccount(string accountId, AccountDTO request);
        Task<bool> DeleteAccountById(int accountId);
    }
}
