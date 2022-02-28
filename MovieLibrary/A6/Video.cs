namespace MovieLibrary
{
    internal class Video : Media
    {
        public string format { get; set; }
        public int length { get; set; }
        public int[] regions { get; set; }

        public Video(string format, int length, int[] regions) 
        { 
            this.format = format;
            this.length = length;  
            this.regions = regions;
        }

        public override String Display()
        {
            return String.Concat(ID, ",", title, ",", format, ",", length, ",", String.Join("|",regions));
        }
    }
}
