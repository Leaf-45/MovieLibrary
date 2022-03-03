using Newtonsoft.Json;

namespace MovieLibrary
{
    public class MovieReader : IMovieReader
    {
        public void listMovies(List<String> keys)
        {
            foreach (String key in keys) 
            {
                Movie movie = JsonConvert.DeserializeObject<Movie>(key);
                Console.WriteLine($"{movie.ID},{movie.title},{String.Join("|",movie.Genres)}");
            }
        }
    }
}
