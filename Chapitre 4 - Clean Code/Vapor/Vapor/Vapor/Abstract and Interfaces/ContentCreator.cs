namespace Vapor
{
    public abstract class ContentCreator
    {
        public string Name { get; set; }
        public List<Game> GamesReleased { get; set; }

        protected ContentCreator(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            GamesReleased = new List<Game>();
        }
    }
}