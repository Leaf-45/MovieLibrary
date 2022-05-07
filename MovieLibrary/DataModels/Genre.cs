using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.DataModels
{
    public class Genre
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<MovieGenre> MovieGenres {get;set;}
    }
}
