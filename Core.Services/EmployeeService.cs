using AutoMapper;
using Core.Interfaces.Repository;
using Core.Interfaces.Service;
using Infrastructure.Data.DTO;
using Infrastructure.Data.Entities;

namespace Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeDTO>> GetAllEmployees(CancellationToken token = default)
        {
            List<EmployeeEntity> employeesEntities = await _employeeRepository.GetAllEmployees(token);

            List<EmployeeDTO> employeeDtos = _mapper.Map<List<EmployeeDTO>>(employeesEntities);

            return employeeDtos;
        }

        public async Task<EmployeeDTO> GetEmployeeById(string employeeId, CancellationToken token = default)
        {
            EmployeeEntity result = await _employeeRepository.GetEmployeeById(int.Parse(employeeId), token);

            EmployeeDTO employeeDTO = _mapper.Map<EmployeeDTO>(result);

            return employeeDTO;
        }

        public async Task<int> CreateEmployee(EmployeeDTO newEmployee)
        {
            EmployeeEntity employeeToCreate = _mapper.Map<EmployeeEntity>(newEmployee);

            int employeeId = await _employeeRepository.CreateEmployee(employeeToCreate);

            return employeeId;
        }

        public async Task<EmployeeDTO> UpdateEmployee(string employeeId, EmployeeDTO request)
        {
            EmployeeEntity updatedEmployee = await _employeeRepository.UpdateEmployee(employeeId, request);

            EmployeeDTO mappedEmployee = _mapper.Map<EmployeeDTO>(updatedEmployee);

            return mappedEmployee;
        }

        public async Task<bool> DeleteEmployee(string employeeId)
        {
            bool hasEntityBeenDeleted = await _employeeRepository.DeleteEmployeeById(int.Parse(employeeId));

            return hasEntityBeenDeleted;
        }
    }
}
