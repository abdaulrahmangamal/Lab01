using ASP_.NET_MVC_lab.Context;
using NuGet.Protocol;
using System.ComponentModel.DataAnnotations;

namespace ASP_.NET_MVC_lab.Models.Validators
{
    public class MoreThanMinAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var n1 = value as decimal?;
            var obj = validationContext.ObjectInstance as Course;
            //SchoolContext scontext = new SchoolContext();

            if (n1 > obj.MinDegree)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Degree Less than min degree");

            }
        }
    }
}
