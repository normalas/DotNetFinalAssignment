using System.Collections.Generic;

namespace DotNet.Models
{
    public class Developer : Company
    {
        public Developer() : base() { }
        public Developer(string CompanyName) : base(CompanyName) { }

        public int DeveloperId { get; set; }

        public ICollection<VideoGame> DevelopedGames { get; } = new List<VideoGame>();
    }
}
