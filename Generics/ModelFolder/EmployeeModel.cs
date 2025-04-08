using System.ComponentModel.DataAnnotations;

namespace Generics.ModelFolder
{
    public class EmployeeModel
    {
        [Key] //Entity Framework (EF) with Auto-increment (Primary Key): Jab aap Entity Framework ke saath data model bana rahe hote hain, toh agar aap ID field ko primary key (PK) bana dete hain, toh wo automatically auto-increment ho jata hai (yeh by default hota hai).
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpCompanyName { get; set; }
        public string EmpEmail { get; set; }
    }
}
