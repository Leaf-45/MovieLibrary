using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieLibrary.A9
{
    internal class MediaSearch : IMediaSearch
    {
        public void mediaSearch(List<String[]> movieList, List<String[]> showList, List<String[]> videoList) 
        {
            Console.WriteLine("Type in the media you are searching for");
            string response = Console.ReadLine();
            List<String[]> allMedia = movieList.Concat(showList).Concat(videoList).ToList();
            IEnumerable<string[]> query = allMedia.Where(x => x[1].ToLower() == response.ToLower());
            int matches = query.Count();
            if (matches != 0)
            {
                /* movie and show found are to prevent a bug where if two or more media types shared a title
                 * it would be counted as the type of media that was checked first
                 for example a video with a title of Toy Story (1995) would be displayed as a movie first */ 
                bool movieFound = false;
                bool showFound = false;
                Console.WriteLine($"There were {matches} matche(s)");
                foreach (string[] item in query) 
                {
                    if (movieList.Exists(x => x[1] == item[1]) && !movieFound)
                    {
                        movieResult(item);
                        movieFound = true;
                    }
                    else if (showList.Exists(x => x[1] == item[1]) && !showFound)
                    {
                        showResult(item);
                        showFound = true;
                    }
                    else if (videoList.Exists(x => x[1] == item[1])) 
                    {
                        videoResult(item);
                    } 
                }
            }
            else Console.WriteLine("Could not find media");
        }

        private void movieResult(string[] movie) 
        {
            Console.WriteLine("There was a movie found");
            Console.WriteLine($"The ID is {movie[0]}");
            Console.WriteLine($"The title is {movie[1]}");
            Console.WriteLine($"The genres are {movie[2]}");
        }

        private void showResult(string[] show)
        {
            Console.WriteLine("There was a show found");
            Console.WriteLine($"The ID is {show[0]}");
            Console.WriteLine($"The title is {show[1]}");
            Console.WriteLine($"The season is {show[2]}");
            Console.WriteLine($"The episode is {show[3]}");
            Console.WriteLine($"The writers are {show[4]}");
        }

        private void videoResult(string[] video)
        {
            Console.WriteLine("There was a video found");
            Console.WriteLine($"The ID is {video[0]}");
            Console.WriteLine($"The title is {video[1]}");
            Console.WriteLine($"The format is {video[2]}");
            Console.WriteLine($"The length is {video[3]}");
            Console.WriteLine($"The regions are {video[4]}");
        }
    }
}
