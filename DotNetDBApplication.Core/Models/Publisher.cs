using System.Collections.Generic;

namespace DotNet.Models
{
    public class Publisher
    {
        public Publisher() { }
        public Publisher(string PublisherName)
        {
            this.PublisherName = PublisherName;
        }

        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public ICollection<VideoGame> PublishedGames { get; } = new List<VideoGame>();
    }
}
