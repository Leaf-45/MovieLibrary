using MovieLibrary.Context;

namespace MovieLibrary
{
    internal interface IMovieSearch
    {
        void Search(MovieContext movies);
    }
}
