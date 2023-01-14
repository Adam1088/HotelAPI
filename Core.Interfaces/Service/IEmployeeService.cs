using Infrastructure.Data.DTO;

namespace Core.Interfaces.Service
{
    public interface IEmployeeService
    {
        Task<List<EmployeeDTO>> GetAllEmployees(CancellationToken token = default);
        Task<EmployeeDTO> GetEmployeeById(string employeeId, CancellationToken token = default);
        Task<int> CreateEmployee(EmployeeDTO newEmployee);
        Task<EmployeeDTO> UpdateEmployee(string employeeId, EmployeeDTO request);
        Task<bool> DeleteEmployee(string employeeId);
    }
}
