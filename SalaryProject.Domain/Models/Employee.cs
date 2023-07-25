namespace SalaryProject.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public double BasicSalary { get; set; }
        public double AttractionRight { get; set; }
        public double CommutingRight { get; set; }
        public double OvertimeAmount { get; set; }
        public DateTime SalaryDate { get; set; }
    }
}
