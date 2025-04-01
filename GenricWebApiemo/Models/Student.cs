using System.ComponentModel.DataAnnotations;

namespace GenricWebApiemo.Models
{
    public class Student
    {
       
        public int Id { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Grade { get; set; }
        
    }
}
