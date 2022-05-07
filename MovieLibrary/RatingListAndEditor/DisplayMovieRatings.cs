using MovieLibrary.Context;

namespace MovieLibrary
{
    internal class DisplayMovieRatings : IDisplayMovieRatings
    {
        public void DisplayRatings(MovieContext context) 
        { 
            MovieUtility movieUtility = new MovieUtility();
            Console.WriteLine("Find the movie you want to view the ratings for");
            var movie = movieUtility.FindSingleMovie(context);
            var movieRatings = context.UserMovies.Where(x => x.Movie == movie)
                .ToList();
            Console.WriteLine($"Here are all the ratings for {movie.Title}");
            foreach (var movieRating in movieRatings) 
            {
                Console.WriteLine($"The Rating information is:\n" +
                    $"The rating was {movieRating.Rating} out of 5 and was rated at {movieRating.RatedAt}\n" +
                    $"The User information is:\n" +
                    $"The age was {movieRating.User.Age} the gender is {movieRating.User.Gender} " +
                    $"the zipcode is {movieRating.User.ZipCode} and the occupation is {movieRating.User.Occupation.Name}\ns" +
                    $"------------------------------------------------------------------------------------------------------------------------------------");
            }
        }
    }
}
