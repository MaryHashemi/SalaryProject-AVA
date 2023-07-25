namespace SalaryProject.Domain.DataTransferObjects
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public double BasicSalary { get; set; }
        public double AttractionRight { get; set; }
        public double CommutingRight { get; set; }
        public double OvertimePaymentAmount { get; set; }
        public DateOnly SalaryDate { get; set; }
    }
}
