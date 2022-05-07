using MovieLibrary.Context;

namespace MovieLibrary
{
    internal interface IGetTopRatedMovie
    {
        void DisplayByAge(MovieContext context);
        void DisplayByOccupation(MovieContext context);
    }
}
