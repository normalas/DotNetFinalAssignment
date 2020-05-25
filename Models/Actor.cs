using System.Collections.Generic;

namespace DotNet.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        public string ActorName { get; set; }
        public ICollection<Character> Plays { get; } = new List<Character>();

        public override string ToString()
        {
            return $"{ActorName}";
        }
    }
}
