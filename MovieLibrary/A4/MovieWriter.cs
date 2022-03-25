namespace MovieLibrary
{
    public class MovieWriter : IMovieWriter
    {
        public string[] addMovies(String file, List<String[]> allMovies)
        {
            String movieLising = validateMovieToAdd(allMovies);
            int movieID = 1 + Convert.ToInt32(allMovies[allMovies.Count - 1][0]);
            String movieToAdd = String.Concat(movieID, ",", movieLising);
            StreamWriter sw = new StreamWriter(file, true);
            sw.WriteLine(movieToAdd);
            sw.Close();
            return movieToAdd.Split(",");
        }
        private String validateMovieToAdd(List<String[]> allMovies)
        {
            String movieTitle = getMovieName(allMovies);
            String allGenres = getGenre();
            return String.Concat(movieTitle, ",", allGenres);
        }

        private String getMovieName(List<String[]> allMovies)
        {
            Console.WriteLine("Enter the movie title and year for example: Toy Story (1995)");
            String movieTitle = Console.ReadLine();
            while (allMovies.Exists(x => x[1] == movieTitle) || movieTitle == String.Empty)
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
                }
            }
            return movieTitle;
        }

        private String getGenre()
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
            return String.Join('|', genres);
        }
    }
}