using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Core_EF.Models
{

    public  enum Status
    {
        Undergraduate,Postgraduate,PhD,Suspended
    }
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is Required.")]
        
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last Name is Required.")]
        public string LastName { get; set; }
        [DisplayName("Date of Birth")]
        [Required(ErrorMessage = "Date of Birth is Required.")]
        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        [DisplayName("Gender")]
        public int? GenderId { get; set; }
        [DataType(DataType.Date)]
        [DisplayName("Registration Date")]
        [Required(ErrorMessage = "Registration Date is Required.")]
        public DateTime RegistrationDate { get; set; }
        [DisplayFormat(NullDisplayText ="No Status")]
        [Required(ErrorMessage = "Status is Required.")]

        public Status? Status { get; set; }

        public Gender genders { get; set; }

       

        public ICollection<Enrollment> enrollments { get; set; } 

    }

}
