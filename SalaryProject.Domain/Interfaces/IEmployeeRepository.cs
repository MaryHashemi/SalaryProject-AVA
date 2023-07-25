using SalaryProject.Domain.DataTransferObjects;

namespace SalaryProject.Domain.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<HashSet<EmployeeDto>> Get(SearchEmployee employeeDto);
        Task<HashSet<EmployeeDto>> GetRange(SearchRangeEmployee searchDto);
        Task Add(CreateEmployee create);
        Task Update(UpdateEmployee employeeDto);
        Task Delete(int id);
    }
}
