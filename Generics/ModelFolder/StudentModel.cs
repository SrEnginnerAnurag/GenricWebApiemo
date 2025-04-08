using System.ComponentModel.DataAnnotations;

namespace Generics.ModelFolder
{
    public class StudentModel
    {
        [Key]   // Entity Framework (EF) with Auto-increment (Primary Key): Jab aap Entity Framework ke saath data model bana rahe hote hain, toh agar aap ID field ko primary key (PK) bana dete hain, toh wo automatically auto-increment ho jata hai (yeh by default hota hai).
        public int Stid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
