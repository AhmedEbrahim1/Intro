using System.ComponentModel.DataAnnotations;

namespace Intro.Models
{
    public class User
    {
        public string? UserName { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }

    }
}
