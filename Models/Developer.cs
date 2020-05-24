using System.Collections.Generic;

namespace DotNet.Models
{
    public class Developer : Company
    {
        public Developer(string CompanyName) : base(CompanyName) { }

        public ICollection<Game> DevelopedGames { get; set; }
    }
}
