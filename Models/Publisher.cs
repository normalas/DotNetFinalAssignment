using System.Collections.Generic;

namespace DotNet.Models
{
    public class Publisher : Company
    {
        public Publisher(string CompanyName) : base(CompanyName) { }

        public ICollection<Game> PublishedGames { get; set; }
    }
}
