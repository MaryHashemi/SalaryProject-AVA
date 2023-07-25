using Microsoft.EntityFrameworkCore;
using SalaryProject.DAL.EFCore.Factories;
using SalaryProject.Domain.DataTransferObjects;
using SalaryProject.Domain.Extensions;
using SalaryProject.Domain.Interfaces;
using SalaryProject.Domain.Models;

namespace SalaryProject.DAL.EFCore.Repositores
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly SalaryDbContextFactory _dbContextFactory;

        public EmployeeRepository(SalaryDbContextFactory dbContextFactory)
        {
            this._dbContextFactory = dbContextFactory;
        }
        public async Task<HashSet<EmployeeDto>> Get(SearchEmployee Dto)
        {
            using var _context = _dbContextFactory.CreateDbContext();

            var employees = await _context.Employees
                .Where(e => e.SalaryDate.Year == Dto.SalaryDateYear && e.SalaryDate.Month == Dto.SalaryDateMonth && e.FirstName.Trim().ToLower()==Dto.FirstName.Trim().ToLower() && e.LastName.Trim().ToLower() == Dto.LastName.Trim().ToLower())
                .AsNoTracking().ToListAsync();

            HashSet<EmployeeDto> employeeDtoHashSet = new();

            foreach (Employee? employee in employees)
            {
                EmployeeDto employeeDto = EmployeeExtensions.ToEmployeeDto(employee);
                employeeDtoHashSet.Add(employeeDto);
            }

            return employeeDtoHashSet;

        }

        public async Task<HashSet<EmployeeDto>> GetRange(SearchRangeEmployee searchRange)
        {
            using var _context = _dbContextFactory.CreateDbContext();
            var employeesInRange = await _context.Employees
                .Where(e => e.SalaryDate >= DateTime.Parse($"{searchRange.StartSalaryDateYear}-{searchRange.StartSalaryDateMonth}-01") && e.SalaryDate <= DateTime.Parse($"{searchRange.EndSalaryDateYear}-{searchRange.EndSalaryDateMonth}-01") && e.FirstName.Trim().ToLower() == searchRange.FirstName.Trim().ToLower() && e.LastName.Trim().ToLower() == searchRange.LastName.Trim().ToLower())
                .ToListAsync();
            HashSet<EmployeeDto> employeeDtoHashSet = new();
            foreach (Employee? employee in employeesInRange)
            {
                EmployeeDto employeeDto = EmployeeExtensions.ToEmployeeDto(employee);
                employeeDtoHashSet.Add(employeeDto);
            }
            return employeeDtoHashSet;
        }

        public async Task Add(CreateEmployee create)
        {
            using var _context = _dbContextFactory.CreateDbContext();
            Employee employee = EmployeeExtensions.ToEmployee(create);
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            using var _context = _dbContextFactory.CreateDbContext();
            _context.Employees.Remove(new Employee()
            {
                Id = id
            });
            await _context.SaveChangesAsync();
        }

        public async Task Update(UpdateEmployee update)
        {
            using var _context = _dbContextFactory.CreateDbContext();
            Employee? oldEmployee = await _context.Employees.SingleOrDefaultAsync(x => x.Id == update.Id);

            if (oldEmployee is not null)
            {
                oldEmployee.Id = update.Id;
                oldEmployee.FirstName = update.FirstName;
                oldEmployee.LastName = update.LastName;
                oldEmployee.DateOfBirth = DateTime.Parse(update.DateOfBirth.ToString());
                oldEmployee.BasicSalary = update.BasicSalary;
                oldEmployee.AttractionRight = update.AttractionRight;
                oldEmployee.CommutingRight = update.CommutingRight;
                oldEmployee.OvertimeAmount = update.OvertimePaymentAmount;
                oldEmployee.SalaryDate = DateTime.Parse($"{update.SalaryDateYear}-{update.SalaryDateMonth}-01");

                await _context.SaveChangesAsync();
            }
            else
                throw new ArgumentException("Employee Not Found");
        }
    }
}
