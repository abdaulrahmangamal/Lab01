using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_.NET_MVC_lab.Models
{
    public class Student
    {
        [Key]
        public int ssn          { get ; set; }
        [MinLength(3,ErrorMessage ="min length is 3"),MaxLength(20,ErrorMessage ="max length is 20") ]
        public string? name     { get ; set ; }
        [Range(18,50,ErrorMessage ="Age between 18-50")]
        public int? age         { get ; set; }
        public string? image    { get ; set; }
        [EmailAddress]
        public string? email    { get; set; }
        [RegularExpression("[a-zA-Z]{3,20}",ErrorMessage ="Must be letters only and less than 21")]
        public string? address  { get; set; }

        public int? DeptId { get; set; }
        [ForeignKey(nameof(DeptId))]
        [ValidateNever]
        public Department department { get; set; }
        [ValidateNever]
        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();

    }
}
