namespace MovieLibrary
{
    public abstract class Media
    {
        public int ID { get; set; }
        public string title { get; set;}

        public abstract String Display(); 
    }
}
