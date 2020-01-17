using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ASP_Core_EF.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        [Required(ErrorMessage ="Student is Required")]
        [DisplayName("Student Name")]
        public int? StudentId { get; set; }
        [Required(ErrorMessage = "Course is Required")]
        [DisplayName("Course Name")]
        public int? CourseId { get; set; }
        [Required(ErrorMessage = "Start Date is Required")]
        [DisplayName("Start Date")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End Date is Required")]
        [DisplayName("End Date")]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [DisplayFormat(NullDisplayText = "No grade")]
        [Required(ErrorMessage = "Grade is Required.")]
        public Grade? Grade { get; set; }

      [NotMapped]
            
    public ICollection <Student> Students { get; set;  }
        [ForeignKey("CourseId")]
        public Course courses { get; set; }
        [ForeignKey("StudentId")]
         public Student  students { get; set; }
        
    }
}
