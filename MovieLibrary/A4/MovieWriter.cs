using Newtonsoft.Json;

namespace MovieLibrary
{
    public class MovieWriter : IMovieWriter
    {
        public string addMovies(List<Movie> allMovies)
        {
            Media media = new Movie(getGenre());
            if (allMovies.Count > 0) 
            {
                Movie movie = allMovies[allMovies.Count - 1];
                media.ID = 1 + movie.ID;
            }
            else media.ID = 1;
            media.title = getMovieName(allMovies); 

            return JsonConvert.SerializeObject(media);
        }
        private String getMovieName(List<Movie> allMovies)
        {
            Console.WriteLine("Enter the movie title and year for example: Toy Story (1995)");
            String movieTitle = Console.ReadLine();
            List<Movie> duplicateList = allMovies.Where(m => m.title == movieTitle).ToList();
            while (duplicateList.Count > 0 || movieTitle == String.Empty)
            {
                if (movieTitle == String.Empty)
                {
                    Console.WriteLine("There was no input please try again");
                    Console.WriteLine("Enter the movie title and year for example: Toy Story (1995)");
                    movieTitle = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("That movie was already inputted please try another movie");
                    Console.WriteLine("Enter the movie title and year for example: Toy Story (1995)");
                    movieTitle = Console.ReadLine();
                    duplicateList = allMovies.Where(m => m.title == movieTitle).ToList();
                }
            }
            return movieTitle;
        }

        private String[] getGenre()
        {
            List<String> genres = new List<string>();
            String input = "";
            Console.WriteLine("Input all the genres associated with the movie one at a time and at least one genre must be inputted");
            Console.WriteLine("Press 1 to exit after one genre has been inputted");
            while (input != "1" || genres.Count == 0)
            {
                Console.WriteLine("Input a genre");
                input = Console.ReadLine();
                while (input == String.Empty)
                {
                    Console.WriteLine("There was nothing put in please entering the genre again");
                    input = Console.ReadLine();
                }
                if (input != "1")
                {
                    genres.Add(input);
                }
            }
            return genres.ToArray();
        }
    }
}
