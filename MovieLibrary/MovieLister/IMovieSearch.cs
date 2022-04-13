using MovieLibrary.DataModels;

namespace MovieLibrary
{
    internal interface IMovieSearch
    {
        void Search(List<Movie> movies);
    }
}
