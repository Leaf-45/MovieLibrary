using MovieLibrary.Context;

namespace MovieLibrary.MovieLister
{
    internal interface IMovieListing
    {
        void ListAllMovies(MovieContext context);
    }
}
