namespace MovieLibrary
{
    public class Program
    {
        static void Main(String[] args)
        {
            String file = "ml-latest-small/movies.csv";
            askForAction(file);
        }

        public static void askForAction(String file)
        {
            String input = "";

            if (File.Exists(file))
            {
                List<string[]> entries = new List<string[]>();
                StreamReader sr = new StreamReader(file);
                while (!sr.EndOfStream)
                {
                    String line = sr.ReadLine();
                    entries.Add(line.Split(","));
                }
                sr.Close();

                while (input != "0")
                {
                    Console.WriteLine("Press 0 to exit, press 1 to view the movie list, press 2 to add to the move list");
                    input = Console.ReadLine();
                    if (input == "1")
                    {
                        listMovies(file);
                    }
                    if (input == "2")
                    {
                        addMovies(file, entries);
                    }
                }
            }
            else Console.WriteLine("The program is going to end as it is unable to locate the data for adding to and listing movies");
        }

        static int validateEntryforListing()
        {
            Console.WriteLine("How many movies would you like to list at a time? (1-1000)");
            String movies = Console.ReadLine();

            int count = 0;
            bool isANumber = Int32.TryParse(movies, out count);
            while (!isANumber || count < 1 || count > 1000)
            {
                Console.WriteLine("Please use a valid input (1-1000)");
                movies = Console.ReadLine();
                isANumber = Int32.TryParse(movies, out count);
            }
            return count;
        }
        static void listMovies(String file)
        {
            int movies = validateEntryforListing();
            String exit = "";
            String message = "Enter 1 to exit and anything else to continue";
            StreamReader sr = new StreamReader(file);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {

                for (int i = 1; i <= movies; i++)
                {
                    Console.WriteLine(sr.ReadLine());
                    if (sr.EndOfStream)
                    {
                        message = "Press anything to exit";
                        break;
                    }
                }
                Console.WriteLine(message);
                exit = Console.ReadLine();
                if (exit == "1")
                {
                    break;
                }
            }
            if (exit != "1")
            {
                Console.WriteLine(sr.ReadToEnd());
            }
            sr.Close();

        }

        static String validateMovieToAdd(List<String[]> allMovies)
        {
            String movieTitle = getMovieName(allMovies);
            String allGenres = getGenre();
            return String.Concat(movieTitle, ",", allGenres);
        }

        static String getMovieName(List<String[]> allMovies)
        {
            Console.WriteLine("Enter the movie title and year for example: Toy Story (1995)");
            String movieTitle = Console.ReadLine();
            while (allMovies[1].Contains(movieTitle) || movieTitle == String.Empty)
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

        static String getGenre()
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

        static void addMovies(String file, List<String[]> allMovies)
        {
            String movieLising = validateMovieToAdd(allMovies);
            int movieID = 1 + Convert.ToInt32(allMovies[allMovies.Count - 1][0]);
            String movieToAdd = String.Concat(movieID, ",", movieLising);
            allMovies.Add(movieToAdd.Split(","));
            StreamWriter sw = new StreamWriter(file, true);
            sw.WriteLine(movieToAdd);
            sw.Close();
        }
    }
}
