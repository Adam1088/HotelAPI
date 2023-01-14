using Core.Interfaces.Repository;
using Infrastructure.Data.DTO;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext _context;

        public EmployeeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<EmployeeEntity>> GetAllEmployees(CancellationToken token = default)
        {
            List<EmployeeEntity> employees = await _context.Employees.ToListAsync(token);

            return employees;
        }

        public async Task<EmployeeEntity> GetEmployeeById(int employeeId, CancellationToken token = default)
        {
            EmployeeEntity? result = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId, token);

            return result;
        }

        public async Task<int> CreateEmployee(EmployeeEntity newEmployee)
        {
            await _context.Employees.AddAsync(newEmployee);

            await _context.SaveChangesAsync();

            return newEmployee.EmployeeId;
        }

        public async Task<EmployeeEntity> UpdateEmployee(string employeeId, EmployeeDTO request)
        {
            EmployeeEntity? employeeToUpdate = await _context.Employees.FindAsync(int.Parse(employeeId));

            if (employeeToUpdate == null)
                throw new KeyNotFoundException();

            employeeToUpdate.FirstName = request.FirstName;
            employeeToUpdate.LastName = request.LastName;
            employeeToUpdate.Street = request.Street;
            employeeToUpdate.City = request.City;
            employeeToUpdate.Phone = request.Phone;
            employeeToUpdate.Gender = request.Gender;
            employeeToUpdate.Birthdate = request.Birthdate;
            employeeToUpdate.EmploymentDate = request.EmploymentDate;
            employeeToUpdate.JobTitle = request.JobTitle;
            employeeToUpdate.Salary = request.Salary;

            await _context.SaveChangesAsync();

            return employeeToUpdate;
        }

        public async Task<bool> DeleteEmployeeById(int employeeId)
        {
            EmployeeEntity? employeeEntity = await _context.Employees.FindAsync(employeeId);

            if (employeeEntity == null)
                return false;

            _context.Remove(employeeEntity);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
