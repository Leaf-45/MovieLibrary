using MovieLibrary.Context;

namespace MovieLibrary
{
    internal class GetTopRatedMovie : IGetTopRatedMovie
    {
        public void DisplayByAge(MovieContext context)
        {
            int range = getRange();
            var query = context.UserMovies.Where(x => x.User.Age >= range && x.User.Age <= range + 10)
                .OrderByDescending(x => x.Rating)
                .ThenBy(x => x.Movie.Title);
            int numberOfRatings = query.Count();
            var topRated = query.FirstOrDefault();
            if (topRated != null) 
            {
                Console.WriteLine($"The top rated movie for those in the age range of {range}-{range + 10} is:\n" +
                $"{topRated.Movie.Title} with a rating of {topRated.Rating} out of 5\n" +
                $"people in the age range {range}-{range + 10} gave the movie this rating {numberOfRatings} times");
            }
            else Console.WriteLine("No information could not be found");
        }

        public void DisplayByOccupation(MovieContext context)
        {
            Console.WriteLine("Look for the occupation you want to find the top rated movie for");
            MovieUtility movieUtility = new MovieUtility();
            var occupation = movieUtility.getOccupation(context);
            var query = context.UserMovies.Where(x => x.User.Occupation == occupation)
                .OrderByDescending(x => x.Rating)
                .ThenBy(x => x.Movie.Title);
            int numberOfRatings = query.Count();
            var topRated = query.FirstOrDefault();
            if (topRated != null)
            {
                Console.WriteLine($"The top rated movie for {occupation.Name}s is:\n" +
                $"{topRated.Movie.Title} with a rating of {topRated.Rating} out of 5\n" +
                $"{occupation.Name}s gave the movie this rating {numberOfRatings} times");
            }
            else Console.WriteLine("That's odd the information could not be found");
        }

        private int getRange() 
        {
            Console.WriteLine("Enter the starting number of the age range you want for example\n" +
                "Enter 1 to get the age range 1-11 and 6 for the age range 6-16");
            string input = Console.ReadLine();
            int number = 0;
            while (!int.TryParse(input, out number) || number < 1 || number > 111)
            {
                Console.WriteLine("The number was invalid please try again");
                input = Console.ReadLine();
            }
            return number;
        }
    }
}
