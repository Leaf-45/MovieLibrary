using MovieLibrary.Context;
using MovieLibrary.DataModels;

namespace MovieLibrary
{
    internal class MovieSearch : IMovieSearch
    {
        public void Search(MovieContext movies) 
        {
            Console.WriteLine("Type in the movie you are searching for");
            string response = Console.ReadLine();
            var query = movies.Movies.Where(x => x.Title.ToLower().Contains(response.ToLower())).ToList();
            int matches = query.Count();
            if (matches != 0)
            {
                Console.WriteLine($"There were {matches} matche(s)");

                foreach (var movie in query) 
                {
                    Console.WriteLine($"The movie's ID is: {movie.Id} The movie's title is: {movie.Title} " +
                        $"The movie's release date is: {movie.ReleaseDate}\n");
                    string output = "";
                    foreach (var genre in movie.MovieGenres)  output += $"{genre.Genre.Name}|";
                    if (output != "") Console.Write($"The genre(s) are: {output.Substring(0, output.Length - 1)}\n");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------");
                } 
                Console.WriteLine();
            }
            else Console.WriteLine("Could not find movie");
        }
    }
}
