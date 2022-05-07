using MovieLibrary.Context;

namespace MovieLibrary
{
    internal interface IAddRatings
    {
        void AddNewRating(MovieContext context);
    }
}
