using Core.Interfaces.Repository;
using Infrastructure.Data.DTO;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DataContext _context;

        public AccountRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<string> GetLoginByEmployeeId(int employeeId, CancellationToken token = default)
        {
            AccountEntity foundAccount = await _context.Accounts
               .Where(a => a.Employee.EmployeeId == employeeId)
               .FirstOrDefaultAsync(token);

            if (foundAccount == null)
                throw new KeyNotFoundException();

            return foundAccount.Login;
        }

        public async Task<int> CreateAccount(AccountEntity newAccount)
        {
            await _context.Accounts.AddAsync(newAccount);

            await _context.SaveChangesAsync();

            return newAccount.AccountId;
        }

        public async Task UpdateAccount(string accountId, AccountDTO request)
        {
            AccountEntity? accountToUpdate = await _context.Accounts.FindAsync(int.Parse(accountId));

            if (accountToUpdate == null)
                throw new KeyNotFoundException();

            accountToUpdate.Login = request.Login;
            accountToUpdate.Password = request.Password;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAccountById(int accountId)
        {
            AccountEntity? accountEntity = await _context.Accounts.FindAsync(accountId);

            if (accountEntity == null)
                return false;

            _context.Accounts.Remove(accountEntity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
