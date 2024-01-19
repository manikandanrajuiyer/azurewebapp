using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ManiWebApp.Models
{
    public class EmployeeModel
    {
        [Required(ErrorMessage = "Employee Name Mandatory")]
        [StringLength(maximumLength:50, ErrorMessage ="Max Length 50")]
        [DisplayName("Employee Name")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "DOB Mandatory")]
        [DataType(DataType.Date)]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Address mandatory")]
        [StringLength(maximumLength: 50, ErrorMessage = "Max Length 2")]
        public string Address { get; set; }

        [Required(ErrorMessage = "State mandatory")]
        public string State { get; set; }
    }
}
