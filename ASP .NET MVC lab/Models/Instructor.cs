using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_.NET_MVC_lab.Models
{
    public class Instructor
    {
        [Key]
        public int Id { get; set; }
        [MinLength(3, ErrorMessage = "min length is 3"), MaxLength(20, ErrorMessage = "max length is 20")]
        public string Name { get; set; }
        [Range(3000,12000, ErrorMessage = "Salary between 3000 and 12000")]
        public double Salary { get; set; }
        public string Image{ get; set; }
        [DataType(DataType.Date)]
        public DateOnly HiringDate { get; set; }
        [RegularExpression("[a-zA-Z]{3,20}", ErrorMessage = "Letters only and no more than 21")]
        public string Address { get; set; }
        public int DeptId { get; set; }
        [ForeignKey(nameof(DeptId))]
        [Display(Name="Department")]
        [ValidateNever]
        public Department Department { get; set; }
        //[ValidateNever]
        public ICollection<InstructorCourse> InstructorCourses = new HashSet<InstructorCourse>();

    }
}
