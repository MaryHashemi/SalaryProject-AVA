using System.ComponentModel.DataAnnotations;

namespace SalaryProject.Domain.DataTransferObjects
{
    public class SearchRangeEmployee
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [Range(1950, 2050)]
        public int StartSalaryDateYear { get; set; }
        [Required]
        [Range(1, 12)]
        public int StartSalaryDateMonth { get; set; }
        [Required]
        [Range(1950, 2050)]
        public int EndSalaryDateYear { get; set; }
        [Required]
        [Range(1, 12)]
        public int EndSalaryDateMonth { get; set; }
    }
}
