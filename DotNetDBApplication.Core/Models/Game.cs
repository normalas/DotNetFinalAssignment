using System.ComponentModel.DataAnnotations;

namespace DotNet.Models
{
    public class Game
    {
        public Game() { }
        public Game(string GameTitle)
        {
            this.GameTitle = GameTitle;
        }

        [Required]
        public int GameId { get; set; }

        public string GameTitle { get; set; }

        public string GameSubtitle { get; set; }

        public string GameSeries { get; set; }

        //Estimated hours to completion, aka how long it is estimated to complete a full, regular playthrough in hours

        public VideoGame PartOf { get; set; }

        public override string ToString()
        {
            return GameTitle;
        }
    }
}
