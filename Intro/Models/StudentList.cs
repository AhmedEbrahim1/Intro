using Microsoft.AspNetCore.Identity;

namespace Intro.Models
{
    public static class StudentList
    {
        public static List<Student> Students { get; set; } = new List<Student>();
        static StudentList()
        {
            Students = new List<Student>()
            {
                new Student(){Id=1,Name="Ali",Level=1,Address="Alex",Image="2.JPG"},
                new Student(){Id=2,Name="Ahmed",Level=2,Address="Cairo",Image="2.JPG"},
                new Student(){Id=3,Name="Mona",Level=1,Address="Cairo",Image="1.JPG"},
                new Student(){Id=4,Name="Aliaa",Level=2,Address="Alex",Image="1.JPG"},
            };
        }


    }
}
