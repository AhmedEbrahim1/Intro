using Intro.CustomAtt;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Intro.Models
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Nam { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        [ForeignKey("Department")]
        public int? Dept_Id { get; set; }
        public virtual Department? Department { get; set; }
    }
}
