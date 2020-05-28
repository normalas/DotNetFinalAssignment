using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNet.Models
{
    public class VideoGame
    {
        [Key]
        public int GameId { get; set; }
        public string GameTitle { get; set; }
        public string GameSubtitle { get; set; }
        public string DeveloperName { get; set; }
        public string PublisherName { get; set; }
        public string CharacterName { get; set; }

        public override string ToString()
        {
            return $"ID {GameId}:\n{GameTitle}: {GameSubtitle}";
        }
    }
}
