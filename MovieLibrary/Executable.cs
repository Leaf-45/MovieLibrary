using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MovieLibrary.Context;
using MovieLibrary.MovieLister;

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
            var serviceProvider = GetAllServices();
                while (input != "0")
                {
                    Console.WriteLine("Press 0 to exit\nPress 1 to look over the movie listing\n" +
                        "Press 2 to edit the movie listing\nPress 3 to add and display users" +
                        "\nPress 4 to add ratings and display ratings on movies\n" +
                        "Press 5 to list the top rated movie by an age range or ocupation");
                    input = Console.ReadLine();
                using var context = new MovieContext();
                switch (input)
                    {
                        case "1":
                        MovieListing(serviceProvider, context);
                        break;
                        case "2":
                        MovieListEditing(serviceProvider, context);
                        break;
                        case "3":
                        UserDisplayAndAdding(serviceProvider, context); 
                        break;
                        case "4":
                        RatingsDisplayAndAdding(serviceProvider, context);
                        break;
                        case "5":
                        getTopRatedMovie(serviceProvider, context);
                        break;
                    }
                }  
        }

        public static void getTopRatedMovie(ServiceProvider serviceProvider, MovieContext context) 
        {
            Console.WriteLine("Press 1 to display a top rated movie based on different age groups\n" +
                "Press 2 to display a top rated movie based on occupation\n" +
                "Press anything else to go the main menu");
            string input = Console.ReadLine();
            var getTopRatedMovie = serviceProvider.GetService<IGetTopRatedMovie>();
            if (input == "1") getTopRatedMovie.DisplayByAge(context);
            if (input == "2") getTopRatedMovie.DisplayByOccupation(context);
        }

        public static void RatingsDisplayAndAdding(ServiceProvider serviceProvider, MovieContext context) 
        {
            Console.WriteLine("Press 1 to display all the ratings on a movie\nPress 2 to add a new rating\n" +
                "Press anything else to go the main menu");
            string input = Console.ReadLine();
            if (input == "1") serviceProvider.GetService<IDisplayMovieRatings>().DisplayRatings(context);
            if (input == "2") serviceProvider.GetService<IAddRatings>().AddNewRating(context);
        }

        public static void UserDisplayAndAdding(ServiceProvider serviceProvider, MovieContext context) 
        {
            Console.WriteLine("Press 1 to display all the users\nPress 2 to add a new user\n" +
                "Press anything else to go the main menu");
            string input = Console.ReadLine();
            if (input == "1") serviceProvider.GetService<IDisplayUser>().DisplayUser(context); 
            if (input == "2") serviceProvider.GetService<IAddUser>().AddNewUser(context);
        }

        public static void MovieListing(ServiceProvider serviceProvider, MovieContext context) 
        {
            Console.WriteLine("Press 1 to look over all the movies\nPress 2 to search for a movie\n" +
                                "Press anything else to go back the main menu");
            string input = Console.ReadLine();
            if (input == "1") serviceProvider.GetService<IMovieListing>().ListAllMovies(context);
            if (input == "2") serviceProvider.GetService<IMovieSearch>().Search(context);
        }

        public static void MovieListEditing(ServiceProvider serviceProvider, MovieContext context) 
        {
            Console.WriteLine("Press 1 to add a movie\nPress 2 to update a movie\n" +
                                "Press 3 to delete a movie\nPress anything else to go to the main menu");
            string input = Console.ReadLine();
            if (input == "1") serviceProvider.GetService<IMovieWriter>().AddMovie(context);
            if (input == "2") serviceProvider.GetService<IMovieUpdater>().UpdateMovie(context);
            if (input == "3") serviceProvider.GetService<IMovieDeleter>().DeleteMovie(context);
        }

        public static ServiceProvider GetAllServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IMovieWriter, MovieWriter>();
            services.AddTransient<IMovieSearch, MovieSearch>();
            services.AddTransient<IMovieUpdater, MovieUpdater>();
            services.AddTransient<IMovieDeleter, MovieDeleter>();
            services.AddTransient<IMovieListing, MovieListing>();
            services.AddTransient<IDisplayUser, DisplayUsers>();
            services.AddTransient<IAddUser, AddUser>();
            services.AddTransient<IAddRatings, AddRatings>();
            services.AddTransient<IDisplayMovieRatings, DisplayMovieRatings>();
            services.AddTransient<IGetTopRatedMovie, GetTopRatedMovie>();
            return services.BuildServiceProvider();
        }
    }
}