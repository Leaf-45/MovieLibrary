using MovieLibrary.Context;

namespace MovieLibrary
{
    internal interface IMovieUpdater
    {
        void UpdateMovie(MovieContext context);
    }
}
