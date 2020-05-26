using System.Collections.Generic;

namespace DotNet.Models
{
    public class Publisher : Company
    {
        public Publisher() : base() { }
        public Publisher(string CompanyName) : base(CompanyName) { }

        public int PublisherId { get; set; }
        public ICollection<VideoGame> PublishedGames { get; } = new List<VideoGame>();
    }
}
