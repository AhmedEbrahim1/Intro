using System.ComponentModel.DataAnnotations;

namespace Intro.ViewModel
{
    public class AddRoleVM
    {
        [Required]
        public string RoleName { get; set; }
    }
}
