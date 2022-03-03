using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
            var serviceProvider = services.BuildServiceProvider();
            List<Movie> entries = new List<Movie>();
            List<String> keys = new List<string>();
            
            string key = "";
            while (input != "0") 
            { 
                Console.WriteLine("Press 0 to exit, press 1 to read from the movie listing");  
                Console.WriteLine("press 2 to write to the movie listing"); 
                Console.WriteLine("Press 3 to display a sample movie, show or video"); 
                input = Console.ReadLine();    
                if (input == "1")    
                {    
                    var movieReader = serviceProvider.GetService<IMovieReader>();      
                    movieReader.listMovies(keys);
                }  
                if (input == "2")
                {
                    var movieWriter = serviceProvider.GetService<IMovieWriter>();
                    key = movieWriter.addMovies(entries);
                    keys.Add(key);
                    entries.Add(JsonConvert.DeserializeObject<Movie>(key)); 
                }
                if (input == "3") 
                {
                    var movieSample = serviceProvider.GetService<IMovieSample>();
                    movieSample.movieSample();   
                }
            } 
        }
    }
}
