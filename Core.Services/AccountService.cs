using AutoMapper;
using Core.Interfaces.Repository;
using Core.Interfaces.Service;
using Infrastructure.Data.DTO;
using Infrastructure.Data.Entities;

namespace Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<string> GetLoginByEmployeeId(string employeeId, CancellationToken token = default)
        {
            string foundLogin = await _accountRepository.GetLoginByEmployeeId(int.Parse(employeeId), token);

            return foundLogin;
        }

        public async Task<int> CreateAccount(AccountDTO newAccount)
        {
            AccountEntity accountToCreate = _mapper.Map<AccountEntity>(newAccount);

            int accountId = await _accountRepository.CreateAccount(accountToCreate);

            return accountId;
        }

        public async Task UpdateAccount(string accountId, AccountDTO request)
        {
            await _accountRepository.UpdateAccount(accountId, request);
        }

        public async Task<bool> DeleteAccount(string accountId)
        {
            bool hasEntityBeenDeleted = await _accountRepository.DeleteAccountById(int.Parse(accountId));

            return hasEntityBeenDeleted;
        }
    }
}
