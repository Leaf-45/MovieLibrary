using MovieLibrary.Context;

namespace MovieLibrary
{
    internal interface IMovieWriter
    {
        void AddMovie(MovieContext context);
    }
}
