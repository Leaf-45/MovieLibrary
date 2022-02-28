namespace MovieLibrary
{
    public class MovieSample
    {
        public void movieSample() 
        {
            Console.WriteLine("Press 1 to view a sample movie, press 2 to view a sample video, press 3 to view a sample show");
            String input = Console.ReadLine();
            Media media = null;
            if (input == "1")
            {
                string movieFile = "ml-latest-small/movies.csv";
                StreamReader sr = new StreamReader(movieFile);
                sr.ReadLine();
                String[] movie = sr.ReadLine().Split(",");
                List<string> entrie = new List<string>(movie);
                for (int i = 0; i <= 1; i++)
                {
                    entrie.RemoveAt(0);
                }
                media = new Movie(entrie.ToArray());
                media.ID = Convert.ToInt32(movie[0]);
                media.title = movie[1];
                Console.WriteLine(media.Display());
            }
            else if (input == "2")
            {
                string videoFile = "ml-latest-small/videos.csv";
                StreamReader sr = new StreamReader(videoFile);
                sr.ReadLine();
                String[] video = sr.ReadLine().Split(",");
                List<string> entrie = new List<string>(video);
                for (int i = 0; i <= 3; i++)
                {
                    entrie.RemoveAt(0);
                }
                string[] test = entrie.ToArray();
                media = new Video(video[2], Convert.ToInt32(video[3]), Array.ConvertAll(test[0].Split("|"), e => int.Parse(e)));
                media.ID = Convert.ToInt32(video[0]);
                media.title = video[1];
                Console.WriteLine(media.Display());
            }
            else if (input == "3")
            {
                string showFile = "ml-latest-small/shows.csv";
                StreamReader sr = new StreamReader(showFile);
                sr.ReadLine();
                String[] show = sr.ReadLine().Split(",");
                List<string> entrie = new List<string>(show);
                for (int i = 0; i <= 3; i++)
                {
                    entrie.RemoveAt(0);
                }
                media = new Show(Convert.ToInt32(show[2]), Convert.ToInt32(show[3]), entrie.ToArray());
                media.ID = Convert.ToInt32(show[0]);
                media.title = show[1];
                Console.WriteLine(media.Display());

            }
            else Console.WriteLine("Invalid input going back to main menu");
        }
    }
}
