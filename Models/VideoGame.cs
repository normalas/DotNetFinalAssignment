using System;
using System.Collections.Generic;

namespace DotNet.Models
{
    public class VideoGame : Game
    {
        public VideoGame(string GameTitle) : base(GameTitle) { }
        public ICollection<Character> Cast { get; set; }

        public DateTime ReleaseDate { get; set; }

    }
}
