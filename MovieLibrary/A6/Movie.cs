namespace MovieLibrary
{
    internal class Movie : Media
    {
        public string[] Genres { get; set;}

        public Movie(String[] Genres) 
        { 
            this.Genres = Genres;
        }

        public override String Display()
        {
            return String.Concat(ID, ",", title, ",", String.Join('|', Genres));
        }
    }
}
