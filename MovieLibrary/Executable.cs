using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace MovieLibrary
{
    public class Executable
    {
        static void Main(String[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            var serviceProvider = serviceCollection
                .AddLogging(x => x.AddConsole())
                .BuildServiceProvider();

            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            var logger = loggerFactory.CreateLogger<Executable>();
            logger.Log(LogLevel.Information, "Executing the movie library program");
            loggerFactory.Dispose();
            String file = "ml-latest-small/movies.csv";
            askForAction(file);
        }

        public static void askForAction(String file)
        {
            String input = "";

            if (File.Exists(file))
            {
                while (input != "0")
                {
                    Console.WriteLine("Press 0 to exit, press 1 to view the movie list, press 2 to add to the move list");
                    Console.WriteLine("Press 3 to display a sample movie, show or video");
                    input = Console.ReadLine();
                    if (input == "1")
                    {
                        MovieReader movieReader = new MovieReader();
                        movieReader.listMovies(file);
                    }
                    if (input == "2")
                    {
                        List<string[]> entries = new List<string[]>();
                        StreamReader sr = new StreamReader(file);
                        while (!sr.EndOfStream)
                        {
                            String line = sr.ReadLine();
                            entries.Add(line.Split(","));
                        }
                        sr.Close();
                        MovieWriter movieWriter = new MovieWriter();
                        movieWriter.addMovies(file, entries);
                    }
                    if (input == "3") 
                    {
                        MovieSample movieSample = new MovieSample();
                        movieSample.movieSample();
                    }
                }
            }
            else Console.WriteLine("The program is going to end as it is unable to locate the data for adding to and listing movies");
        }
    }
}
