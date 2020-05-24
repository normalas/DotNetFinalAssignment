namespace DotNet.Models
{
    public class Game
    {
        public Game(string GameTitle)
        {
            this.GameTitle = GameTitle;
        }
        public Game(string GameTitle, Publisher Publisher, Developer Developer)
        {
            this.GameTitle = GameTitle;
            this.Publisher = Publisher;
            this.Developer = Developer;
        } 
        public int GameId { get; set; }

        public string GameTitle { get; set; }

        public string GameSubtitle { get; set; }

        public string GameSeries { get; set; }

        public string BoxArtImage { get; set; }

        public Developer Developer { get; set; }

        public Publisher Publisher { get; set; }

        //Estimated Time To Completion, aka how long it is estimated to complete a full, regular playthrough
        public float EstimatedTtc { get; set; }
    }
}
