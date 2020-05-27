using System.Collections.Generic;

namespace DotNet.Models
{
    public class Developer
    {
        public Developer() { }
        public Developer(string DeveloperName)
        {
            this.DeveloperName = DeveloperName;
        }
        public int DeveloperId { get; set; }
        public string DeveloperName { get; set; }
        public ICollection<VideoGame> DevelopedGames { get; private set; } = new List<VideoGame>();
    }
}
