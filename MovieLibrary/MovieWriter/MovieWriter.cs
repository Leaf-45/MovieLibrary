using MovieLibrary.Context;
using MovieLibrary.DataModels;

namespace MovieLibrary
{
    public class MovieWriter : IMovieWriter
    {
        public void AddMovie(MovieContext context)
        {
            MovieUtility movieUtility = new MovieUtility();
            Movie movie = new Movie();
            movie.Title = movieUtility.SetMovieTitle(context);
            movie.ReleaseDate = movieUtility.SetReleaseDate();
            movieUtility.SetMovieGenres(movie, context);
            context.Add(movie);
            context.SaveChanges();
        }
    }
}