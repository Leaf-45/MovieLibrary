using MovieLibrary.Context;
using MovieLibrary.DataModels;

namespace MovieLibrary
{
    public class MovieUpdater : IMovieUpdater
    {
        public void UpdateMovie(MovieContext context)
        {
            MovieUtility movieUtility = new MovieUtility();
            Movie movie = movieUtility.FindSingleMovie(context);
            movie.Title = movieUtility.SetMovieTitle(context);
            movie.ReleaseDate = movieUtility.SetReleaseDate();
            var genres = context.MovieGenres.Where(x => x.Movie.Id == movie.Id);
            foreach (var genre in genres) context.MovieGenres.Remove(genre);
            movieUtility.SetMovieGenres(movie, context);
            context.Update(movie);
            context.SaveChanges();
        }
    }
}
