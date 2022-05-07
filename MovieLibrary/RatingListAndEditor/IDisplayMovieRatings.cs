using MovieLibrary.Context;

namespace MovieLibrary
{
    internal interface IDisplayMovieRatings
    {
        public void DisplayRatings(MovieContext context);
    }
}
