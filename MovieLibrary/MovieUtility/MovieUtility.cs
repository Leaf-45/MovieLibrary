using MovieLibrary.Context;
using MovieLibrary.DataModels;

namespace MovieLibrary
{
    public class MovieUtility
    {
        public Occupation getOccupation(MovieContext context)
        {
            foreach (var occupations in context.Occupations) Console.WriteLine(occupations.Name);
            Console.WriteLine("Select the user's occupation");
            var occupation = context.Occupations.Where(x => x.Name.ToLower().Contains(Console.ReadLine().ToLower()))
                .FirstOrDefault();
            while (true)
            {
                if (occupation != null)
                {
                    Console.WriteLine($"Did you mean {occupation.Name}?\nPress 1 for yes and anything else to say no");
                    string input = Console.ReadLine();
                    if (input != "1")
                    {
                        Console.WriteLine("Search for the occupation again");
                        occupation = context.Occupations.Where(x => x.Name.ToLower().Contains(Console.ReadLine().ToLower()))
                            .FirstOrDefault();
                    }
                    else break;
                }
                else
                {
                    Console.WriteLine("We did not find the occupation please try again");
                    occupation = context.Occupations.Where(x => x.Name.ToLower().Contains(Console.ReadLine().ToLower()))
                        .FirstOrDefault();
                }
            }
            return occupation;
        }
        public Movie FindSingleMovie(MovieContext context) 
        {
            string response = "";
            Movie movie = null;
            while (response != "1")
            {
                Console.WriteLine("Enter the name of the movie you want");
                var query = context.Movies.Where(x => x.Title.ToLower().Contains(Console.ReadLine().ToLower()));
                if (query == null) Console.WriteLine("No movies were found");
                else
                {
                    foreach (var item in query)
                    {
                        Console.WriteLine($"Did you mean {item.Title}?\nPress 1 for yes\nPress 2 to search again from scratch\n" +
                            $"Press anything else to keep scrolling");
                        response = Console.ReadLine();
                        if (response == "1")
                        {
                            movie = item;
                            break;
                        }
                        if (response == "2") break;
                    }
                }
            }
            return movie;
        }

        public int ValidateNumberOfEntriesToDisplay()
        {
            Console.WriteLine("Enter the number of entries you would like to see at a time 1-500");
            string input = Console.ReadLine();
            int number = 0;
            while (!int.TryParse(input, out number) || number < 1 || number > 501)
            {
                Console.WriteLine("The input was invalid please try again");
                input = Console.ReadLine();
            }
            return number;
        }

        public string SetMovieTitle(MovieContext context)
        {
            Console.WriteLine("Enter the movie's title alongside the year for example: Toy Story (1995)");
            string title = Console.ReadLine();

            var dublicateSearch = context.Movies.Where(x => x.Title == title)
                .FirstOrDefault();

            while (string.IsNullOrEmpty(title) || dublicateSearch != null)
            {
                Console.WriteLine("The input was invalid or the movie was already in the movie library");
                title = Console.ReadLine();
                dublicateSearch = context.Movies.Where(x => x.Title == title)
                    .FirstOrDefault();
            }
            return title;
        }


        public DateTime SetReleaseDate()
        {
            bool validReleaseDate = DateTime.TryParse(AskForDate(), out DateTime releaseDate);
            while (!validReleaseDate)
            {
                Console.WriteLine("The date entered was not valid");
                validReleaseDate = DateTime.TryParse(AskForDate(), out releaseDate);
            }
            return releaseDate;
        }

        public string AskForDate()
        {
            Console.WriteLine("Enter the year");
            string year = Console.ReadLine();
            Console.WriteLine("Enter the month 1-12");
            string month = Console.ReadLine();
            Console.WriteLine("Enter the day 1-31");
            string day = Console.ReadLine();
            return $"{year}/{month}/{day}";
        }

        public void SetMovieGenres(Movie movie, MovieContext context)
        {
            string addNewGenre = "";
            List<Genre> alreadyAddedGenres = new List<Genre>();
            while (addNewGenre != "1")
            {
                MovieGenre genres = new MovieGenre();
                genres.Movie = movie;
                Console.WriteLine("Enter the genre's name from one of these genres");
                foreach (var genre in context.Genres) Console.WriteLine(genre.Name);
                Genre query = null;
                string correctGenre = "";
                while (query == null || correctGenre != "1")
                {
                    query = context.Genres.Where(x => x.Name.ToLower().Contains(Console.ReadLine().ToLower()))
                        .FirstOrDefault();
                    if (query == null)
                    {
                        Console.WriteLine("The genre wasn't found please try again");
                        query = context.Genres.Where(x => x.Name.ToLower().Contains(Console.ReadLine().ToLower()))
                            .FirstOrDefault();
                    }
                    else
                    {
                        Console.WriteLine($"Is {query.Name} correct?\nPress 1 for yes or anything else to try again");
                        correctGenre = Console.ReadLine();
                        if (correctGenre != "1") Console.WriteLine("Please enter the genre again");
                    }
                }
                genres.Genre = query;
                var alreadyAddedCheck = alreadyAddedGenres.Where(x => x.Name == genres.Genre.Name);
                if (alreadyAddedCheck.Count() == 0)
                {
                    context.MovieGenres.Add(genres);
                    alreadyAddedGenres.Add(genres.Genre);
                }
                else Console.WriteLine("That genre was already added");
                Console.WriteLine("Press 1 to be done\nPress anything else enter another genre");
                addNewGenre = Console.ReadLine();
            }
        }
    }
}
