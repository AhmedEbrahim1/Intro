using Intro.CustomAtt;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intro.Models
{
    [ModelMetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
    }


    public class EmployeeMetaData
    {
        public int Id { get; set; }

        [DisplayName("Employe Name ")]
        [Required(ErrorMessage = "This Field can't be null")]
        [MinLength(3)]
        [MaxLength(10)]
        [UniqueName]
        public string Nam { get; set; }

        //Custom ==> Client Side Validation 
        [Remote(action: "ChekAgeAndName", controller: "Emolyee", AdditionalFields = "Nam", ErrorMessage = "Age Must Be More than 40")]
        public int Age { get; set; }

        [RegularExpression(@"\w+-\w+", ErrorMessage = "Please Enter Valid Address Like this Example : Cairo-NasrCity ")] //Cairo-NasrCity
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int? Dept_Id { get; set; }

        public virtual Department? Department { get; set; }


    }

}
