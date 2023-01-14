using Infrastructure.Data.DTO;
using Infrastructure.Data.Entities;

namespace Core.Interfaces.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<EmployeeEntity>> GetAllEmployees(CancellationToken token = default);
        Task<EmployeeEntity> GetEmployeeById(int employeeId, CancellationToken token = default);
        Task<int> CreateEmployee(EmployeeEntity newEmployee);
        Task<EmployeeEntity> UpdateEmployee(string employeeId, EmployeeDTO request);
        Task<bool> DeleteEmployeeById(int employeeId);
    }
}
