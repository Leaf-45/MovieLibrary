using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MovieLibrary.Context;

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
            AskForAction();
        }

        public static void AskForAction()
        {
            String input = "";
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IMovieWriter, MovieWriter>();
            services.AddTransient<IMovieSearch, MovieSearch>();
            services.AddTransient<IMovieUpdater, MovieUpdater>();
            services.AddTransient<IMovieDeleter, MovieDeleter>();
            var serviceProvider = services.BuildServiceProvider();
            using (var context = new MovieContext()) 
            {
                while (input != "0")
                {
                    Console.WriteLine("Press 0 to exit\nPress 1 to search for a movie\nPress 2 to add a movie" +
                        "\nPress 3 to update a movie\nPress 4 to delete a movie");
                    input = Console.ReadLine();

                    if (input == "1")
                    {
                        var movieSearch = serviceProvider.GetService<IMovieSearch>();
                        movieSearch.Search(context.Movies.ToList());
                    }
                    if (input == "2")          
                    {     
                        var movieWriter = serviceProvider.GetService<IMovieWriter>();
                        movieWriter.AddMovie(context);
                    }
                    if (input == "3")
                    {
                        var movieUpdater = serviceProvider.GetService<IMovieUpdater>();
                        movieUpdater.UpdateMovie(context); 
                    }
                    if (input == "4") 
                    {
                        var movieDeleter = serviceProvider.GetService<IMovieDeleter>();
                        movieDeleter.DeleteMovie(context);
                    }
                }
            }
        }
    }
}
