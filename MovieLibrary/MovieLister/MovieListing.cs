using MovieLibrary.Context;

namespace MovieLibrary.MovieLister
{
    internal class MovieListing : IMovieListing
    {
        public void ListAllMovies(MovieContext context) 
        {
            MovieUtility movieUtility = new MovieUtility();
            int number = movieUtility.ValidateNumberOfEntriesToDisplay();
            int howManyListed = 0;
            var listing = context.Movies.Skip(howManyListed).Take(number).ToList();

            string input = "";
            while (input != "1")  
            {
                if (listing.Count() <= 0) break;
                foreach (var movie in listing)
                {
                    Console.WriteLine($"The movie's ID is: {movie.Id} The movie's title is: {movie.Title} " +
                        $"The movie's release date is: {movie.ReleaseDate}\n");
                    string output = "";
                    foreach (var genre in movie.MovieGenres) output += $"{genre.Genre.Name}|";
                    if (output != "") Console.Write($"The genre(s) are: {output.Substring(0, output.Length - 1)}\n");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------------------------------------");
                }
                howManyListed += number;
                listing = context.Movies.Skip(howManyListed).Take(number).ToList();
                Console.WriteLine("Press 1 to exit or anything else to continue");
                input = Console.ReadLine();
            }
        }
    }
}
