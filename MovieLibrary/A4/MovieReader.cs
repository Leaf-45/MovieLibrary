namespace MovieLibrary
{
    public class MovieReader : IMovieReader
    {
        private int validateEntryforListing()
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
        public void listMovies(String file)
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
    }
}
