using Intro.Models;
using System.ComponentModel.DataAnnotations;

namespace Intro.CustomAtt
{
    public class UniqueNameAttribute : ValidationAttribute
    {

        //public UniqueNameAttribute()
        //{
        //    ErrorMessage = "Any Message";
        //}
        //public override bool IsValid(object? value)//Ahmed
        //{
        //    RwadMisrConext context = new RwadMisrConext();
        //    var emp = context.Employees.FirstOrDefault(e => e.Nam == value.ToString()); // No Ahmed (null)
        //    return emp is null ? true : false; 
        //}

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //obj from user form ==> validationContext

            var userObject = (Employee)validationContext.ObjectInstance;

            RwadMisrConext context = new RwadMisrConext();
            var DbObject = context.Employees.FirstOrDefault(e => e.Nam == userObject.Nam.ToString());

            if (DbObject is null)
                return ValidationResult.Success;
            else
                return new ValidationResult("Name must be Unique");

        }


    }
}
