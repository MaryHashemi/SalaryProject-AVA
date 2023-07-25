using Microsoft.AspNetCore.Mvc;
using SalaryProject.Domain.DataTransferObjects;
using SalaryProject.Domain.Enums;
using SalaryProject.Domain.Interfaces;
using SalaryProject.UI.API.Utilities;
using System.ComponentModel.DataAnnotations;

namespace SalaryProject.UI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeeRepository employeeRepository, ILogger<EmployeeController> logger)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] SearchEmployee searchDto)
        {
            try
            {
                var employees = await _employeeRepository.Get(searchDto);
                return employees.Count > 0 ? Ok(employees) : NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("GetRange")]
        public async Task<IActionResult> GetEmployeesInRange([FromQuery] SearchRangeEmployee searchDto)
        {
            try
            {
                var employees = await _employeeRepository.GetRange(searchDto);
                return employees.Count > 0 ? Ok(employees) : NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([Required][FromBody] CreateEmployee create, [Required][FromQuery] SalaryEnum.CalculatorType calculatorType)
        {
            try
            {
                create.OvertimePaymentAmount = OvertimeCalculatorService.OverTimeCalculator(calculatorType, create.OvertimeAmount, create.BasicSalary, create.AttractionRight, create.CommutingRight);
                await _employeeRepository.Add(create);
                _logger.LogInformation($"{create.FirstName} {create.LastName} added successfully.");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([Required][FromBody] UpdateEmployee update, [Required][FromQuery] SalaryEnum.CalculatorType calculatorType)
        {
            try
            {
                update.OvertimePaymentAmount= OvertimeCalculatorService.OverTimeCalculator(calculatorType, update.OvertimeAmount, update.BasicSalary, update.AttractionRight, update.CommutingRight);
                await _employeeRepository.Update(update);
                _logger.LogInformation($"{update.FirstName} {update.LastName} updated successfully.");
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete([Required][FromQuery] int id)
        {
            try
            {
                await _employeeRepository.Delete(id);
                _logger.LogInformation("Employee deleted successfully.");
                return Ok();
            }
            catch (ArgumentException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
