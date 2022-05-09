using MovieLibrary.Context;
using MovieLibrary.DataModels;

namespace MovieLibrary
{
    internal class AddRatings : IAddRatings
    {
        public void AddNewRating(MovieContext context) 
        {
            MovieUtility movieUtility = new MovieUtility();
            UserMovie userMovie = new UserMovie();
            userMovie.User = GetSingleUser(context);
            userMovie.Movie = movieUtility.FindSingleMovie(context);
            userMovie.Rating = GetRating();
            userMovie.RatedAt = DateTime.Now;
            context.Add(userMovie);
            context.SaveChanges();
        }

        private User GetSingleUser(MovieContext context) 
        {
            Console.WriteLine("Enter the ID of the user who is giving the rating");
            string input = Console.ReadLine();
            int number = 0;
            string foundUser = "";
            var user = context.Users.Where(x => x.Id == number)
                .FirstOrDefault();
            while (foundUser != "1") 
            {
                while (!int.TryParse(input, out number)) 
                {
                    Console.WriteLine("The input was invlaid please try again");
                    input = Console.ReadLine();
                }
                user = context.Users.Where(x => x.Id == number)
                    .FirstOrDefault();
                if (user != null)
                {
                    Console.WriteLine($"Are you looking for the user with the id {user.Id}, the age {user.Age}, " +
                        $"gender is {user.Gender}, that has the zipcode {user.ZipCode}, and the occupation {user.Occupation.Name}?\n" +
                        $"Press 1 for yes and anything else to try again");
                    foundUser = Console.ReadLine();
                    if (foundUser != "1") 
                    {
                        Console.WriteLine("Enter the ID for the user again");
                        input = Console.ReadLine();
                    } 
                }
                else 
                { 
                    Console.WriteLine("We could not find the user please enter another ID");
                    input = Console.ReadLine();
                }
            }
            return user;
        }

        private long GetRating() 
        {
            Console.WriteLine("Enter the rating for the movie on a scale of 1-5 with 1 as the lowest and 5 as the higest");
            string input = Console.ReadLine();
            long number = 0;
            while (!long.TryParse(input, out number) || number < 1 || number > 5)
            {
                Console.WriteLine("The input was invalid please try again");
                input = Console.ReadLine();
            }
            return number;
        }
    }
}
