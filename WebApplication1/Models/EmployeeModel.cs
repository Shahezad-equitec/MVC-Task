using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Name is Required")]
        public string names { get; set; }
        [Required(ErrorMessage ="Designation is Required")]
        public string Designation {  get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Email Is Not Valid")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is Required")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Phone Number is Invalid")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Invalid mobile number")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Salary is Required")]
        public int Salary { get; set; }
    }
}