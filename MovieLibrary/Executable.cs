using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MovieLibrary.A9;

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
            askForAction();
        }

        public static void askForAction()
        {
            String input = "";

            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IMovieReader, MovieReader>();
            services.AddTransient<IMovieWriter, MovieWriter>();
            services.AddTransient<IMovieSample, MovieSample>();
            services.AddTransient<IMediaSearch, MediaSearch>();
            var serviceProvider = services.BuildServiceProvider();

            string movieFile = "ml-latest-small/movies.csv";
            string showFile = "ml-latest-small/shows.csv";
            string videoFile = "ml-latest-small/videos.csv";

            if (File.Exists(movieFile))
            {
                List<string[]> movieList = new List<string[]>();
                StreamReader sr = new StreamReader(movieFile);
                while (!sr.EndOfStream) movieList.Add(sr.ReadLine().Split(","));
                sr.Close();

                while (input != "0")
                {
                    Console.WriteLine("Press 0 to exit, press 1 to read or write from the movie listing");
                    Console.WriteLine("press 2 to search from all media types");
                    Console.WriteLine("Press 3 to display a sample movie, show or video");

                    input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.WriteLine("Press 1 to list movies, press 2 to write to the list and anything else to return to the main menu");
                        input = Console.ReadLine();
                        if (input == "1")
                        {
                            var movieReader = serviceProvider.GetService<IMovieReader>();
                            movieReader.listMovies(movieFile);
                        }
                        if (input == "2")
                        {
                            var movieWriter = serviceProvider.GetService<IMovieWriter>();
                            movieList.Add(movieWriter.addMovies(movieFile, movieList));
                        }
                        input = "";
                    }
                    if (input == "2")
                    {
                        if (File.Exists(showFile) && File.Exists(videoFile))
                        {
                            List<String[]> showList = new List<string[]>();
                            StreamReader srShow = new StreamReader(showFile);
                            srShow.ReadLine();
                            while (!srShow.EndOfStream) showList.Add(srShow.ReadLine().Split(","));
                            srShow.Close();
                            List<String[]> videoList = new List<string[]>();
                            StreamReader srVideo = new StreamReader(videoFile);
                            srVideo.ReadLine();
                            while (!srVideo.EndOfStream) videoList.Add(srVideo.ReadLine().Split(","));
                            srVideo.Close();
                            var mediaSearch = serviceProvider.GetService<IMediaSearch>();
                            mediaSearch.mediaSearch(movieList, showList, videoList);
                        }
                        else Console.WriteLine("The data for shows and/or movies could not be found\n Returning to main menu");
                    }
                    if (input == "3")
                    {
                        var movieSample = serviceProvider.GetService<IMovieSample>();
                        movieSample.movieSample();
                    }
                }
            }
            else Console.WriteLine("Could not find movie data\nExiting program");
        }
    }
}
