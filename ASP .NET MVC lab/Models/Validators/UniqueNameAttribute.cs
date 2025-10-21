using ASP_.NET_MVC_lab.Context;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ASP_.NET_MVC_lab.Models.Validators
{
    public class UniqueNameAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var obj = validationContext.ObjectInstance as Course;
            var name = value as string;
            SchoolContext scontext = new SchoolContext();
            if(scontext.courses.FirstOrDefault(m => m.Name == name && m.Id ==obj.Id) is not null)
            {
                return ValidationResult.Success;
            }
            else if (scontext.courses.FirstOrDefault(m => m.Name == name && m.Id != obj.Id)is not null)
            {
                return new ValidationResult("Name exists");
            }
            else
            return ValidationResult.Success;
            //return base.IsValid(value, validationContext);
        }
    }
}
