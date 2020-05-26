using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DotNet.Models
{
    public class VideoGame
    {
        [Key]
        public int GameId { get; set; }
        public Game Game { get; set; }

        [Key]
        public int DeveloperId { get; set; }
        public Developer Developer { get; set; }

        [Key]
        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }

        [Key]
        public int CharacterId { get; set; }
        public Character Character { get; set; }

        [Key]
        public int ActorId { get; set; }
        public Actor Actor { get; set; }
    }
}
