using System.ComponentModel.DataAnnotations;

namespace GenericsApiDtoAndAutomapper.ModelFolder
{
    public class CochingModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
