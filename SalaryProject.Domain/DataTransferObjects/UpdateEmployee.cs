using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SalaryProject.Domain.DataTransferObjects
{
    public class UpdateEmployee
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateOnly DateOfBirth { get; set; }
        [Required]
        public double BasicSalary { get; set; }
        public double AttractionRight { get; set; }
        public double CommutingRight { get; set; }
        public double OvertimeAmount { get; set; }
        [JsonIgnore]
        public double OvertimePaymentAmount { get; set; }
        [Required]
        [Range(1950, 2050)]
        public int SalaryDateYear { get; set; }
        [Required]
        [Range(1, 12)]
        public int SalaryDateMonth { get; set; }
    }
}
