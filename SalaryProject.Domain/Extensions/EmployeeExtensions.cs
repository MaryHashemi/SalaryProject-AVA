using SalaryProject.Domain.DataTransferObjects;
using SalaryProject.Domain.Models;

namespace SalaryProject.Domain.Extensions
{
    public static class EmployeeExtensions
    {
        public static Employee ToEmployee(this EmployeeDto dto)
        {
            return new Employee
            {
                Id = dto.Id,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                DateOfBirth = DateTime.Parse(dto.DateOfBirth.ToString()),
                BasicSalary = dto.BasicSalary,
                AttractionRight = dto.AttractionRight,
                CommutingRight = dto.CommutingRight,
                OvertimeAmount = dto.OvertimePaymentAmount,
                SalaryDate = DateTime.Parse(dto.SalaryDate.ToString())
            };
        }

        public static Employee ToEmployee(this CreateEmployee create)
        {
            return new Employee
            {
                FirstName = create.FirstName,
                LastName = create.LastName,
                DateOfBirth = DateTime.Parse(create.DateOfBirth.ToString()),
                BasicSalary = create.BasicSalary,
                AttractionRight = create.AttractionRight,
                CommutingRight = create.CommutingRight,
                OvertimeAmount = create.OvertimePaymentAmount,
                SalaryDate = DateTime.Parse($"{create.SalaryYearDate}-{create.SalaryMonthDate}-01")
            };
        }

        public static EmployeeDto ToEmployeeDto(this Employee employee)
        {
            return new EmployeeDto
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                DateOfBirth = DateOnly.FromDateTime(employee.DateOfBirth),
                BasicSalary = employee.BasicSalary,
                AttractionRight = employee.AttractionRight,
                CommutingRight = employee.CommutingRight,
                OvertimePaymentAmount = employee.OvertimeAmount,
                SalaryDate = DateOnly.FromDateTime(employee.SalaryDate),
            };
        }
    }
}
