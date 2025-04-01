using System.ComponentModel.DataAnnotations;

namespace Generics.ModelFolder
{
    public class StudentModel
    {
        [Key]
        public int Stid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
