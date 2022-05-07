using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.DataModels
{
    public class Occupation
    {
        [Key]
        public long Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
    }
}
