
using ASP_.NET_MVC_lab.Models.Validators;
using System.ComponentModel.DataAnnotations;

namespace ASP_.NET_MVC_lab.Models
{
    public class Course
    {
        [Key]
        public int Id { set; get; }
        //[MinLength(3, ErrorMessage = "min length is 3"), MaxLength(10, ErrorMessage = "Max length is 10")]
        [UniqueName]//Unique name
        public string Name { set; get; }
        //[MinLength(3, ErrorMessage = "min length is 3"), MaxLength(10, ErrorMessage = "Max length is 10")]
        public string Topic{ set; get; }
        [MoreThanMin]//always more than min degree
        public decimal Degree { set; get; }
        [Range(40,60, ErrorMessage ="min degree between 40 and 60")]
        public decimal MinDegree { set; get; }
        public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
        public ICollection<InstructorCourse> InstructorCourses { get; set; } = new HashSet<InstructorCourse>();

    }
}
