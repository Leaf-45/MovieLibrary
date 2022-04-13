using MovieLibrary.Context;
using MovieLibrary.DataModels;

namespace MovieLibrary
{
    public class MovieDeleter : IMovieDeleter
    {
        public void DeleteMovie(MovieContext context)
        {
            MovieUtility movieUtility = new MovieUtility();
            Movie movie = movieUtility.FindSingleMovie(context);
            Console.WriteLine($"Type in 'yes' if you are sure you want to delete {movie.Title} " +
                $"if you do not you will be brought back to the main menu");
            if (Console.ReadLine() == "yes") 
            {
                var genres = context.MovieGenres.Where(x => x.Movie.Id == movie.Id);
                foreach (var genre in genres) context.MovieGenres.Remove(genre);
                context.Movies.Remove(movie);
                context.SaveChanges();
                Console.WriteLine($"{movie.Title} has been deleted");
            }
        }
    }
}
