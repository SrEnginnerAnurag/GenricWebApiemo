using System.ComponentModel.DataAnnotations;

namespace MainGenericsDemoProject.ModelFolder
{
    public class StudentModel
    {
        [Key]
        public int stId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
    }
}
