using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required]
        public int GameId { get; set; }

        public string GameTitle { get; set; }

        public string GameSubtitle { get; set; }

        public string GameSeries { get; set; }

        public string BoxArtImage { get; set; }

        [ForeignKey("DeveloperId")]
        public Developer Developer { get; set; }

        [ForeignKey("PublisherId")]
        public Publisher Publisher { get; set; }
        public ICollection<Character> Cast { get; } = new List<Character>();

        //Estimated Time To Completion, aka how long it is estimated to complete a full, regular playthrough
        public float EstimatedTtc { get; set; }

        public override string ToString()
        {
            return GameTitle;
        }
    }
}
