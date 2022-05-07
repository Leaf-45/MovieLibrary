using System.ComponentModel.DataAnnotations;

namespace MovieLibrary.DataModels
{
    public class User
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [Range(0,121)]
        public long Age { get; set; }
        [Required]
        [StringLength(1)]
        public string Gender { get; set; }
        [Required]
        [StringLength(5)]
        public string ZipCode { get; set; }
        [Required]

        public virtual Occupation Occupation { get; set; }
        public virtual ICollection<UserMovie> UserMovies {get;set;}
    }
}
