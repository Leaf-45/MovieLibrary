using MovieLibrary.Context;

namespace MovieLibrary
{
    internal class DisplayUsers : IDisplayUser
    {
        public void DisplayUser(MovieContext context)
        {
            MovieUtility movieUtility = new MovieUtility();
            int number = movieUtility.ValidateNumberOfEntriesToDisplay();
            int howManyListed = 0;
            var listing = context.Users.Skip(howManyListed).Take(number).ToList();

            string input = "";
            while (input != "1") 
            {
                if (listing.Count() <= 0) break;
                foreach (var user in listing) Console.WriteLine($"The user's ID is: {user.Id} " +
                    $"the user's age is: {user.Age} the user's gender is: {user.Gender} the user's zipcode is: {user.ZipCode}" +
                    $" the user's occupation is: {user.Occupation.Name}\n" +
                    $"------------------------------------------------------------------------------------------------------------------------------------");
                howManyListed += number;
                listing = context.Users.Skip(howManyListed).Take(number).ToList();
                Console.WriteLine("Press 1 to exit or anything else to continue");
                input = Console.ReadLine();
            }
        }
    }
}
