using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.DataModels
{
    public class UserMovie
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long Rating {get;set;}
        [Required]
        public DateTime RatedAt { get; set; }
        [Required]
        public virtual User User { get; set; }
        [Required]
        public virtual Movie Movie { get; set; }

    }
}
