using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.DataModels
{
    public class MovieGenre
    {
        [Key]
        public int Id {get;set;}
        [Required]
        public virtual Movie Movie { get; set; }
        [Required]
        public virtual Genre Genre { get; set; }
    }
}
