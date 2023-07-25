using System.ComponentModel.DataAnnotations;

namespace SalaryProject.Domain.DataTransferObjects
{
    public class SearchEmployee
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [Range(1950, 2050)]
        public int SalaryDateYear { get; set; }
        [Required]
        [Range(1, 12)]
        public int SalaryDateMonth { get; set; }
    }
}
