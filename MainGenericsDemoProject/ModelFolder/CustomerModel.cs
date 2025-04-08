using System.ComponentModel.DataAnnotations;

namespace MainGenericsDemoProject.ModelFolder
{
    public class CustomerModel
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public string EmpEmail { get; set; }
    }
}
