namespace MovieLibrary
{
    internal class Show : Media
    {
        public int season { get; set; }
        public int episode { get; set; }
        string[] writers { get; set; }

        public Show(int season, int episode, string[] writers) 
        { 
            this.season = season;
            this.episode = episode;
            this.writers = writers;
        }

        public override String Display()
        {
            return String.Concat(ID, ",", title, ",", season, ",", episode, ",", String.Join("|",writers));
        }
    }
}
